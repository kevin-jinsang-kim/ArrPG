using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArrPG
{
    public class Raccoon : Enemy
    {
        void Start()
        {
            Energy = 10;
            Attack = 5;
            Defence = 3;
            Gold = 20;
            Description = "A rabid racoon";
            Inventory.Add("Mouldy Eyepatch");
        }
    }
}