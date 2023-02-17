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
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
