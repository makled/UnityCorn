﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unitycorn
{
    public class GunManager : MonoBehaviour
    {
        [Tooltip("Reference to bullet prefabs")]
        [SerializeField]
        private GameObject BulletPrefab;

        [Tooltip("Reference to Muzzle Game")]
        [SerializeField]
        private GameObject MuzzleGameObject;

        [Tooltip("Energy value in float")]
        [SerializeField]
        private float Energy;

        [Tooltip("Refrence to Bullet Type")]
        [SerializeField]
        private Bullet BulletType;

        // [Tooltip("Bullet Energy Consumption value in float")]
        // [SerializeField]
        // private float bulletConsumption;


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void ShootGun()
        {
            GameObject bulletInstance = Instantiate(BulletPrefab);
            bulletInstance.transform.position = MuzzleGameObject.transform.position;
            bulletInstance.transform.rotation = MuzzleGameObject.transform.rotation;

            Energy = Energy - BulletType.BulletEnergyConsumption;
            bulletInstance.GetComponent<BulletController>().SetDamage(BulletType.BulletDamage);
            
        }
    } 
}
