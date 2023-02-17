using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

namespace MyFirstARGame
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject networkLauncher;
        private bool spawnedGoal = false;
        //private bool enemyGoalFound = false;
        public GameObject goalPrefab;
        public GameObject goal { get; private set; }
        public GameObject enemyGoal = null;
        public bool lose = false;

        [SerializeField]
        private GameObject winUI;
        [SerializeField]
        private GameObject loseUI;
        [SerializeField]
        private GameObject resetButtonUI;

        void Update()
        {
            SpawnGoal();
            //FindEnemyGoal();
            //CheckLoss();
            EndGame();
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

        void SpawnGoal()
        {
            if (!spawnedGoal)
            {
                if (networkLauncher.GetComponent<NetworkLauncher>().HasJoinedRoom)
                {
                    SpawnGoalHelp();
                    spawnedGoal = true;
                }
            }
        }

        void SpawnGoalHelp()
        {
            Vector3 pos = new Vector3(1.0f, 0, 0);

            if (PhotonNetwork.LocalPlayer.ActorNumber == 2)
            {
                pos *= -1;
            }
            var initialData = new object[] { PhotonNetwork.LocalPlayer.ActorNumber };

            this.goal = PhotonNetwork.Instantiate(this.goalPrefab.name, pos, Quaternion.identity, data: initialData);
            this.goal.name = "Player_" + (PhotonNetwork.LocalPlayer.ActorNumber - 1).ToString() + " Goal";
        }

        void EndGame()
        {
            ////If both goals exist
            //if (spawnedGoal && enemyGoal != null)
            //{
            //    if (enemyGoal.GetComponent<GoalManager>().goalHealth == 0)
            //    {
            //        SetGoalPause();
            //        enemyGoal.GetComponent<GoalManager>().lose = true;
            //        Win();
            //    }
            //}

            if (spawnedGoal)
            {
                if (goal.GetComponent<GoalManager>().goalHealth == 0)
                {
                    //SetGoalPause();
                    //enemyGoal.GetComponent<GoalManager>().lose = true;
                    Win();
                }
            }
        }

        void Win()
        {
            //Turn on Win UI
            winUI.SetActive(true);
            resetButtonUI.SetActive(true);

            // for debugging
            goal.GetComponent<GoalManager>().pause = true;
        }

        void SetGoalPause()
        {
            goal.GetComponent<GoalManager>().pause = true;
            enemyGoal.GetComponent<GoalManager>().pause = true;
        }

        void CheckLoss()
        {
            if (spawnedGoal && enemyGoal != null)
            {
                if (goal.GetComponent<GoalManager>().lose)
                {
                    SetGoalPause();
                    Lose();
                }
            }
        }

        void Lose()
        {
            //Turn on Lose UI
            loseUI.SetActive(true);
            resetButtonUI.SetActive(true);
        }
    }
}
