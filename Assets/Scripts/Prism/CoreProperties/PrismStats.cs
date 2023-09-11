public class PrismStats
{
    /*
    Strength: Melee Damage
    Dexterity: Shooting Damage
    Constitution: Health capacity
    Wisdom: Magic capacity
    Intelligence: Logic
    Charisma: Speech
    Agility: Movement
     */
    public int Strength { get; private set; }
    public int Dexterity { get; private set; }
    public int Constitution { get; private set; }
    public int Wisdom { get; private set; }
    public int Intelligence { get; private set; }
    public int Charisma { get; private set; }
    public int Agility { get; private set; }

    public PrismStats(CombatClass combatClass)
    {
        // TODO: Create factory for combatClass
    }
}