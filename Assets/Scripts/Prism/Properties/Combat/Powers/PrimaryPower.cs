using System;
public class PrimaryPower : Weapon
{
	public Power GuardianPower { get; set; }

	public PrimaryPower()
	{
		this.GuardianPower = new Power();
	}
}

