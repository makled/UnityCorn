using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;
using Valve.VR.InteractionSystem;

namespace Unitycorn
{
    public class MoveTowards : MonoBehaviour
    {

        private Vector3 target;
        public float speed;

        // Start is called before the first frame update
        void Start()
        {
            target = FindObjectOfType<Camera>().gameObject.transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            if(GameManager.Instance.gameOver)
            {
                target = new Vector3(0f, 9001f, 0f);
            }
            float step = speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, target, step);
            transform.LookAt(target);
        }
    }


}
