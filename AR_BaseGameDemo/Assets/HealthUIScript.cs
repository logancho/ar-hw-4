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

        // Start is called before the first frame update
        void Start()
        {
            pm = cam.GetComponent<PlayerManager>();
            //GameObject g = GameObject.Find("Goal");
            //goal = g.GetComponent<GoalManager>();
            //livesText = gameObject.GetComponent<Text>();
        }

        // Update is called once per frame
        void Update()
        {
            if (goal == null)
            {
                //GameObject g = GameObject.Find("Goal(Clone)");
                
                if (pm.goal1 != null)
                {
                    Debug.Log("G was found");
                    goal = pm.goal1.GetComponent<GoalManager>();
                    livesText = gameObject.GetComponent<Text>();
                } else
                {
                    Debug.Log("G not found");
                }
            } else
            {
                livesText.text = "LIVES: " + goal.goalHealth.ToString();
            }

            //livesText.text = "LIVES: " + goal.goalHealth.ToString();
        }
    }
}
