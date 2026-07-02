namespace NWVGTijdrit.Data;

/// <summary>
/// Bevat standaard data uit het Excel-bestand.
/// Deze worden automatisch geladen als er nog geen data is.
/// </summary>
public static class SeedData
{
    /// <summary>
    /// Geeft de lijst van deelnemers uit het originele Excel-bestand terug.
    /// </summary>
    public static List<Deelnemer> GetDeelnemers()
    {
        return new List<Deelnemer>
        {
            // 2018
            new() { Naam = "Thomas", Categorie = "2018 jongens", StandaardRondes = 1 },
            // 2017
            new() { Naam = "Florian", Categorie = "2017 jongens", StandaardRondes = 2 },
            new() { Naam = "Dieke", Categorie = "2017 meisjes", StandaardRondes = 2 },
            // 2016
            new() { Naam = "Doris", Categorie = "2016 meisjes", StandaardRondes = 1 },
            new() { Naam = "Mirthe", Categorie = "2016 meisjes", StandaardRondes = 2 },
            new() { Naam = "Amy", Categorie = "2016 meisjes", StandaardRondes = 1 },
            new() { Naam = "Tim", Categorie = "2016 jongens", StandaardRondes = 2 },
            new() { Naam = "Thijmen", Categorie = "2016 jongens", StandaardRondes = 2 },
            // 2015
            new() { Naam = "Hilene", Categorie = "2015 meisjes", StandaardRondes = 2 },
            // 2014
            new() { Naam = "Roos A", Categorie = "2014 meisjes", StandaardRondes = 2 },
            new() { Naam = "Jasmijn", Categorie = "2014 meisjes", StandaardRondes = 2 },
            new() { Naam = "Bente", Categorie = "2014 meisjes", StandaardRondes = 2 },
            new() { Naam = "Gijs", Categorie = "2014 jongens", StandaardRondes = 3 },
            new() { Naam = "Floris", Categorie = "2014 jongens", StandaardRondes = 3 },
            new() { Naam = "Casper", Categorie = "2014 jongens", StandaardRondes = 3 },
            new() { Naam = "Tobias", Categorie = "2014 jongens", StandaardRondes = 3 },
            // 2013
            new() { Naam = "Lea", Categorie = "2013 meisjes", StandaardRondes = 3 },
            new() { Naam = "Lars", Categorie = "2013 jongens", StandaardRondes = 3 },
            // 2012
            new() { Naam = "Suus", Categorie = "2012 meisjes", StandaardRondes = 3 },
            new() { Naam = "Neeltje", Categorie = "2012 meisjes", StandaardRondes = 3 },
            new() { Naam = "Daphne", Categorie = "2012 meisjes", StandaardRondes = 3 },
            new() { Naam = "Jesper", Categorie = "2012 jongens", StandaardRondes = 3 },
            new() { Naam = "Midas", Categorie = "2012 jongens", StandaardRondes = 3 },
            // 2011-2010 NWL
            new() { Naam = "Javet", Categorie = "2011-2010 NWL", StandaardRondes = 4 },
            new() { Naam = "Lindsay", Categorie = "2011-2010 NWL", StandaardRondes = 4 },
            new() { Naam = "Jurrian", Categorie = "2011-2010 NWL", StandaardRondes = 4 },
            new() { Naam = "Lies", Categorie = "2011-2010 NWL", StandaardRondes = 4 },
            new() { Naam = "Jibbe", Categorie = "2011-2010 NWL", StandaardRondes = 4 },
            new() { Naam = "Matvii", Categorie = "2011-2010 NWL", StandaardRondes = 4 },
            new() { Naam = "Jens", Categorie = "2011-2010 NWL", StandaardRondes = 4 },
            // 2008-2009 Junioren
            new() { Naam = "Siger", Categorie = "2008-2009 Junioren", StandaardRondes = 4 },
            new() { Naam = "Nout", Categorie = "2008-2009 Junioren", StandaardRondes = 4 },
            new() { Naam = "Jaron", Categorie = "2008-2009 Junioren", StandaardRondes = 4 },
            // Elite
            new() { Naam = "Lieke Hijlkema", Categorie = "2007 en ouder Elite dames", StandaardRondes = 4 },
            new() { Naam = "Merijn de Haan", Categorie = "2007 en ouder Elite heren", StandaardRondes = 4 },
            new() { Naam = "Sven van der Wal", Categorie = "2007 en ouder Elite heren", StandaardRondes = 4 },
        };
    }

