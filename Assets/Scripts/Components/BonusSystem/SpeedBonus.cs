using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gunship
{
    public class SpeedBonus : Bonus
    {
        [SerializeField] private float SpeedBoost = 1f;

        public override void Update()
        {
            Destroy(gameObject, 5f);
        }

        public override void OnTriggerEnter2D(Collider2D collision)
        {
            GameObject main = GameObject.FindGameObjectWithTag("Main");
            main.GetComponent<PlayerController>().SpeedBoost(SpeedBoost);
            Destroy(gameObject);
        }
    }
}