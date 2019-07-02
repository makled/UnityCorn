using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unitycorn
{
    public class LocomotionScript : MonoBehaviour
    {

        [SerializeField]
        private GameObject player;


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void supplyLocomotionVector(Vector2 vector)
        {
            player.transform.position = player.transform.position + new Vector3(vector.x, 0, vector.y) * 0.15f;
        }
    }
}
