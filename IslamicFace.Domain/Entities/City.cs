namespace IslamicFace.Domain.Entities;

public class City
{
    public int Id { get; set; }
    public required string Name_ENG { get; set; } // for city name in English
    public required string Name_ARB { get; set; } // for city name in Arabic

    public short CountryId { get; set; }

    public Country? Country { get; set; }
}

