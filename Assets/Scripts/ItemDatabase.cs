using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArrPG
{
    public class ItemDatabase : MonoBehaviour
    {
        public List<string> Items { get; set; } = new List<string>();
        public static ItemDatabase Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
                Destroy(this.gameObject);
            else
                Instance = this;
            
            Items.Add("Peg Leg");
            Items.Add("Pirate Flag");
            Items.Add("Talkative Parrot");
        }
    }
}