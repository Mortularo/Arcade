using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gunship
{
    [CreateAssetMenu(fileName = "EnemyDescriptions", menuName = "EnemyDescriptions", order = 51)]
    public class EnemyDescriptions : ScriptableObject
    {
        [SerializeField] private List<EnemyDescription> _listEnemies;
        public List<EnemyDescription> ListEnemies => _listEnemies;
    }
}