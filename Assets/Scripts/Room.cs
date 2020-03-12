using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArrPG
{
    public class Room : MonoBehaviour
    {
        public Chest Chest { get; set; }
        public Enemy Enemy { get; set; }
        public bool Exit { get; set; }
        public bool Empty { get; set; }
        public Vector2 RoomIndex { get; set; }

        public Room(Chest chest, Enemy enemy, bool empty, bool exit)
        {
            this.Chest = chest;
            this.Enemy = enemy;
            this.Empty = empty;
            this.Exis = exit;
        }

        public Room()
        {
            int roll = Random.Range(0,30);
            if (roll > 0 && < 6)
            {
                Enemy = EnemyDatabase.Instance.GetRandomEnemy();
                Enemy.RoomIndex = RoomIndex;
            }
            else if ( roll > 15 && roll < 20)
            {
                Chest = new Chest();
            }
            else
            {
                Empty = true;
            }
        }
    }
}