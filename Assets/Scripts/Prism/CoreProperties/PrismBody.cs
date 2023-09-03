using System.Collections.Generic;

public enum BodyPart
{
    Unknown = 0,
    Head = 1,
    Torso = 2,
    Arms = 3,
    Legs = 4,
}

public class PrismBody
{

    public Dictionary<BodyPart, int> BodyParts { get; internal set; }

    public PrismBody()
    {
        this.BodyParts = PrismBodyFactory.GeneratePrismBody();
    }

    public bool IsDamaged()
    {
        var defaultParts = PrismBodyFactory.GeneratePrismBody();
        var defaultHealthScore = PrismScoreHelper.CalculateHealthScore(defaultParts);
        var ourHealthScore = PrismScoreHelper.CalculateHealthScore(this.BodyParts);
        if (defaultHealthScore <= 0)
        {
            return true;
        }
        int ratioScore = ourHealthScore / defaultHealthScore;
        return ratioScore <= 0.5;

    }

    public bool IsAlive()
    {
        if (BodyParts.Count <= 0)
            return false;
        if (!BodyParts.ContainsKey(BodyPart.Head))
            return false;
        if (!BodyParts.ContainsKey(BodyPart.Torso))
            return false;
        return true;
    }

    public void Rest()
    {
        this.BodyParts = PrismBodyFactory.GeneratePrismBody();
    }
}