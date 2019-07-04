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
        private float delayTime = 0.5f;
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
            if(Enemies.Count >= 1 && !isSpawned)
            {
                
                SpawnEnemies();
            }
        }

        public void AddEnemy(string enemyString)
        {
            if (enemyString == "_")
                return;

            Enemies.Add(enemyString);
            Debug.Log("Enemies");
        }

        public void SpawnEnemies()
        {
            isSpawned = true;

            foreach(var enemy in Enemies)
            {
                string[] tempEnemy = enemy.Split('_');
                
                for (int i = 0; i < System.Int32.Parse(tempEnemy[1]); i++)
                {
                    int randPos = Random.Range(0, 5);
                    GameObject selectedSpawnPoint = this.spawnPoints[randPos]; // select random SpawnPoint
                    Spawner spawnScript = selectedSpawnPoint.GetComponent<Spawner>();

                    switch (tempEnemy[0])
                    {
                        case "G":
                            {
                                // GameObject g = Instantiate(GreenEnemy);
                                // g.transform.position = SpawnPoint[randPos].position;
                                spawnScript.SetEnemies(GreenEnemy);
                                break;
                            }
                        case "B":
                            {
                                spawnScript.SetEnemies(BlueEnemy);
                                break;
                            }
                        case "R":
                            {   
                                spawnScript.SetEnemies(RedEnemy);
                                break;
                            }
                    }
                }
            }
            Enemies.Clear();
            isSpawned = false;
            //GunManager.Instance.RechargeGun();
        }
    }
}

