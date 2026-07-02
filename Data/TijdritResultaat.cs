namespace NWVGTijdrit.Data;

/// <summary>
/// Representeert het resultaat van één deelnemer in een tijdrit.
/// Bevat startvolgorde, tijden en berekende statistieken.
/// Komt overeen met de "Invoer Tijdrit" en "Uitslagen" sheets in Excel.
/// </summary>
public class TijdritResultaat
{
    /// <summary>Unieke identifier voor dit resultaat</summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>Verwijzing naar de tijdrit</summary>
    public Guid TijdritId { get; set; }

    /// <summary>Verwijzing naar de deelnemer</summary>
    public Guid DeelnemerId { get; set; }

    /// <summary>Startvolgorde van de deelnemer (1 = eerste starter)</summary>
    public int Startvolgorde { get; set; }

    /// <summary>Aantal rondes dat deze deelnemer rijdt</summary>
    public int AantalRondes { get; set; }

    /// <summary>Starttijd (stopwatch-tijd op moment van start)</summary>
    public TimeSpan Starttijd { get; set; }

    /// <summary>Lijst van passagetijden (stopwatch-tijd bij elke passage van de finish)</summary>
    public List<TimeSpan> Passagetijden { get; set; } = new();

    /// <summary>
    /// Berekent de netto rijtijd (laatste passage minus starttijd).
    /// Dit is de daadwerkelijke tijd die de renner nodig had.
    /// </summary>
    public TimeSpan NettoTijd
    {
        get
        {
            if (Passagetijden.Count == 0) return TimeSpan.Zero;
            return Passagetijden.Last() - Starttijd;
        }
    }

    /// <summary>
    /// Berekent de totale afgelegde afstand in kilometers.
    /// </summary>
    /// <param name="rondeLengteKm">Lengte van één ronde in km</param>
    public double AfstandKm(double rondeLengteKm) => AantalRondes * rondeLengteKm;

    /// <summary>
    /// Berekent de gemiddelde snelheid in km/u.
    /// </summary>
    /// <param name="rondeLengteKm">Lengte van één ronde in km</param>
    public double GemiddeldeSnelheid(double rondeLengteKm)
    {
        if (NettoTijd.TotalHours == 0) return 0;
        return AfstandKm(rondeLengteKm) / NettoTijd.TotalHours;
    }

    /// <summary>
    /// Berekent de tijd per individuele ronde.
    /// Ronde 1 = Passage 1 - Starttijd
    /// Ronde N = Passage N - Passage N-1
    /// Als een passage ontbreekt (TimeSpan.Zero), wordt de rondetijd ook Zero.
    /// </summary>
    public List<TimeSpan> Rondetijden
    {
        get
        {
            var rondetijden = new List<TimeSpan>();
            for (int i = 0; i < Passagetijden.Count; i++)
            {
                // Als de huidige passage ontbreekt (Zero), is de rondetijd ook Zero
                if (Passagetijden[i] == TimeSpan.Zero)
                {
                    rondetijden.Add(TimeSpan.Zero);
                }
                else if (i == 0)
                {
                    // Eerste ronde: passage - starttijd
                    rondetijden.Add(Passagetijden[i] - Starttijd);
                }
                else if (Passagetijden[i - 1] == TimeSpan.Zero)
                {
                    // Vorige passage ontbrak, kunnen we deze rondetijd niet berekenen
                    // Toon Zero als placeholder
                    rondetijden.Add(TimeSpan.Zero);
                }
                else
                {
                    // Normale berekening: huidige passage - vorige passage
                    rondetijden.Add(Passagetijden[i] - Passagetijden[i - 1]);
                }
            }
            return rondetijden;
        }
    }

    /// <summary>
    /// Geeft aan of er echte rondetijden beschikbaar zijn.
    /// False als er maar 1 passagetijd is voor meerdere rondes (alleen eindtijd bekend).
    /// </summary>
    public bool HeeftEchteRondetijden => Passagetijden.Count >= AantalRondes;
}
