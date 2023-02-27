using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gunship
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _playerHealth = 10;
        [SerializeField] private GameObject deathEffect, endGamePanel, winGamePanel;
        [SerializeField] private int stripesNumber;
        [SerializeField] private Image[] stripes;
        [SerializeField] private Sprite Wound, LostWound;
        [SerializeField] private AudioSource _hitSound;
        public ScoreManager _sm;
        private float speed;

        #region Methods        
        //public void WinGame()
        //{
        //    if (_sm._score >= 10)
        //    {
        //        Time.timeScale = 0f;
        //        winGamePanel.SetActive(true);
        //    }
        //}
        
        public void TakeDamage(float damage)
        {
            _playerHealth -= damage;
            _hitSound.Play();
            if (_playerHealth <= 0)
            {
                Die();
                endGamePanel.SetActive(true);
            }
        }
        private void Die()
        {
            GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            GameObject.FindGameObjectWithTag("Player").SetActive(false);
            Destroy(effect, 1f);

        }
        public void GotHealing(float healing)
        {
            _playerHealth += healing;
        }
        #endregion
        private void Start()
        {
            PlayerController controlller = GetComponent<PlayerController>();
            controlller.SpeedBoost(speed);
        }
        private void FixedUpdate()
        {
            if (_playerHealth > stripesNumber)
            {
                _playerHealth = stripesNumber;
            }
            for (int i = 0; i < stripes.Length; i++)
            {
                if (i < Mathf.RoundToInt(_playerHealth))
                {
                    stripes[i].sprite = Wound;
                }
                else
                {
                    stripes[i].sprite = LostWound;
                }
                if (i < stripesNumber)
                {
                    stripes[i].enabled = true;
                }
                else
                {
                    stripes[i].enabled = false;
                }
            }
            if (_sm._score >= 10)
            {
                Time.timeScale = 0f;
                winGamePanel.SetActive(true);
            }
        }
    }
}