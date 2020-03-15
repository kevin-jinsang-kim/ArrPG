using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArrPG
{
    public class Enemy : Character
    {   
        public string Description { get; set; }
        public override void TakeDamage(int amount)
        {
            base.TakeDamage(amount);
            Debug.Log("This also happens, but only on enemy! Not other characters.");
        }

        public override void Die()
        {
            Debug.Log("Character died, was enemy");
        }
    }
}