    /// <summary>
    /// Geeft de lijst van alle categorieen terug.
    /// </summary>
    public static List<string> GetCategorieen()
    {
        return new List<string>
        {
            "2018 jongens",
            "2018 meisjes",
            "2017 jongens",
            "2017 meisjes",
            "2016 jongens",
            "2016 meisjes",
            "2015 jongens",
            "2015 meisjes",
            "2014 jongens",
            "2014 meisjes",
            "2013 jongens",
            "2013 meisjes",
            "2012 jongens",
            "2012 meisjes",
            "2011-2010 NWL",
            "2008-2009 Junioren",
            "2007 en ouder Elite dames",
            "2007 en ouder Elite heren",
        };
    }

    /// <summary>
    /// Geeft de tijdritten terug.
    /// </summary>
    public static List<Tijdrit> GetTijdritten()
    {
        return new List<Tijdrit>
        {
            // 2024 tijdritten (historisch, alleen eindtijden)
            new() 
            { 
                Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                Datum = new DateTime(2024, 6, 6), 
                RondeLengteKm = 1.6, 
                Beschrijving = "Tijdrit 6 juni 2024" 
            },
            new() 
            { 
                Id = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                Datum = new DateTime(2024, 7, 4), 
                RondeLengteKm = 1.6, 
                Beschrijving = "Tijdrit 4 juli 2024" 
            },
            // 2025 tijdritten (historisch, alleen eindtijden)
            new() 
            { 
                Id = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                Datum = new DateTime(2025, 3, 30), 
                RondeLengteKm = 1.6, 
                Beschrijving = "Tijdrit 30 maart 2025" 
            },
            new() 
            { 
                Id = Guid.Parse("66666666-6666-6666-6666-666666666666"),
                Datum = new DateTime(2025, 5, 15), 
                RondeLengteKm = 1.6, 
                Beschrijving = "Tijdrit 15 mei 2025" 
            },
            // 2026 tijdritten (met volledige data)
            new()
            { 
                Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                Datum = new DateTime(2026, 3, 31), 
                RondeLengteKm = 1.6, 
                Beschrijving = "Eerste tijdrit 2026" 
            },
            new() 
            { 
                Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                Datum = new DateTime(2026, 6, 30), 
                RondeLengteKm = 1.6, 
                Beschrijving = "Tweede tijdrit 2026" 
            },
        };
    }

