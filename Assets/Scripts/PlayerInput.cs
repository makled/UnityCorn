using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

namespace Unitycorn
{
    public class PlayerInput : MonoBehaviour
    {
        public bool isShoot; 
        public SteamVR_Action_Boolean button;

        public GunManager gun;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            isShoot = SteamVR_Input.GetStateUp("ShootGun", SteamVR_Input_Sources.LeftHand);
            if(isShoot)
            {
                gun.ShootGun();
            }
        }


    }
}

