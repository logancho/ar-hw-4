using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

namespace MyFirstARGame
{
    public class ResetButtonUI : MonoBehaviour
    {
        public bool otherPlayerReset = false;
        GameObject enemyGoal = null;
        GameObject timer;

        void FindEnemyGoal()
        {
            enemyGoal = GameObject.Find("Goal(Clone)");
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
                otherPlayerReset = enemyGoal.GetComponent<GoalManager>().reset;
                if (otherPlayerReset)
                {
                    Restart();
                    enemyGoal.GetComponent<GoalManager>().reset = false;
                }
            }
        }

        public void Restart()
        {
            GameObject[] allObjects = GameObject.FindGameObjectsWithTag("Ball");
            foreach (GameObject obj in allObjects)
            {
                PhotonNetwork.Destroy(obj);
            }

            GameObject[] allGoals = GameObject.FindGameObjectsWithTag("Goal");
            foreach (GameObject goal in allGoals)
            {
                goal.GetComponent<GoalManager>().pause = false;

                goal.GetComponent<GoalManager>().goalHealth = 5;

                if (goal.name != "Goal(Clone)")
                {
                    goal.GetComponent<GoalManager>().reset = true;
                }
            }

            GameObject[] allUI = GameObject.FindGameObjectsWithTag("UI");
            foreach (GameObject ui in allUI)
            {
                ui.SetActive(false);
            }

            timer.GetComponent<TimerUI>().time = 0;
        }
    }
}
