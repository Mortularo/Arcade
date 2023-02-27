using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;

namespace Gunship
{
    public class SpawnController : MonoBehaviour
    {
        [SerializeField] private GameObject _enemy;
        //[SerializeField] private EnemyDescriptions _enemyDescriptions;
        List<Transform> points = new List<Transform>();
        private GameObject curentEnemy;
        //private EnemyFactory _factory;
        void Start()
        {
            Transform pointsObject = GameObject.FindGameObjectWithTag("Spawnpoints").transform;
            foreach (Transform t in pointsObject)
            {
                points.Add(t);
            }
            //_factory = new EnemyFactory();
            //_factory.Init(_enemyDescriptions);
            //_factory.CreateEnemy("Enemy", 1);
            Instantiate(_enemy, points[Random.Range(0, points.Count)].position, Quaternion.identity);
        }
        private void Update()
        {
            curentEnemy = GameObject.FindGameObjectWithTag("Enemy");
            if (curentEnemy != null)
            {
                return;
            }
            else
            {
                Instantiate(_enemy, points[Random.Range(0, points.Count)].position, Quaternion.identity);
            }
        }
    }
}