using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gunship
{
    [Serializable]
    public class EnemyDescription
    {
        public GameObject Prefab;
        public float Health;
        public float Damage;
        public float Speed;
    }
}