using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gunship
{
    public class HealthBonus : Bonus
    {
        [SerializeField] private float HealingPower = 1f;

        public override void Update()
        {
            Destroy(gameObject, 5f);
        }

        public override void OnTriggerEnter2D(Collider2D collision)
        {
            Player player = collision.GetComponent<Player>();
            player.GotHealing(HealingPower);
            Destroy(gameObject);
        }
    }
}