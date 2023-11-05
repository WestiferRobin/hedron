using System;

public enum BattleClassID
{
    Unknown = -1,

    Soldier = 0,    // TODO: Make this to work as Marine
    Specialist = 1,
    Ranger = 2,
    Officer = 3,
    Commando = 4,
    Guardian = 5
}

public enum BattleRank
{
    Unknown = -1,
    Private = 0,
    Corporal = 1, // Freighter
    Lance = 2, // Corvette
    Sergeant = 3, // Outpost : 1 Corvette and 2 Freighters
    Lieutenant = 4, // Frigate
    Commander = 5, // Colony : 1 Frigate and 2 Corvettes
    Captain = 6, // Capital
    Colonel = 7, // Town : 1 Captial and 2 Frigates
    Major = 8, // City : 3 Captial
    Arch = 9 // Dreadnought : Citadel
}


public class BattleClass
{
    public BattleClassID Id { get; set; }
    public BattleRank Rank { get; set; }
    public Armor BattleArmor { get; set; }
    public Weapon PrimaryWeapon { get; set; }
    public Weapon SecondaryWeapon { get; set; }
    public Item FirstItem { get; set; }
    public Item SecondItem { get; set; }

    public BattleClass(BattleClassID classId, BattleRank rank, PrismBody body)
    {
        this.Id = classId;
        this.Rank = rank;
        this.BattleArmor = new Armor(body);
        ConfigInventory();
    }

    private void ConfigInventory()
    {
        switch (this.Id)
        {
            case BattleClassID.Soldier:
                this.PrimaryWeapon = new Guardian();
                this.SecondaryWeapon = new Classic();
                this.FirstItem = new MedPack();
                this.SecondItem = new FragGrenade();
                break;
            case BattleClassID.Specialist:
                this.PrimaryWeapon = new Stinger();
                this.SecondaryWeapon = new Frenzy();
                this.FirstItem = new RepairPack();
                this.SecondItem = new ShockGrenade();
                break;
            case BattleClassID.Ranger:
                this.PrimaryWeapon = new Shotty();
                this.SecondaryWeapon = new Sword();
                this.FirstItem = new StimPack();
                this.SecondItem = new SmokeGrenade();
                break;
            case BattleClassID.Officer:
                this.PrimaryWeapon = new Marshal();
                this.SecondaryWeapon = new Ghost();
                this.FirstItem = new StealthPack();
                this.SecondItem = new PoisinGrenade();
                break;
            case BattleClassID.Commando:
                this.PrimaryWeapon = new Bulldog();
                this.SecondaryWeapon = new Sheriff();
                this.FirstItem = new DamagePack();
                this.SecondItem = new FlameGrenade();
                break;
            case BattleClassID.Guardian:
                this.PrimaryWeapon = new PrimaryPower();
                this.SecondaryWeapon = new SecondaryPower();
                this.FirstItem = new ItemPower();
                this.SecondItem = new GrenadePower();
                break;
            default:
                throw new Exception("Rank isn't defined");
        }
    }
}
