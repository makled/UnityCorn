using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unitycorn
{
    public class BulletController : MonoBehaviour
    {
        private float Damage;
        // Start is called before the first frame update
        void Start()
        {
            GetComponent<Rigidbody>().AddForce(this.transform.forward * 4f, ForceMode.Impulse);
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void SetDamage(float d)
        {
            Damage = d;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                //Here apply damage to enemy
                
            }

            DestroyBullet();
        }

        private void DestroyBullet()
        {
            Destroy(gameObject);
        }
    }
}

