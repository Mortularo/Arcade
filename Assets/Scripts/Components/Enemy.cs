using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gunship
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float _health = 100f, _damage = 1f, _speed = 3f;
        [SerializeField] private GameObject _deathEffect, _healthBonus, _speedBonus;
        private Transform _targetPosition;
        [SerializeField] private EnemyModel _model;
        private ScoreManager _sm;
        private Animator CamAnimator;

        #region Methods
        public void TakeDamage (float damage)
        {
            _health -= damage;
            if(_health <= 0)
            {
                _sm.ScoreUp();
                Die();
            }
        }
        private void Die()
        {
            CamAnimator.SetTrigger("Explosion");
            GameObject effect = Instantiate(_deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(effect, 2f);
            int x = Random.Range(0, 7);
            if (x > 5)
            {
                int y = Random.Range(0, 2);
                if (y == 0)
                {
                    Instantiate(_healthBonus, transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(_speedBonus, transform.position, Quaternion.identity);
                }
            }
        }
        #endregion
        #region Trigger
        private void OnTriggerEnter2D(Collider2D hitInfo)
        {
            Player player = hitInfo.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamage(_damage);
            }
        }
        #endregion
        private void Start()
        {
            _targetPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            CamAnimator = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
            _sm = FindObjectOfType<ScoreManager>();
        }
        private void Update()
        {
            transform.position = Vector2.MoveTowards(transform.position,
                                                     _targetPosition.transform.position,
                                                     _speed * Time.deltaTime);
        }
    }
}