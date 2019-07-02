using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;
using Valve.VR.InteractionSystem;

public class MoveTowards : MonoBehaviour
{

    private Transform target;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<Camera>().gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        transform.LookAt(target);
    }
}

