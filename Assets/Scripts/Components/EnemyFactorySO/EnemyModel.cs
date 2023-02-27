using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

namespace Gunship
{
    public class EnemyModel
    {
        private EnemyDescription _description;
        //[SerializeField] private Enemy _enemy;
        //[SerializeField] private PlayerController _player;
        public float _health, _damage, _speed;
        public EnemyDescription Description => _description;
        //public Enemy Enemy => _enemy;
        //public PlayerController Controller => _player;

        public EnemyModel(EnemyDescription description)
        {
            _description = description;
            _health = _description.Health;
            _damage = _description.Damage;
            _speed = _description.Speed;
        }
        //public void Move()
        //{
        //    _enemy.transform.position = Vector2.MoveTowards(Enemy.transform.position,
        //                                             Controller.transform.position,
        //                                             _speed * Time.deltaTime);
        //}

    }
}