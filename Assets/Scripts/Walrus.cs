using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArrPG
{
    public class Walrus : Enemy
    {
        void Start()
        {
            Energy = 15;
            Attack = 3;
            Defence = 5;
            Gold = 30;
            Description = "Severely manic walrus";
            Inventory.Add("Decaying Tusk");
        }
    }
}