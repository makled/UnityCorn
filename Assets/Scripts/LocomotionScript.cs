using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unitycorn
{
    public class LocomotionScript : MonoBehaviour
    {

        private static float CLOSE_TO_MAX_STICK_MAGNITUDE = 0.8f;
        private static float CLOSE_TO_MIN_STICK_MAGNITUDE = 0.5f;
        private static float LOCOMOTION_FORCE = 0.05f;
        private static float MOMENTUM_PART = 0.95f;
        private static float DASH_MULTIPLIER = 4f;
        private static int DASH_TIME_MILLIS = 400;
        private static int FLICK_TOLERANCE_MILLIS = 200;

        [SerializeField]
        private int ArenaSize;

        [SerializeField]
        private GameObject Player;
        [SerializeField]
        private GameObject PlayerHead;

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
            cropPositionOfPlayer();
            //Debug.Log("Vector: (" + vector.x + " ," + vector.y + ") mag: " + vector.magnitude);
        }

        private void cropPositionOfPlayer()
        {
            Debug.Log("Croping pos");
            float offsetX = PlayerHead.transform.position.x - (ArenaSize+1.5f);
            if (offsetX > 0)
            {
                Player.transform.position = Player.transform.position - new Vector3(offsetX, 0);
            }
            if (offsetX < -60)
            {
                offsetX = (offsetX + 60);
                Player.transform.position = Player.transform.position - new Vector3(offsetX, 0);
            }

            float offsetZ = PlayerHead.transform.position.z - (ArenaSize + 1.5f);
            if (offsetZ > 0)
            {
                Player.transform.position = Player.transform.position - new Vector3(0, 0, offsetZ);
            }
            if (offsetZ < -60)
            {
                offsetZ = (offsetZ + 60);
                Player.transform.position = Player.transform.position - new Vector3(0, 0, offsetZ);
            }
        }

        private void applyDash(Vector2 vector)
        {
            lastLocomotionVector = vector;
            Debug.Log("Dash!");
        }

        private void applyRegularLocomotion(Vector2 vector)
        {
            if (System.DateTime.Now.Subtract(lastDash) < new System.TimeSpan(0, 0, 0, 0, DASH_TIME_MILLIS))
            {
                vector = vector * DASH_MULTIPLIER;
            }

            Vector2 locomotion = lastLocomotionVector * MOMENTUM_PART + vector * (1f-MOMENTUM_PART);
            

            lastLocomotionVector = locomotion;
            while(lastRegularLocomotion<System.DateTime.Now)
            {
                lastRegularLocomotion = lastRegularLocomotion + new System.TimeSpan(0, 0, 0, 0, 8);
                Vector3 relativePositionChange = new Vector3(locomotion.x, 0, locomotion.y) * LOCOMOTION_FORCE;
                Vector3 globalPositionChange = PlayerHead.transform.TransformVector(relativePositionChange);
                globalPositionChange.y = 0f;
                Player.transform.position = Player.transform.position + globalPositionChange;
            }
        }
    }
}
