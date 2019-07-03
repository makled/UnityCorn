using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unitycorn
{
    public class UnicornMover : MonoBehaviour
    {
        public int MIN_TIME_CHOICE_SECONDS = 3;
        public int MAX_TIME_CHOICE_SECONDS = 10;
        public int IDLE_TIME_BETWEEN_CHOICES = 2; 
        public float RATE_TARGET_PLAYER = 0.5f;
        public float SPEED = 2f;
        public float MAX_HEIGHT = 0.5f;

        [SerializeField]
        private GameObject Player;

        private float groundHeight;
        private System.DateTime lastTargetChosen;
        private System.TimeSpan timeTillNextChoice;
        private Vector3 target;
        private bool up;

        // Start is called before the first frame update
        void Start()
        {
            groundHeight = gameObject.transform.position.y;
            targetPlayer();
            up = true;
        }

        // Update is called once per frame
        void Update()
        {
            if(System.DateTime.Now > lastTargetChosen+timeTillNextChoice)
            {
                if(Random.value<RATE_TARGET_PLAYER)
                {
                    targetPlayer();
                }
                else
                {
                    targetRandomPoint();
                }
            }

            if(System.DateTime.Now > lastTargetChosen+ new System.TimeSpan(0, 0, 0, IDLE_TIME_BETWEEN_CHOICES))
            {
                float step = SPEED * Time.deltaTime; // calculate distance to move

                float dist = Vector3.Distance(transform.position, Player.transform.position);

                bool move = false;
                if (dist > 2)
                {
                    transform.position = Vector3.MoveTowards(transform.position, target, step);
                    move = true;
                }
                else
                {
                    up = false;
                }
                    
                if(move && up)
                {
                    if (transform.position.y < groundHeight + MAX_HEIGHT)
                    {
                        transform.position = transform.position + new Vector3(0f, step * 2f, 0f);
                    }
                    else
                    {
                        up = false;
                    }
                }
                else if(!up)
                {
                    if (transform.position.y > groundHeight)
                    {
                        transform.position = transform.position - new Vector3(0f, step * 2f, 0f);
                    }
                    else
                    {
                        up = true;
                    }
                }
                
                
                transform.LookAt(target);
                transform.localEulerAngles = new Vector3(0f, transform.localEulerAngles.y, 0f);
            }
        }

        private void targetRandomPoint()
        {
            float randX = Random.Range(-25f, 25f);
            float randZ = Random.Range(-25f, 25f);
            target = new Vector3(randX, groundHeight+0.5f, randZ);
            renewTimes();
        }

        private void targetPlayer()
        {
            target = Player.transform.position;
            target.y = groundHeight+0.5f;
            renewTimes();
        }

        private void renewTimes()
        {
            lastTargetChosen = System.DateTime.Now;
            int newSecondsTime = Random.Range(MIN_TIME_CHOICE_SECONDS, MAX_TIME_CHOICE_SECONDS + 1);
            timeTillNextChoice = new System.TimeSpan(0, 0, 0, newSecondsTime);
        }
    }
}