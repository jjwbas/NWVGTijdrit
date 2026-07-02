using Blazored.LocalStorage;

namespace NWVGTijdrit.Data;

/// <summary>
/// Service voor het opslaan en ophalen van alle tijdrit-data.
/// Gebruikt browser LocalStorage voor persistente opslag.
/// 
/// UITLEG: Deze service fungeert als "database" voor de applicatie.
/// In een WebAssembly app draait alles in de browser, dus we gebruiken
/// LocalStorage (browser-opslag) om data te bewaren tussen sessies.
/// </summary>
public class DataService
{
    private readonly ILocalStorageService _localStorage;

    // Keys voor LocalStorage - elke datasoort krijgt zijn eigen "tabel"
    private const string DeelnemersKey = "tijdrit_deelnemers";
    private const string TijdrittenKey = "tijdrit_tijdritten";
    private const string ResultatenKey = "tijdrit_resultaten";
    private const string CategorieenKey = "tijdrit_categorieen";
    private const string SeededKey = "tijdrit_seeded"; // Houdt bij of seed data al geladen is

    public DataService(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    #region Deelnemers

    /// <summary>
    /// Haalt alle deelnemers op uit de opslag.
    /// Bij eerste gebruik worden automatisch de deelnemers uit het Excel-bestand geladen.
    /// </summary>
    public async Task<List<Deelnemer>> GetDeelnemersAsync()
    {
        // Controleer of we al seed data hebben geladen
        var isSeeded = await _localStorage.GetItemAsync<bool>(SeededKey);
        if (!isSeeded)
        {
            await SeedAllDataAsync();
        }

        var deelnemers = await _localStorage.GetItemAsync<List<Deelnemer>>(DeelnemersKey);
        return deelnemers ?? new List<Deelnemer>();
    }

    /// <summary>
    /// Laadt alle seed data: deelnemers, categorieen, tijdritten en resultaten.
    /// </summary>
    private async Task SeedAllDataAsync()
    {
        // 1. Laad deelnemers
        var seedDeelnemers = SeedData.GetDeelnemers();
        await _localStorage.SetItemAsync(DeelnemersKey, seedDeelnemers);

        // 2. Laad categorieen
        var seedCategorieen = SeedData.GetCategorieen();
        await _localStorage.SetItemAsync(CategorieenKey, seedCategorieen);

        // 3. Laad tijdritten
        var seedTijdritten = SeedData.GetTijdritten();
        await _localStorage.SetItemAsync(TijdrittenKey, seedTijdritten);

        // 4. Laad resultaten (koppel naam aan DeelnemerId)
        var seedResultaten = SeedData.GetResultaten();
        var resultaten = new List<TijdritResultaat>();

        foreach (var sr in seedResultaten)
        {
            // Zoek deelnemer op naam
            var deelnemer = seedDeelnemers.FirstOrDefault(d => 
                d.Naam.Equals(sr.DeelnemerNaam, StringComparison.OrdinalIgnoreCase));

            if (deelnemer != null)
            {
                resultaten.Add(new TijdritResultaat
                {
                    Id = Guid.NewGuid(),
                    TijdritId = sr.TijdritId,
                    DeelnemerId = deelnemer.Id,
                    Startvolgorde = sr.Startvolgorde,
                    AantalRondes = sr.AantalRondes,
                    Starttijd = sr.Starttijd,
                    Passagetijden = sr.Passagetijden
                });
            }
        }

        await _localStorage.SetItemAsync(ResultatenKey, resultaten);

        // Markeer als geseeded
        await _localStorage.SetItemAsync(SeededKey, true);
    }

    /// <summary>
    /// Haalt een deelnemer op basis van ID.
    /// </summary>
    public async Task<Deelnemer?> GetDeelnemerAsync(Guid id)
    {
        var deelnemers = await GetDeelnemersAsync();
        return deelnemers.FirstOrDefault(d => d.Id == id);
    }

    /// <summary>
    /// Voegt een nieuwe deelnemer toe of werkt een bestaande bij.
    /// </summary>
    public async Task SaveDeelnemerAsync(Deelnemer deelnemer)
    {
        var deelnemers = await GetDeelnemersAsync();

        // Zoek of deze deelnemer al bestaat (update) of nieuw is (toevoegen)
        var bestaande = deelnemers.FirstOrDefault(d => d.Id == deelnemer.Id);
        if (bestaande != null)
        {
            // Update bestaande
            deelnemers.Remove(bestaande);
        }

        deelnemers.Add(deelnemer);
        await _localStorage.SetItemAsync(DeelnemersKey, deelnemers);
    }

    /// <summary>
    /// Verwijdert een deelnemer.
    /// </summary>
    public async Task DeleteDeelnemerAsync(Guid id)
    {
        var deelnemers = await GetDeelnemersAsync();
        deelnemers.RemoveAll(d => d.Id == id);
        await _localStorage.SetItemAsync(DeelnemersKey, deelnemers);
    }

    #endregion

    #region Categorieen

    /// <summary>
    /// Haalt alle categorieen op (apart beheerd).
    /// </summary>
    public async Task<List<string>> GetCategorieenAsync()
    {
        // Zorg dat seed data geladen is
        await GetDeelnemersAsync();

        var categorieen = await _localStorage.GetItemAsync<List<string>>(CategorieenKey);
        return categorieen ?? new List<string>();
    }

    /// <summary>
    /// Voegt een nieuwe categorie toe.
    /// </summary>
    public async Task AddCategorieAsync(string categorie)
    {
        if (string.IsNullOrWhiteSpace(categorie)) return;

        var categorieen = await GetCategorieenAsync();
        if (!categorieen.Contains(categorie, StringComparer.OrdinalIgnoreCase))
        {
            categorieen.Add(categorie);
            categorieen = categorieen.OrderBy(c => c).ToList();
            await _localStorage.SetItemAsync(CategorieenKey, categorieen);
        }
    }

    /// <summary>
    /// Verwijdert een categorie (alleen als er geen deelnemers zijn met die categorie).
    /// Retourneert false als verwijderen niet mogelijk is.
    /// </summary>
    public async Task<bool> DeleteCategorieAsync(string categorie)
    {
        var deelnemers = await _localStorage.GetItemAsync<List<Deelnemer>>(DeelnemersKey) ?? new List<Deelnemer>();

        // Check of er deelnemers zijn met deze categorie
        if (deelnemers.Any(d => d.Categorie.Equals(categorie, StringComparison.OrdinalIgnoreCase)))
        {
            return false; // Kan niet verwijderen
        }

        var categorieen = await GetCategorieenAsync();
        categorieen.RemoveAll(c => c.Equals(categorie, StringComparison.OrdinalIgnoreCase));
        await _localStorage.SetItemAsync(CategorieenKey, categorieen);
        return true;
    }

    /// <summary>
    /// Telt het aantal deelnemers per categorie.
    /// </summary>
    public async Task<Dictionary<string, int>> GetDeelnemersPerCategorieAsync()
    {
        var deelnemers = await GetDeelnemersAsync();
        return deelnemers
            .GroupBy(d => d.Categorie)
            .ToDictionary(g => g.Key, g => g.Count());
    }

    #endregion

    #region Tijdritten

    /// <summary>
    /// Haalt alle tijdritten op.
    /// </summary>
    public async Task<List<Tijdrit>> GetTijdrittenAsync()
    {
        var tijdritten = await _localStorage.GetItemAsync<List<Tijdrit>>(TijdrittenKey);
        return tijdritten ?? new List<Tijdrit>();
    }

    /// <summary>
    /// Haalt één tijdrit op basis van ID.
    /// </summary>
    public async Task<Tijdrit?> GetTijdritAsync(Guid id)
    {
        var tijdritten = await GetTijdrittenAsync();
        return tijdritten.FirstOrDefault(t => t.Id == id);
    }

    /// <summary>
    /// Slaat een tijdrit op (nieuw of bestaand).
    /// </summary>
    public async Task SaveTijdritAsync(Tijdrit tijdrit)
    {
        var tijdritten = await GetTijdrittenAsync();
        var bestaande = tijdritten.FirstOrDefault(t => t.Id == tijdrit.Id);
        if (bestaande != null)
        {
            tijdritten.Remove(bestaande);
        }
        tijdritten.Add(tijdrit);
        await _localStorage.SetItemAsync(TijdrittenKey, tijdritten);
    }

    /// <summary>
    /// Verwijdert een tijdrit en alle bijbehorende resultaten.
    /// </summary>
    public async Task DeleteTijdritAsync(Guid id)
    {
        var tijdritten = await GetTijdrittenAsync();
        tijdritten.RemoveAll(t => t.Id == id);
        await _localStorage.SetItemAsync(TijdrittenKey, tijdritten);

        // Verwijder ook alle resultaten van deze tijdrit
        var resultaten = await GetResultatenAsync();
        resultaten.RemoveAll(r => r.TijdritId == id);
        await _localStorage.SetItemAsync(ResultatenKey, resultaten);
    }

    #endregion

    #region Resultaten

    /// <summary>
    /// Haalt alle resultaten op.
    /// </summary>
    public async Task<List<TijdritResultaat>> GetResultatenAsync()
    {
        var resultaten = await _localStorage.GetItemAsync<List<TijdritResultaat>>(ResultatenKey);
        return resultaten ?? new List<TijdritResultaat>();
    }

    /// <summary>
    /// Haalt alle resultaten voor een specifieke tijdrit op.
    /// </summary>
    public async Task<List<TijdritResultaat>> GetResultatenVoorTijdritAsync(Guid tijdritId)
    {
        var resultaten = await GetResultatenAsync();
        return resultaten.Where(r => r.TijdritId == tijdritId).ToList();
    }

    /// <summary>
    /// Haalt één resultaat op basis van ID.
    /// </summary>
    public async Task<TijdritResultaat?> GetResultaatAsync(Guid id)
    {
        var resultaten = await GetResultatenAsync();
        return resultaten.FirstOrDefault(r => r.Id == id);
    }

    /// <summary>
    /// Slaat een resultaat op (nieuw of bestaand).
    /// </summary>
    public async Task SaveResultaatAsync(TijdritResultaat resultaat)
    {
        var resultaten = await GetResultatenAsync();
        var bestaande = resultaten.FirstOrDefault(r => r.Id == resultaat.Id);
        if (bestaande != null)
        {
            resultaten.Remove(bestaande);
        }
        resultaten.Add(resultaat);
        await _localStorage.SetItemAsync(ResultatenKey, resultaten);
    }

    /// <summary>
    /// Verwijdert een resultaat.
    /// </summary>
    public async Task DeleteResultaatAsync(Guid id)
    {
        var resultaten = await GetResultatenAsync();
        resultaten.RemoveAll(r => r.Id == id);
        await _localStorage.SetItemAsync(ResultatenKey, resultaten);
    }

    #endregion

    #region Import/Export/Reset

    /// <summary>
    /// Importeert data uit een backup. Overschrijft alle bestaande data.
    /// </summary>
    public async Task ImportDataAsync(
        List<Deelnemer> deelnemers,
        List<Tijdrit> tijdritten,
        List<TijdritResultaat> resultaten,
        List<string> categorieen)
    {
        await _localStorage.SetItemAsync(DeelnemersKey, deelnemers);
        await _localStorage.SetItemAsync(TijdrittenKey, tijdritten);
        await _localStorage.SetItemAsync(ResultatenKey, resultaten);
        await _localStorage.SetItemAsync(CategorieenKey, categorieen);
        await _localStorage.SetItemAsync(SeededKey, true);
    }

    /// <summary>
    /// Reset alle data en herlaadt de seed data.
    /// </summary>
    public async Task ResetAllDataAsync()
    {
        await _localStorage.RemoveItemAsync(DeelnemersKey);
        await _localStorage.RemoveItemAsync(TijdrittenKey);
        await _localStorage.RemoveItemAsync(ResultatenKey);
        await _localStorage.RemoveItemAsync(CategorieenKey);
        await _localStorage.RemoveItemAsync(SeededKey);

        // Herlaad seed data
        await SeedAllDataAsync();
    }

    #endregion
}
