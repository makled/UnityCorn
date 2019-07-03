using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public void Spawn(GameObject enemy)
    {
        Instantiate(enemy, transform.position, Quaternion.identity);
    }
}
