using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unitycorn
{
    public class LocomotionScript : MonoBehaviour
    {

        private static float CLOSE_TO_MAX_STICK_MAGNITUDE = 0.8f;
        private static float CLOSE_TO_MIN_STICK_MAGNITUDE = 0.5f;
        private static float LOCOMOTION_FORCE = 0.03f;
        private static float MOMENTUM_PART = 0.66f;
        private static int DASH_TIME_MILLIS = 400;
        private static int FLICK_TOLERANCE_MILLIS = 200;


        [SerializeField]
        private GameObject player;

        private System.DateTime lastFlick;
        private System.DateTime lastCheck;
        private System.DateTime lastDash;
        private System.DateTime lastRegularLocomotion;
        private Vector2 lastCheckVector;
        private Vector2 lastLocomotionVector;



        // Start is called before the first frame update
        void Start()
        {
            lastFlick = System.DateTime.MinValue;
            lastCheck = System.DateTime.MinValue;
            lastDash = System.DateTime.MinValue;

            lastRegularLocomotion = System.DateTime.Now;
            lastLocomotionVector = new Vector2();
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void supplyLocomotionVector(Vector2 vector)
        {
            if (vector.magnitude > CLOSE_TO_MAX_STICK_MAGNITUDE)
            {
                if(System.DateTime.Now.Subtract(lastCheck) < new System.TimeSpan(0, 0, 0, 0, FLICK_TOLERANCE_MILLIS) && lastCheckVector.magnitude < CLOSE_TO_MIN_STICK_MAGNITUDE)
                {
                    if(System.DateTime.Now.Subtract(lastFlick) < new System.TimeSpan(0, 0, 0, 0, FLICK_TOLERANCE_MILLIS * 2))
                    {
                        applyDash(vector);
                        lastDash = System.DateTime.Now; 
                    }
                    lastFlick = System.DateTime.Now;
                }
                lastCheck = System.DateTime.Now;
                lastCheckVector = vector;
            }
            if(vector.magnitude < CLOSE_TO_MIN_STICK_MAGNITUDE)
            {
                lastCheck = System.DateTime.Now;
                lastCheckVector = vector;
            }
            
            applyRegularLocomotion(vector);

            //Debug.Log("Vector: (" + vector.x + " ," + vector.y + ") mag: " + vector.magnitude);
        }

        private void applyDash(Vector2 vector)
        {
            lastLocomotionVector = vector;
            Debug.Log("Dash!");
        }

        private void applyRegularLocomotion(Vector2 vector)
        {
            Vector2 locomotion = lastLocomotionVector * MOMENTUM_PART + vector * (1f-MOMENTUM_PART);
            if(System.DateTime.Now.Subtract(lastDash) < new System.TimeSpan(0, 0, 0, 0, DASH_TIME_MILLIS))
            {
                locomotion = locomotion * 10f;
            }

            lastLocomotionVector = locomotion;
            while(lastRegularLocomotion<System.DateTime.Now)
            {
                lastRegularLocomotion = lastRegularLocomotion + new System.TimeSpan(0, 0, 0, 0, 8);
                player.transform.position = player.transform.position - new Vector3(locomotion.x, 0, locomotion.y) * LOCOMOTION_FORCE;
            }
        }
    }
}
