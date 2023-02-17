using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyFirstARGame
{
    public class ResetButtonUI : MonoBehaviour
    {
        public bool otherPlayerReset = false;
        GameObject enemyGoal = null;

        void FindEnemyGoal()
        {
            //if (enemyGoal == null)
            //{
                enemyGoal = GameObject.Find("Goal(Clone)");
            //}
        }

        //// Update is called once per frame
        void Update()
        {
            FindEnemyGoal();
            CheckOtherPlayerReset();
            if (otherPlayerReset)
            {
                Restart();
            }
        }

        void CheckOtherPlayerReset()
        {
            if (enemyGoal != null)
            {
                //otherPlayerReset = enemyGoal.reset;
                otherPlayerReset = enemyGoal.GetComponent<GoalManager>().reset;
            }
        }

        public void Restart()
        {
            if (enemyGoal != null)
            {
                enemyGoal.GetComponent<GoalManager>().reset = true;
            }

            GameObject[] allObjects = GameObject.FindGameObjectsWithTag("Ball");
            foreach (GameObject obj in allObjects)
            {
                Destroy(obj);
            }

            GameObject[] allGoals = GameObject.FindGameObjectsWithTag("Goal");
            foreach (GameObject goal in allGoals)
            {
                goal.GetComponent<GoalManager>().pause = false;
                goal.GetComponent<GoalManager>().goalHealth = 5;
            }

            //
            GameObject[] allUI = GameObject.FindGameObjectsWithTag("UI");
            foreach (GameObject ui in allUI)
            {
                ui.SetActive(false);
            }



        }
    }
}
