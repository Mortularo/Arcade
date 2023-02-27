using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gunship
{
    public class SpeedFactory : BonusFactory
    {
        public override Bonus CreateBonus()
        {
            return new SpeedBonus();
        }
    }
}