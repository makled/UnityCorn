using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

        [Tooltip("Refrence to the Text displaying the Energy")]
        [SerializeField]
        private Text EnergyTextField;

        public static GunManager Instance;
        // [Tooltip("Bullet Energy Consumption value in float")]
        // [SerializeField]
        // private float bulletConsumption;


        // Start is called before the first frame update
        void Start()
        {

        }

        private void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this);
            }
        }

        // Update is called once per frame
        void Update()
        {
            EnergyTextField.text = "" + Energy;
        }

        public void ShootGun()
        {
            if(Energy -BulletType.BulletEnergyConsumption < 0)
            {
                return;
            }
            GameObject bulletInstance = Instantiate(BulletPrefab);
            bulletInstance.transform.position = MuzzleGameObject.transform.position;
            bulletInstance.transform.rotation = MuzzleGameObject.transform.rotation;

            Energy = Energy - BulletType.BulletEnergyConsumption;
            bulletInstance.GetComponent<BulletController>().SetDamage(BulletType.BulletDamage);
            
        }

        public void RechargeGun()
        {
            Energy = 500;
        }
    } 
}

