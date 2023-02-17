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
            enemyGoal = GameObject.Find("Goal(Clone)");
        }

        void UpdateEnemyGoalHealth()
        {
            if (enemyGoal != null)
            {
                livesText.enabled = true;
                livesText.text = "ENEMY: " +
                    enemyGoal.GetComponent<GoalManager>().goalHealth.ToString();
            } else
            {
                livesText.enabled = false;
            }
        }
    }
}
