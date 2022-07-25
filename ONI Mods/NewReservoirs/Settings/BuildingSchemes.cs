using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewReservoirs.Settings
{
    public class BuildingSchemes
    {
        public class Decor
        {
            public class BONUS
            {
                public static readonly EffectorValues AdvLiqResDECORBonus = new EffectorValues()
                {
                    amount = 0,
                    radius = 1
                };
            }

            public class PENALTY
            {
                public static readonly EffectorValues AdvLiqResDECORPenalty = new EffectorValues()
                {
                    amount = 0,
                    radius = 1
                };
            }
        }
        public class NOISY
        {
            public static readonly EffectorValues TIER0 = new EffectorValues()
            {
                amount = 45,
                radius = 10
            };
            public static readonly EffectorValues TIER1 = new EffectorValues()
            {
                amount = 55,
                radius = 10
            };
            public static readonly EffectorValues TIER2 = new EffectorValues()
            {
                amount = 65,
                radius = 10
            };
            public static readonly EffectorValues TIER3 = new EffectorValues()
            {
                amount = 75,
                radius = 15
            };
            public static readonly EffectorValues TIER4 = new EffectorValues()
            {
                amount = 90,
                radius = 15
            };
            public static readonly EffectorValues TIER5 = new EffectorValues()
            {
                amount = 105,
                radius = 20
            };
            public static readonly EffectorValues TIER6 = new EffectorValues()
            {
                amount = 125,
                radius = 20
            };
        }
    }
}
