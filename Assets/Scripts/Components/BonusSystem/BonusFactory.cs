using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gunship
{
    public abstract class BonusFactory : MonoBehaviour
    {
        public abstract Bonus CreateBonus();
    }
}