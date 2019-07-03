using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    
    void SpawnInitialization(System.Tuple<GameObject, GameObject>[] selectedEnemiesAndSpawns)
    {
        foreach(System.Tuple<GameObject, GameObject> enemyAndSpawn in selectedEnemiesAndSpawns)
        {
            Spawner spawnerScript = enemyAndSpawn.Item2.GetComponent<Spawner>();
            GameObject enemy = enemyAndSpawn.Item1;
           // spawnerScript.Spawn(enemy);
        }
    }
}
