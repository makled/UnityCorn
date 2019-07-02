
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unitycorn
{
    public class MinionController : MonoBehaviour
    {
        public int health;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void receiveDamage(int damageAmount)
        {
            health -= damageAmount;
            if (health <= 0)
                Destroy(this);
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "MasterMind")
            {
                // TODO increase the score of the masterMind
            }
        }
    }
}
