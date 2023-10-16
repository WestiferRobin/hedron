using System;
using System.Collections.Generic;

public static class NameFactory
{
    public static List<string> GetFirstNames(PrismGender gender, PrismRace race)
    {
        if (gender == PrismGender.Unknown)
        {
            throw new ArgumentException($"Gender is not valid for getting getting FirstNames");
        }
        return race switch
        {
            PrismRace.Terrian => gender == PrismGender.Male ? TerrianNames.MaleNames : TerrianNames.FemaleNames,
            PrismRace.Zetan => gender == PrismGender.Male ? ZetanNames.MaleNames : ZetanNames.FemaleNames,
            _ => throw new ArgumentException($"Race is not valid for getting getting FirstNames"),
        };
    }

    public static List<string> GetLastNames(PrismRace race)
    {
        return race switch
        {
            PrismRace.Terrian => TerrianNames.LastNames,
            PrismRace.Zetan => ZetanNames.LastNames,
            _ => throw new ArgumentException($"Race is not valid for getting getting LastNames"),
        };
    }

    public static string RandomFirstName(PrismGender gender, PrismRace race)
    {
        var firstNames = GetFirstNames(gender, race);
        int randomIndex = new Random().Next(firstNames.Count);
        return firstNames[randomIndex];
    }

    public static string RandomLastName(PrismRace race)
    {
        var lastNames = GetLastNames(race);
        int randomIndex = new Random().Next(lastNames.Count);
        return lastNames[randomIndex];
    }
}

