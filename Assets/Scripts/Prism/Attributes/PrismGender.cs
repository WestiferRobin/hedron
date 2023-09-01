using System;


public enum PrismGender
{
    Unknown = 0,
    Male = 1,
    Female = 2
}

public class PrismGenderHelper
{
    public static PrismGender RandomPrismGender()
    {
        var array = Enum.GetValues(typeof(PrismGender));
        int randomIndex = new Random().Next(0, array.Length);
        var selectedGender = (PrismGender)randomIndex;
        while (selectedGender == PrismGender.Unknown)
        {
            randomIndex = new Random().Next(0, array.Length);
            selectedGender = (PrismGender)randomIndex;
        }
        return selectedGender;
    }
}
