namespace NWVGTijdrit.Data;

/// <summary>
/// Representeert een renner die kan deelnemen aan tijdritten.
/// Komt overeen met de "Deelnemers" sheet in Excel.
/// </summary>
public class Deelnemer
{
    /// <summary>Unieke identifier voor de deelnemer</summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>Naam van de deelnemer</summary>
    public string Naam { get; set; } = string.Empty;

    /// <summary>Categorie waarin de deelnemer rijdt, bijv. "2014 jongens"</summary>
    public string Categorie { get; set; } = string.Empty;

    /// <summary>Standaard aantal rondes voor deze deelnemer (1-6)</summary>
    public int StandaardRondes { get; set; } = 1;
}