    /// <summary>
    /// Geeft de resultaten terug. DeelnemerNaam wordt later gekoppeld aan echte DeelnemerId.
    /// </summary>
    public static List<SeedResultaat> GetResultaten()
    {
        return new List<SeedResultaat>
        {
            // ========== TIJDRIT 2024-06-06 ==========
            // Alleen eindtijden - geen rondetijden bijgehouden
            RE("33333333-3333-3333-3333-333333333333", 1, "Lies", 2, "5:32"),
            RE("33333333-3333-3333-3333-333333333333", 2, "Jesper", 2, "6:19"),
            RE("33333333-3333-3333-3333-333333333333", 3, "Lars", 2, "6:04"),
            RE("33333333-3333-3333-3333-333333333333", 4, "Neeltje", 2, "7:12"),
            RE("33333333-3333-3333-3333-333333333333", 5, "Casper", 2, "6:41"),

            // ========== TIJDRIT 2024-07-04 ==========
            RE("44444444-4444-4444-4444-444444444444", 1, "Lies", 2, "5:12"),
            RE("44444444-4444-4444-4444-444444444444", 2, "Jesper", 2, "6:04"),
            RE("44444444-4444-4444-4444-444444444444", 3, "Lars", 2, "6:13"),
            RE("44444444-4444-4444-4444-444444444444", 4, "Neeltje", 2, "7:53"),
            RE("44444444-4444-4444-4444-444444444444", 5, "Casper", 2, "6:28"),
            RE("44444444-4444-4444-4444-444444444444", 6, "Hilene", 2, "6:45"),
            RE("44444444-4444-4444-4444-444444444444", 7, "Tim", 2, "8:37"),
            RE("44444444-4444-4444-4444-444444444444", 8, "Mirthe", 2, "9:30"),

            // ========== TIJDRIT 2025-03-30 ==========
            RE("55555555-5555-5555-5555-555555555555", 1, "Matvii", 4, "11:45"),
            RE("55555555-5555-5555-5555-555555555555", 2, "Lies", 3, "9:12"),
            RE("55555555-5555-5555-5555-555555555555", 3, "Jesper", 3, "9:12"),
            RE("55555555-5555-5555-5555-555555555555", 4, "Lars", 3, "9:26"),
            RE("55555555-5555-5555-5555-555555555555", 5, "Tobias", 2, "6:19"),
            RE("55555555-5555-5555-5555-555555555555", 6, "Casper", 2, "6:23"),
            RE("55555555-5555-5555-5555-555555555555", 7, "Floris", 2, "6:28"),
            RE("55555555-5555-5555-5555-555555555555", 8, "Hilene", 1, "3:25"),
            RE("55555555-5555-5555-5555-555555555555", 9, "Amy", 1, "3:44"),
            RE("55555555-5555-5555-5555-555555555555", 10, "Doris", 1, "4:06"),

            // ========== TIJDRIT 2025-05-15 ==========
            RE("66666666-6666-6666-6666-666666666666", 1, "Matvii", 3, "8:12"),
            RE("66666666-6666-6666-6666-666666666666", 2, "Lies", 3, "8:18"),
            RE("66666666-6666-6666-6666-666666666666", 3, "Jurrian", 3, "8:45"),
            RE("66666666-6666-6666-6666-666666666666", 4, "Jesper", 3, "9:24"),
            RE("66666666-6666-6666-6666-666666666666", 5, "Lars", 3, "8:25"),
            RE("66666666-6666-6666-6666-666666666666", 6, "Floris", 2, "7:24"),
            RE("66666666-6666-6666-6666-666666666666", 7, "Gijs", 2, "8:25"),
            RE("66666666-6666-6666-6666-666666666666", 8, "Mirthe", 1, "3:55"),
            RE("66666666-6666-6666-6666-666666666666", 9, "Doris", 1, "3:37"),
            RE("66666666-6666-6666-6666-666666666666", 10, "Florian", 1, "3:56"),

            // ========== TIJDRIT 1: 31-03-2026 ==========
            // Alleen eindtijden beschikbaar (laatste passage)

            // 1 ronde
            R("11111111-1111-1111-1111-111111111111", 1, "Florian", 1, "0:00", "3:19"),
            R("11111111-1111-1111-1111-111111111111", 2, "Doris", 1, "0:30", "3:51"),
            R("11111111-1111-1111-1111-111111111111", 3, "Mirthe", 1, "1:00", "4:30"),
            R("11111111-1111-1111-1111-111111111111", 4, "Amy", 1, "1:30", "5:01"),

            // 2 rondes
            R("11111111-1111-1111-1111-111111111111", 5, "Tim", 2, "2:00", "9:47"),
            R("11111111-1111-1111-1111-111111111111", 6, "Thijmen", 2, "2:30", "9:51"),
            R("11111111-1111-1111-1111-111111111111", 7, "Hilene", 2, "3:00", "9:44"),
            R("11111111-1111-1111-1111-111111111111", 8, "Roos A", 2, "3:30", "10:19"),
            R("11111111-1111-1111-1111-111111111111", 9, "Jasmijn", 2, "4:00", "10:55"),

            // 3 rondes
            R("11111111-1111-1111-1111-111111111111", 10, "Gijs", 3, "4:30", "14:05"),
            R("11111111-1111-1111-1111-111111111111", 11, "Floris", 3, "5:00", "14:49"),
            R("11111111-1111-1111-1111-111111111111", 12, "Casper", 3, "5:30", "15:17"),
            R("11111111-1111-1111-1111-111111111111", 13, "Tobias", 3, "6:00", "14:43"),
            R("11111111-1111-1111-1111-111111111111", 14, "Lea", 3, "6:30", "16:34"),
            R("11111111-1111-1111-1111-111111111111", 15, "Lars", 3, "7:00", "15:59"),
            R("11111111-1111-1111-1111-111111111111", 16, "Suus", 3, "7:30", "17:10"),
            R("11111111-1111-1111-1111-111111111111", 17, "Neeltje", 3, "8:00", "18:07"),
            R("11111111-1111-1111-1111-111111111111", 18, "Jesper", 3, "8:30", "17:55"),
            R("11111111-1111-1111-1111-111111111111", 19, "Midas", 3, "9:00", "18:53"),

            // 2 rondes (proeftraining)
            R("11111111-1111-1111-1111-111111111111", 20, "Javet", 2, "9:30", "16:18"),

            // 4 rondes
            R("11111111-1111-1111-1111-111111111111", 21, "Lindsay", 4, "10:00", "21:22"),
            R("11111111-1111-1111-1111-111111111111", 22, "Jurrian", 4, "10:30", "20:50"),
            R("11111111-1111-1111-1111-111111111111", 23, "Lies", 4, "11:00", "22:04"),
            R("11111111-1111-1111-1111-111111111111", 24, "Jibbe", 4, "11:30", "22:30"),
            R("11111111-1111-1111-1111-111111111111", 25, "Siger", 4, "12:30", "21:52"),
            R("11111111-1111-1111-1111-111111111111", 26, "Nout", 4, "13:00", "23:45"),
            R("11111111-1111-1111-1111-111111111111", 27, "Lieke Hijlkema", 4, "13:30", "24:39"),
            R("11111111-1111-1111-1111-111111111111", 28, "Merijn de Haan", 4, "14:00", "23:25"),
            R("11111111-1111-1111-1111-111111111111", 29, "Sven van der Wal", 4, "14:30", "23:39"),

            // ========== TIJDRIT 2: 30-06-2026 (incl. 01-07 deel 2) ==========
            // Deze heeft deels tussenpassages

            // 1 ronde
            R("22222222-2222-2222-2222-222222222222", 1, "Thomas", 1, "0:00", "3:21"),

            // 2 rondes met passages
            R2("22222222-2222-2222-2222-222222222222", 2, "Dieke", 2, "0:30", "4:38", "8:48"),
            R2("22222222-2222-2222-2222-222222222222", 3, "Florian", 2, "1:00", "4:13", "7:30"),
            R2("22222222-2222-2222-2222-222222222222", 4, "Mirthe", 2, "1:30", "4:51", "8:14"),
            R("22222222-2222-2222-2222-222222222222", 5, "Hilene", 2, "2:00", "8:18"),
            R("22222222-2222-2222-2222-222222222222", 6, "Roos A", 2, "2:30", "8:42"),
            R("22222222-2222-2222-2222-222222222222", 7, "Jasmijn", 2, "3:00", "8:57"),
            R("22222222-2222-2222-2222-222222222222", 8, "Bente", 2, "3:30", "10:17"),

            // 3 rondes
            R3("22222222-2222-2222-2222-222222222222", 9, "Gijs", 3, "4:00", "10:13", "13:00"),
            R3("22222222-2222-2222-2222-222222222222", 10, "Lea", 3, "4:30", "11:11", "14:01"),
            R3("22222222-2222-2222-2222-222222222222", 11, "Midas", 3, "5:00", "11:11", "14:01"),
            R3Full("22222222-2222-2222-2222-222222222222", 12, "Lars", 3, "5:30", "8:34", "11:11", "13:50"),
            R3Full("22222222-2222-2222-2222-222222222222", 13, "Neeltje", 3, "6:00", "9:47", "12:50", "15:41"),
            R3Full("22222222-2222-2222-2222-222222222222", 14, "Daphne", 3, "6:30", "9:54", "12:50", "15:41"),
            R3("22222222-2222-2222-2222-222222222222", 15, "Jesper", 3, "7:00", "13:02", "15:45"),

            // 4 rondes (deel 2, starttijd +15 minuten offset voor continuiteit)
            R4("22222222-2222-2222-2222-222222222222", 16, "Jens", 4, "15:00", "17:52", "20:45", "23:47", "26:48"),
            R4("22222222-2222-2222-2222-222222222222", 17, "Lindsay", 4, "15:30", "18:14", "20:57", "23:41", "26:24"),
            R4("22222222-2222-2222-2222-222222222222", 18, "Javet", 4, "16:00", "18:55", "21:51", "25:00", "28:18"),
            R4("22222222-2222-2222-2222-222222222222", 19, "Jurrian", 4, "16:30", "19:00", "21:25", "23:52", "26:10"),
            R4("22222222-2222-2222-2222-222222222222", 20, "Matvii", 4, "17:00", "19:25", "21:52", "24:16", "26:42"),
            R4("22222222-2222-2222-2222-222222222222", 21, "Lies", 4, "17:30", "20:13", "23:00", "25:50", "28:39"),
            R4("22222222-2222-2222-2222-222222222222", 22, "Siger", 4, "18:00", "20:17", "22:32", "24:53", "27:18"),
            R4("22222222-2222-2222-2222-222222222222", 23, "Nout", 4, "18:30", "21:06", "23:43", "26:13", "28:38"),
            R4("22222222-2222-2222-2222-222222222222", 24, "Jibbe", 4, "19:00", "21:20", "23:40", "25:56", "28:03"),
            R4("22222222-2222-2222-2222-222222222222", 25, "Jaron", 4, "19:30", "21:39", "23:47", "25:55", "28:03"),
        };
    }

