using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unitycorn
{
    public class LaserManager : MonoBehaviour
    {
        private LineRenderer lineRend;

        [SerializeField]
        private GameObject Muzzle;
        // Start is called before the first frame update
        void Start()
        {
            lineRend = GetComponent<LineRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            lineRend.SetPosition(0, Muzzle.transform.position);
            lineRend.SetPosition(1, Muzzle.transform.forward * 10f);
        }
    }

}
