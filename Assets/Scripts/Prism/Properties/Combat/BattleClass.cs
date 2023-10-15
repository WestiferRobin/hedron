using System;

public enum BattleClassID
{
    Unknown = -1,

    Soldier = 0,
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
    Corporal = 1,
    Lance = 2,
    Sergeant = 3,
    Lieutenant = 4,
    Commander = 5,
    Captain = 6,
    Colonel = 7,
    Major = 8,
    Arch = 9
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
