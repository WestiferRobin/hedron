using System;
public class SecondaryPower : Weapon
{
    public Power GuardianPower { get; set; }

    public SecondaryPower()
    {
        this.GuardianPower = new Power();
    }
}

