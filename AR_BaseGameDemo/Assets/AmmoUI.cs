using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MyFirstARGame
{
    public class AmmoUI : MonoBehaviour
    {
        int ammo = 3;
        Text ammoText;
        // Start is called before the first frame update
        void Start()
        {
            ammoText = gameObject.GetComponent<Text>();
        }

        // Update is called once per frame
        void Update()
        {
            ammoText.text = "Ammo: " + ammo.ToString();
        }
    }
}
