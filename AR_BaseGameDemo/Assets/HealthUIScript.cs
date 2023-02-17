using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MyFirstARGame
{
    public class HealthUIScript : MonoBehaviour
    {
        public GameObject cam;
        private PlayerManager pm;
        GoalManager goal = null;
        Text livesText;
        
        void Start()
        {
            pm = cam.GetComponent<PlayerManager>();
        }

        // Update is called once per frame
        void Update()
        {
            UpdateGoalHealth();
        }

        void UpdateGoalHealth()
        {
            if (goal == null)
            {
                if (pm.goal != null)
                {
                    Debug.Log("G was found");
                    goal = pm.goal.GetComponent<GoalManager>();
                    livesText = gameObject.GetComponent<Text>();
                }
                else
                {
                    Debug.Log("G not found");
                }
            }
            else
            {
                livesText.text = "LIVES: " + goal.goalHealth.ToString();
            }
        }
    }
}
