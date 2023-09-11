using System;

public class PrismGenderFactory
{
    public static PrismGender RandomGender()
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