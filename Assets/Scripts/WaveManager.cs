using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unitycorn
{
    public class WaveManager : MonoBehaviour
    {
        public List<string> Enemies;
        public Transform[] SpawnPoint;
        public bool isSpawned;
        public GameObject RedEnemy;
        public GameObject BlueEnemy;
        public GameObject GreenEnemy;
        public GameObject[] spawnPoints;
        private int maxNumberGroups =3;
        // Start is called before the first frame update
        void Start()
        {
            Enemies = new List<string>();
            //SpawnPoints = GameObject.FindGameObjectsWithTag("")
            spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        }

        // Update is called once per frame
        void Update()
        {
            if(Enemies.Count >= 3 && !isSpawned)
            {
                
                SpawnEnemies();
            }
        }

        public void AddEnemy(string enemyString)
        {
            Enemies.Add(enemyString);
            Debug.Log("Enemies");
        }

        public void SpawnEnemies()
        {
            isSpawned = true;

            foreach(var enemy in Enemies)
            {
                string[] tempEnemy = enemy.Split('_');
                int randPos = Random.Range(0, 5);
                GameObject selectedSpawnPoint = this.spawnPoints[randPos]; // select random SpawnPoint
                Spawner spawnScript = selectedSpawnPoint.GetComponent<Spawner>();
                for (int i = 0; i < System.Int32.Parse(tempEnemy[1]); i++)
                {
                    switch (tempEnemy[0])
                    {
                        case "G":
                            {
                                // GameObject g = Instantiate(GreenEnemy);
                                // g.transform.position = SpawnPoint[randPos].position;
                                spawnScript.Spawn(GreenEnemy);
                                break;
                            }
                        case "B":
                            {
                                spawnScript.Spawn(BlueEnemy);
                                break;
                            }
                        case "R":
                            {
                                spawnScript.Spawn(RedEnemy);
                                break;
                            }
                    }
                }
            }
            Enemies.Clear();
            
        }
    }
}

