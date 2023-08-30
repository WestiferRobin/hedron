using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Prism
{
    public class PrismBodyBuilder
    {
        public static Dictionary<BodyPart, int> CreateDefaultBody()
        {
            return new Dictionary<BodyPart, int>
            {
                { BodyPart.Head, 3 },
                { BodyPart.Torso, 5 },
                { BodyPart.Arms, 2 },
                { BodyPart.Legs, 2 }
            };
        }
    }
}
