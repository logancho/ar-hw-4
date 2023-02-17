using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

namespace MyFirstARGame
{
    public class EnemyHealthUI : MonoBehaviour
    {
        GameObject enemyGoal = null;
        Text livesText;

        void Start()
        {
            livesText = gameObject.GetComponent<Text>();
        }

        // Update is called once per frame
        void Update()
        {
            FindEnemyGoal();
            UpdateEnemyGoalHealth();
        }

        void FindEnemyGoal()
        {
            if (enemyGoal == null)
            {
                if (PhotonNetwork.LocalPlayer.ActorNumber == 2)
                {
                    //Enemy must be 3
                    enemyGoal = GameObject.Find("Player_2 Goal");
                }
                else
                {
                    //Enemy must be 2
                    enemyGoal = GameObject.Find("Player_1 Goal");
                }
            }
        }

        void UpdateEnemyGoalHealth()
        {
            if (enemyGoal != null)
            {
                livesText.text = "ENEMY: " +
                    enemyGoal.GetComponent<GoalManager>().goalHealth.ToString();
            } else
            {
                livesText.enabled = false;
            }
        }
    }
}
