using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MyFirstARGame
{
    public class TimerUI : MonoBehaviour
    {
        Text timertext;
        public int time;
        float period;
        int minutes;
        string seconds;
        bool pause = false;

        // Start is called before the first frame update
        void Start()
        {
            time = 0;
            period = 0;
            minutes = 0;
            timertext = gameObject.GetComponent<Text>();
        }

        // Update is called once per frame
        void Update()
        {
            CheckIfPause();
            if (!pause)
            {
                //time += (int) Time.deltaTime;
                period += Time.deltaTime;
                if (period > 1.0f)
                {
                    time++;
                    if (time < 10)
                    {
                        seconds = "0" + time.ToString();
                    }
                    else
                    {
                        seconds = time.ToString();
                    }

                    if (time > 58)
                    {
                        minutes++;
                        time = 0;
                    }
                    timertext.text = "Time: " + minutes.ToString() + ":" + seconds;
                    period = 0;
                }
            }
        }

        void CheckIfPause()
        {
            GameObject goal = GameObject.Find("Goal(Clone)");
            if (goal != null)
            {
                pause = goal.GetComponent<GoalManager>().pause;
            }
        }
    }
}