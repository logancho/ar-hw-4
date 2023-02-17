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
            FindEnemyGoal();
            EndGame();
            CheckLoss();
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
            Vector3 pos = new Vector3(1.0f, 0.3f, 0);

            if (PhotonNetwork.LocalPlayer.ActorNumber == 2)
            {
                pos *= -1;
            }
            var initialData = new object[] { PhotonNetwork.LocalPlayer.ActorNumber };

            this.goal = PhotonNetwork.Instantiate(this.goalPrefab.name, pos, Quaternion.identity, data: initialData);
            this.goal.name = "Player_" + (PhotonNetwork.LocalPlayer.ActorNumber - 1).ToString() + " Goal";
        }

        void FindEnemyGoal()
        {
            enemyGoal = GameObject.Find("Goal(Clone)");
        }

        void EndGame()
        {
            //If both goals exist
            if (spawnedGoal && enemyGoal != null)
            {
                if (enemyGoal.GetComponent<GoalManager>().goalHealth == 0)
                {
                    SetGoalPause();
                    enemyGoal.GetComponent<GoalManager>().lose = true;
                    Win();
                }

                if (goal.GetComponent<GoalManager>().goalHealth == 0)
                {
                    SetGoalPause();
                    goal.GetComponent<GoalManager>().lose = true;
                    Lose();
                }
            }
        }

        void Win()
        {
            winUI.SetActive(true);
            resetButtonUI.SetActive(true);
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
