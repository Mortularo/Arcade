using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gunship
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private GameObject _hitEffect;
        [SerializeField] private float _damage = 5f;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            GameObject effect = Instantiate(_hitEffect, transform.position, Quaternion.identity);
            GetComponent<PoolObject>().ReturnToPool();
            Destroy(effect, 1);

        }

        private void OnTriggerEnter2D(Collider2D hitInfo)
        {
            Enemy enemy = hitInfo.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(_damage);
            }
        }
        #region Methods

        #endregion
    }
}