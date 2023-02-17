using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

namespace MyFirstARGame
{
    public class BallBehavior : MonoBehaviour
    {
        [SerializeField]
        private Material[] ballMaterials;
        private bool collidable = true;
        public bool pause = false;

        private GameObject someGoal = null;

        void Awake()
        {
            var photonView = this.transform.GetComponent<PhotonView>();
            var playerId = Mathf.Max((int)photonView.InstantiationData[0], 0);
            if (this.ballMaterials.Length > 0)
            {
                var material = this.ballMaterials[playerId % this.ballMaterials.Length];
                this.transform.GetComponent<Renderer>().material = material;
            }
        }

        void Update()
        {
            FindGoal();
            //update pause
        }

        void FindGoal()
        {
            if (someGoal == null)
            {
                //someGoal = GameObject.Find("Player_1 Goal");
                someGoal = GameObject.Find("Player_0 Goal");
            }
        }
        void UpdatePause()
        {
            if (someGoal != null)
            {
                pause = someGoal.GetComponent<GoalManager>().pause;
            }
        }

        void OnCollisionEnter(Collision collision)
        {
            //if (!pause)
            //{
                //Check if collider tag is "Goal"
                if (collision.collider.CompareTag("Goal") && collidable &&
                    !collision.collider.GetComponent<GoalManager>().pause)
                {
                    collision.collider.GetComponent<GoalManager>().goalHealth--;

                    //if (collision.collider.GetComponent<GoalManager>().goalHealth <= 4)
                    //{
                    //    //Game over!
                    //    //Call Game over function
                    //    Debug.Log("Game over!");
                    //}
                    Destroy(gameObject);
                    //Call goal's update points function
                }
                else
                {
                    //Turn off collider
                    collidable = false;
                    Debug.Log("hit something other than goal.");
                }
            //}
        }
    }
}
