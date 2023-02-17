using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

namespace MyFirstARGame
{
    public class GoalManager : MonoBehaviour
    {
        [SerializeField]
        private Material[] goalMaterials;
        [SerializeField]
        private GameObject child;
        int goalID;
        public int goalHealth = 5;

        public bool pause = false;
        public bool lose = false;

        public bool reset = false;

        void Awake()
        {
            var photonView = this.transform.GetComponent<PhotonView>();
            var playerId = Mathf.Max((int)photonView.InstantiationData[0], 0);

            goalID = playerId;
            Debug.Log(playerId);

            if (this.goalMaterials.Length > 0)
            {
                var material = this.goalMaterials[playerId % this.goalMaterials.Length];
                child.transform.GetComponent<Renderer>().material = material;
            }
        }

        //[PunRPC]
        //public void ReceiveGoal()
        //{
        //}
    }
}