    // Helper methods voor leesbaarheid

        /// <summary>
        /// Resultaat met alleen eindtijd (geen tussenpassages).
        /// Passagetijden bevat alleen de eindtijd, ook al zijn er meerdere rondes.
        /// </summary>
        private static SeedResultaat RE(string tijdritId, int volg, string naam, int rondes, string eind)
        {
            return new SeedResultaat
            {
                TijdritId = Guid.Parse(tijdritId),
                Startvolgorde = volg,
                DeelnemerNaam = naam,
                AantalRondes = rondes,
                Starttijd = TimeSpan.Zero,
                Passagetijden = new List<TimeSpan> { ParseTijd(eind) }
            };
        }

        private static SeedResultaat R(string tijdritId, int volg, string naam, int rondes, string start, string eind)
    {
        var passages = new List<TimeSpan>();
        // Vul lege passages tot de eindtijd
        for (int i = 1; i < rondes; i++)
            passages.Add(TimeSpan.Zero);
        passages.Add(ParseTijd(eind));

        return new SeedResultaat
        {
            TijdritId = Guid.Parse(tijdritId),
            Startvolgorde = volg,
            DeelnemerNaam = naam,
            AantalRondes = rondes,
            Starttijd = ParseTijd(start),
            Passagetijden = passages
        };
    }

