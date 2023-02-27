using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gunship
{
    public abstract class Bonus : MonoBehaviour
    {
        public abstract void Update();
        public abstract void OnTriggerEnter2D(Collider2D collision);
    }
}