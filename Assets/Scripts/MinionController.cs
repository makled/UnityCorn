
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unitycorn
{
    public class MinionController : MonoBehaviour
    {
        public float health;
        public Animation_Test anim;
        private MoveTowards movement;
        // Start is called before the first frame update
        void Start()
        {
            anim = GetComponentInChildren<Animation_Test>();
            movement = GetComponent<MoveTowards>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void ReceiveDamage(float damageAmount)
        {
            anim.DamageAni();

            health -= damageAmount;
            if (health <= 0)
                StartCoroutine(Die());
        }

        IEnumerator Die()
        {
            movement.speed = 0f;
            anim.DeathAni();

            yield return new WaitForSeconds(2.8f);
            GameManager.Instance.IncreasePlayerCoin();

            Destroy(this.gameObject);
        }
    }
}
