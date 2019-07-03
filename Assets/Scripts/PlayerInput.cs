using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

namespace Unitycorn
{
    public class PlayerInput : MonoBehaviour
    {
        public bool isShoot; 
        private Vector2 locomotionVector;

        public GunManager gun;
        public LocomotionScript locomotion;
        // Start is called before the first frame update
        void Start()
        {
            gun = FindObjectOfType<GunManager>();
        }

        // Update is called once per frame
        void Update()
        {
            if(gun == null)
                gun = FindObjectOfType<GunManager>();
            isShoot = SteamVR_Input.GetStateUp("ShootGun", SteamVR_Input_Sources.LeftHand);
            if(isShoot)
            {
                gun.ShootGun();
            }

            locomotionVector = SteamVR_Input.GetVector2("Locomotion", SteamVR_Input_Sources.LeftHand);
            locomotion.supplyLocomotionVector(locomotionVector);
        }


    }
}

