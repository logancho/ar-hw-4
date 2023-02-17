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
            UpdatePause();
        }

        void FindGoal()
        {
            //if (someGoal == null)
            //{
                //someGoal = GameObject.Find("Player_1 Goal");
                someGoal = GameObject.Find("Goal(Clone)");

                //For single player testing
                //someGoal = GameObject.Find("Player_0 Goal");
            //}
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
            if (!pause)
            {
                if (collision.collider.CompareTag("Goal") && collidable)
                {
                    collision.collider.GetComponent<GoalManager>().goalHealth--;
                    Destroy(gameObject);
                }
                else
                {
                    //Turn off collider if we hit something other than a goal
                    collidable = false;
                    Debug.Log("hit something other than goal.");
                }
            }
        }
    }
}
