using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PrismBodyFactory
{
    public static Dictionary<BodyPart, int> GeneratePrismBody(PrismRace race)
    {
        // NOTE: Although Zetas and Terrians work for this configuration,
        //      We need to consider other races. If the same then remove Factory.
        return new Dictionary<BodyPart, int>
        {
            { BodyPart.Head, 3 },
            { BodyPart.Torso, 5 },
            { BodyPart.Arms, 2 },
            { BodyPart.Legs, 2 }
        };
    }
}
