using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unitycorn
{
    public class LocomotionScript : MonoBehaviour
    {

        private static float closeToMaxStickMagnitude = 0.8f;
        private static float closeToMinStickMagnitude = 0.2f;

        [SerializeField]
        private GameObject player;

        private System.DateTime lastFlick;
        private System.DateTime lastCheck;
        private System.DateTime lastDash;
        private System.DateTime lastRegularLocomotion;
        private Vector2 lastVector;



        // Start is called before the first frame update
        void Start()
        {
            lastFlick = System.DateTime.MinValue;
            lastCheck = System.DateTime.MinValue;
            lastDash = System.DateTime.MinValue;

            lastRegularLocomotion = System.DateTime.Now;
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void supplyLocomotionVector(Vector2 vector)
        {
            if (vector.magnitude > closeToMaxStickMagnitude)
            {
                if(System.DateTime.Now.Subtract(lastCheck) < new System.TimeSpan(0, 0, 0, 0, 100) && lastVector.magnitude < closeToMinStickMagnitude)
                {
                    if(System.DateTime.Now.Subtract(lastFlick) < new System.TimeSpan(0, 0, 0, 0, 200))
                    {
                        applyDash(vector);
                        lastDash = System.DateTime.Now; 
                    }
                    lastFlick = System.DateTime.Now;
                }
                lastCheck = System.DateTime.Now;
                lastVector = vector;
            }
            if(vector.magnitude < closeToMinStickMagnitude)
            {
                lastCheck = System.DateTime.Now;
                lastVector = vector;
            }
            
            applyRegularLocomotion(vector);

            Debug.Log("Vector: (" + vector.x + " ," + vector.y + ") mag: " + vector.magnitude);
        }

        private void applyDash(Vector2 vector)
        {
            Debug.Log("Dash!");
        }

        private void applyRegularLocomotion(Vector2 vector)
        {
            while(lastRegularLocomotion<System.DateTime.Now)
            {
                lastRegularLocomotion = lastRegularLocomotion + new System.TimeSpan(0, 0, 0, 0, 8);
                player.transform.position = player.transform.position - new Vector3(vector.x, 0, vector.y) * 0.03f;
            }
        }
    }
}
