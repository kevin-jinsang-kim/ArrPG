using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



namespace ArrPG
{
    public class Encounter : MonoBehaviour
    {
        public Enemy Enemy { get; set; }
        [SerializeField]
        Player player;

        [SerializeField]
        Button[] dynamicControls;
        

        public void ResetDynamicControls()
        {
            foreach(Button button in dynamicControls)
            {
                button.interactable = false;
            }
        }

        public void StartCombat()
        {
            this.Enemy = player.Room.Enemy;
            dynamicControls[0].interactable = true;
            dynamicControls[1].interactable = true;
        }

        public void StartChest()
        {
            dynamicControls[3].interactable = true;
        }

        public void StartExit()
        {
            dynamicControls[2].interactable = true;
        }

        public void Attack()
        {
            int playerDamageAmount = (int)(Random.value * (player.Attack - Enemy.Defence));
            int enemyDamageAmount = (int)(Random.value * (Enemy.Attack - player.Defence));
            Journal.Instance.Log("<color=#59ffa1>You attacked, dealing <b>" + playerDamageAmount + "</b> damage!</color>");
            Journal.Instance.Log("<color=#59ffa1>The enemy retaliated, dealing <b>" + enemyDamageAmount + "</b> damage!</color>");
            player.TakeDamage(enemyDamageAmount);
            Enemy.TakeDamage(playerDamageAmount);
        }

        public void Flee()
        {
            int enemyDamageAmount = (int)(Random.value * (Enemy.Attack - (player.Defence * 0.5)));
            player.Room.Enemy = null;
            player.TakeDamage(enemyDamageAmount);
            Journal.Instance.Log("<color=#59ffa1>You fled the fight, taking <b>" + enemyDamageAmount + "</b> damage!</color>");
            player.Investigate();
        }
    }
}