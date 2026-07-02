namespace NWVGTijdrit.Data;

/// <summary>
/// Representeert een tijdrit-evenement op een specifieke datum.
/// Komt overeen met de metadata van een tijdrit in Excel.
/// </summary>
public class Tijdrit
{
    /// <summary>Unieke identifier voor de tijdrit</summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>Datum waarop de tijdrit plaatsvindt</summary>
    public DateTime Datum { get; set; } = DateTime.Today;

    /// <summary>Lengte van één ronde in kilometers (standaard 1.6 km)</summary>
    public double RondeLengteKm { get; set; } = 1.6;

    /// <summary>Optionele beschrijving van de tijdrit</summary>
    public string? Beschrijving { get; set; }
}
