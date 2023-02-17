using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

namespace MyFirstARGame
{
    public class GoalManager : MonoBehaviour
    {
        //public GameObject goalPrefab;
        //public GameObject goal1 { get; private set; }
        //public GameObject goal2 { get; private set; }
        // Start is called before the first frame update
        [SerializeField]
        private Material[] goalMaterials;

        int goalID;
        public int goalHealth = 5;

        public bool pause = false;
        public bool lose = false;

        void Awake()
        {
            var photonView = this.transform.GetComponent<PhotonView>();
            var playerId = Mathf.Max((int)photonView.InstantiationData[0], 0);

            goalID = playerId;
            Debug.Log(playerId);

            if (this.goalMaterials.Length > 0)
            {
                var material = this.goalMaterials[playerId % this.goalMaterials.Length];
                this.transform.GetComponent<Renderer>().material = material;
            }
        }
    }
}
