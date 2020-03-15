using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArrPG
{
public class Player : Character
{
    public int Floor { get; set; }
    public Room Room { get; set; }

    [SerializeField]
    Encounter encounter;

    [SerializeField] 
    World world;

    void Start()
    {
        Floor = 0;
        Energy = 30;
        Attack = 10;
        Defence = 5;
        Gold = 0;
        Inventory = new List<string>();
        RoomIndex = new Vector2(2,2);
        this.Room = world.Dungeon[(int)RoomIndex.x, (int)RoomIndex.y];
        this.Room.Empty = true;
        AddItem("Lots o dough");
    }

    public void Move(int direction)
    {
        if (direction == 0 && RoomIndex.y > 0)
        {
            Journal.Instance.Log("You move North");
            RoomIndex -= Vector2.up;
        }
        if (direction == 1 && RoomIndex.x < world.Dungeon.GetLength(0)-1)
        {
            Journal.Instance.Log("You move East");
            RoomIndex += Vector2.right;
        }
        if (direction == 2 && RoomIndex.y < world.Dungeon.GetLength(1)-1)
        {
            Journal.Instance.Log("You move South");
            RoomIndex -= Vector2.down;
        }
        if (direction == 3 && RoomIndex.x > 0)
        {            
            Journal.Instance.Log("You move West");
            RoomIndex += Vector2.left;
        }
        if (this.Room.RoomIndex != RoomIndex)                        
            Investigate();
    }

    public void Investigate()
    {
        this.Room = world.Dungeon[(int)RoomIndex.x, (int)RoomIndex.y];
        encounter.ResetDynamicControls();
        if (this.Room.Empty)
        {
            Journal.Instance.Log("You find yourself in an empty room.");
        }
        else if (this.Room.Chest != null)
        {
            Journal.Instance.Log("You found a chest! What do you want to do?");
        }
        else if (this.Room.Enemy != null)
        {
            Journal.Instance.Log("You are jumped by " + Room.Enemy.Description + "! What do you do?");
            encounter.StartCombat();
        }
        else if (this.Room.Exit)
        {
            Journal.Instance.Log("You've found the exit to the next dungeon. Do you continue?");
        }
    }

    public void AddItem(string item)
    {
        Journal.Instance.Log("You were given item: " + item);
        Inventory.Add(item);
    }

    public override void TakeDamage(int amount)
    {
        Debug.Log("Player TakeDamage");
        base.TakeDamage(amount);
    }

    public override void Die()
    {
        Debug.Log("Player Died. Game Over.");
    }
}
}