    private static SeedResultaat R2(string tijdritId, int volg, string naam, int rondes, string start, string p1, string p2)
    {
        return new SeedResultaat
        {
            TijdritId = Guid.Parse(tijdritId),
            Startvolgorde = volg,
            DeelnemerNaam = naam,
            AantalRondes = rondes,
            Starttijd = ParseTijd(start),
            Passagetijden = new List<TimeSpan> { ParseTijd(p1), ParseTijd(p2) }
        };
    }

    private static SeedResultaat R3(string tijdritId, int volg, string naam, int rondes, string start, string p2, string p3)
    {
        return new SeedResultaat
        {
            TijdritId = Guid.Parse(tijdritId),
            Startvolgorde = volg,
            DeelnemerNaam = naam,
            AantalRondes = rondes,
            Starttijd = ParseTijd(start),
            Passagetijden = new List<TimeSpan> { TimeSpan.Zero, ParseTijd(p2), ParseTijd(p3) }
        };
    }

    private static SeedResultaat R3Full(string tijdritId, int volg, string naam, int rondes, string start, string p1, string p2, string p3)
    {
        return new SeedResultaat
        {
            TijdritId = Guid.Parse(tijdritId),
            Startvolgorde = volg,
            DeelnemerNaam = naam,
            AantalRondes = rondes,
            Starttijd = ParseTijd(start),
            Passagetijden = new List<TimeSpan> { ParseTijd(p1), ParseTijd(p2), ParseTijd(p3) }
        };
    }

    private static SeedResultaat R4(string tijdritId, int volg, string naam, int rondes, string start, string p1, string p2, string p3, string p4)
    {
        return new SeedResultaat
        {
            TijdritId = Guid.Parse(tijdritId),
            Startvolgorde = volg,
            DeelnemerNaam = naam,
            AantalRondes = rondes,
            Starttijd = ParseTijd(start),
            Passagetijden = new List<TimeSpan> { ParseTijd(p1), ParseTijd(p2), ParseTijd(p3), ParseTijd(p4) }
        };
    }

    private static TimeSpan ParseTijd(string tijd)
    {
        if (string.IsNullOrEmpty(tijd)) return TimeSpan.Zero;
        var parts = tijd.Split(':');
        return new TimeSpan(0, int.Parse(parts[0]), int.Parse(parts[1]));
    }
}

/// <summary>
/// Tijdelijke structuur voor seed resultaten met naam i.p.v. Guid.
/// </summary>
public class SeedResultaat
{
    public Guid TijdritId { get; set; }
    public int Startvolgorde { get; set; }
    public string DeelnemerNaam { get; set; } = "";
    public int AantalRondes { get; set; }
    public TimeSpan Starttijd { get; set; }
    public List<TimeSpan> Passagetijden { get; set; } = new();
}
