using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unitycorn
{
    public class SwordManager : MonoBehaviour
    {
        private float Damage = 1;
        //public GameObject hand;
        

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            //transform.root.position = hand.transform.position;
            //transform.root.rotation = hand.transform.rotation;
        }
        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log("COL");
            if (collision.collider.CompareTag("Enemy"))
            {
                //Here apply damage to enemy
                collision.gameObject.transform.root.GetComponent<MinionController>().ReceiveDamage(Damage);
                Debug.Log("Hit Enemy00");
            }
        }
    }
}

