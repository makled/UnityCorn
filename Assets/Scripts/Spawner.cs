using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> Enemies;

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), 0f, 3f);
    }

    public void Spawn()
    {
        if (Enemies.Count <= 0)
            return;

        Instantiate(Enemies[0], transform.position, Quaternion.identity);
        Enemies.RemoveAt(0);
    }

    public void SetEnemies(GameObject e)
    {
        Enemies.Add(e);
    }
}
