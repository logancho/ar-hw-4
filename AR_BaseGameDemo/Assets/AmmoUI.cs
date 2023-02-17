using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MyFirstARGame
{
    public class AmmoUI : MonoBehaviour
    {
        public GameObject cam;
        private ProjectileLauncher pl;
        //int ammo = 3;
        Text ammoText;
        // Start is called before the first frame update
        void Start()
        {
            pl = cam.GetComponent<ProjectileLauncher>();
            ammoText = gameObject.GetComponent<Text>();
        }

        // Update is called once per frame
        void Update()
        {
            ammoText.text = "AMMO: " + pl.ballSupply.ToString();
        }
    }
}