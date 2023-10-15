using System;

public class ItemPower : Item
{
    public Power GuardianPower { get; set; }

    public ItemPower(Power power)
    {
        this.GuardianPower = power;
    }

    public ItemPower()
    {
        this.GuardianPower = new Power();
    }
}

