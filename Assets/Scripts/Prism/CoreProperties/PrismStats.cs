using System;

public class PrismStats
{
    /*
    RANGE IS 1-10
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

    public PrismStats(BattleClass combatClass)
    {
        if (combatClass == BattleClass.Unknown)
        {
            throw new ArgumentException("Not a valid Combat Class to create PrismStats");
        }
        // TODO: Create factory for combatClass
    }
}