using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gunship {
    public class HealthFactory : BonusFactory
    {
        public override Bonus CreateBonus()
        {
            return new HealthBonus();
        }
    }
}