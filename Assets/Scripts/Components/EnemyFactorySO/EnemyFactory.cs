using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gunship
{
    public class EnemyFactory
    {
        private Dictionary<string, Func<int, EnemyModel>> EnemyCreation;
        public void Init(EnemyDescriptions descriptions)
        {
            EnemyCreation = new Dictionary<string, Func<int, EnemyModel>>()
            {
                {"Enemy", (level) => new EnemyModel(descriptions.ListEnemies[level])}
            };
        }
        public EnemyModel CreateEnemy(string nameEnemy, int level)
        {
            return EnemyCreation[nameEnemy](level);
        }
    }
}