using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace MyFirstARGame
{
    public class InvisibleBehavior : MonoBehaviour
    {
        public GameObject cam;
        private ProjectileLauncher pl;

        // Start is called before the first frame update
        void Start()
        {
            //Find cam
            cam = GameObject.Find("Main Camera");
            pl = cam.GetComponent<ProjectileLauncher>();
        }

        private void Update()
        {
            cam = GameObject.Find("Main Camera");
            pl = cam.GetComponent<ProjectileLauncher>();
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.CompareTag("Ball") && cam != null)
            {
                pl = cam.GetComponent<ProjectileLauncher>();
                pl.ballSupply += 5;
                PhotonNetwork.Destroy(collision.collider.gameObject);
            }
            PhotonNetwork.Destroy(gameObject);
        }
    }
}
