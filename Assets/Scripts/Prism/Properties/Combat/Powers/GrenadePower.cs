using System;

public class GrenadePower : Grenade
{
	public Power GuardianPower { get; set; }

	public GrenadePower(Power power)
	{
		this.GuardianPower = power;
	}

	public GrenadePower()
	{
		this.GuardianPower = new Power();
	}
}

