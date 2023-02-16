using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

namespace MyFirstARGame
{
    public class PlayerManager : MonoBehaviour
    {
        //var photonView = this.transform.GetComponent<PhotonView>();
        public GameObject goalPrefab;
        public GameObject goal1 { get; private set; }

        public int Health = 5;

        void Awake()
        {
            Invoke("SpawnGoal", 2.0f);
        }

        void SpawnGoal()
        {
            Vector3 pos = new Vector3(0.5f, 0, 0);

            if (PhotonNetwork.LocalPlayer.ActorNumber == 2)
            {
                pos *= -1;
            }
            var initialData = new object[] { PhotonNetwork.LocalPlayer.ActorNumber };
            //var initialData = new object[] { this };
            this.goal1 = PhotonNetwork.Instantiate(this.goalPrefab.name, pos, Quaternion.identity, data: initialData);
        }
    }
}
