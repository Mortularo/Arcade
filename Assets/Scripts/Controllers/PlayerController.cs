using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace Gunship
{
    public class PlayerController : MonoBehaviour, IShoot
    {
        [SerializeField] private GameObject player, bullet;
        [SerializeField] private Camera _cam;
        [SerializeField] private Transform _barrel;
        [SerializeField] private float _moveSpeed = 7f, shotForce = 20f;
        [SerializeField] private AudioSource _shotSound;
        private Vector2 _direction, _mousePosition;
        private Rigidbody2D _rb;

        void Start()
        {
            player.TryGetComponent<Rigidbody2D>(out _rb);
        }

        void Update()
        {
            _direction.x = Input.GetAxisRaw("Horizontal");
            _direction.y = Input.GetAxisRaw("Vertical");
            _mousePosition = _cam.ScreenToWorldPoint(Input.mousePosition);
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
        void FixedUpdate()
        {
            _rb.MovePosition(_rb.position + _direction * _moveSpeed * Time.fixedDeltaTime);
            Vector2 lookDir = _mousePosition - _rb.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            _rb.rotation = angle;
        }
        #region Methods
        private void Shoot()
        {
            if (!PauseMenu.IsPaused)
            {
                GameObject newBullet = PoolManager.GetObject("RegularShot", _barrel.position, _barrel.rotation);
                _shotSound.Play();
                Rigidbody2D bulletRB = newBullet.GetComponent<Rigidbody2D>();
                bulletRB.AddForce(_barrel.up * shotForce, ForceMode2D.Impulse);
            }
        }
        public void SpeedBoost(float speed)
        {
            _moveSpeed += speed;
        }
        #endregion
    }
}