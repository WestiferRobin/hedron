using System;

public enum WeaponID
{
    Unknown = -1,

    // Pistols => Default
    Pistol = 0,
    SingleBladeSword = 1,
    DoubleBladeSword = 2,

    // SMGs => Specialist
    Frenzy = 3,
    Stinger = 4,
    Specter = 5,

    // Shotguns => Ranger
    Shorty = 6,
    Bucky = 7,
    Judge = 8,

    // Rifles => Soldier
    Guardian = 9,
    Phantom = 10,
    Vandal = 11,

    // Sniper Rifles => Stealth = Officer
    Ghost = 12,
    Marshal = 13,
    Operator = 14,

    // Machine Guns => Heavy = Commando
    Sheriff = 15,
    Ares = 16,
    Odin = 17
}

public class Weapon
{
	public Weapon()
	{
	}
}

