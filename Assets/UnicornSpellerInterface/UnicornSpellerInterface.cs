﻿using System;
using UnityEngine;
using System.Net;
using Unity.ItemRecever;

namespace Unitycorn
{
    public class UnicornSpellerInterface : MonoBehaviour
    {
        public Unitycorn.WaveManager waveMan;

        [Tooltip("Activate this to not wait on receiving Commands from the BCI but spawn enemies randmoly.")]
        [SerializeField]
        public bool random;

        private System.DateTime lastSpawn;

        // Start is called before the first frame update
        void Start()
        {
            try
            {
                //IP settings
                string ips = "127.0.0.1";
                int port = 1000;
                IPAddress ip = IPAddress.Parse(ips);

                //Start listening for Unicorn Speller network messages
                SpellerReceiver r = new SpellerReceiver(ip, port);

                //attach items received event
                r.OnItemReceived += OnItemReceived;

                Debug.Log(String.Format("Listening to {0} on port {1}.", ip, port));

                lastSpawn = System.DateTime.Now;
            }
            catch (Exception ex)
            {
                Debug.Log(ex.Message);
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (random && (System.DateTime.Now - lastSpawn > new System.TimeSpan(0, 0, 0, 8)))
            {
                lastSpawn = System.DateTime.Now;
                float rndmValue = UnityEngine.Random.value;
                String result = "";
                if (rndmValue < 0.33f)
                {
                    result += "G_";
                }
                else if (rndmValue < 0.66f)
                {
                    result += "B_";
                }
                else
                {
                    result += "R_";
                }
                result += ("" + UnityEngine.Random.Range(5, 21));
                waveMan.AddEnemy(result);
            }
            //Do something...
        }

        // OnItemReceived is called if a classified item is received from Unicorn Speller via udp.
        private void OnItemReceived(object sender, EventArgs args)
        {
            ItemReceivedEventArgs eventArgs = (ItemReceivedEventArgs)args;
            Debug.Log(String.Format("Received BoardItem:\tName: {0}\tOutput Text: {1}", eventArgs.BoardItem.Name, eventArgs.BoardItem.OutputText));

            if (!random)
            {
                int cost = 0;
                if (eventArgs.BoardItem.OutputText.Equals("R_5"))
                {
                    cost = 100;
                }
                else if (eventArgs.BoardItem.OutputText.Equals("R_10"))
                {
                    cost = 200;
                }
                else if (eventArgs.BoardItem.OutputText.Equals("R_20"))
                {
                    cost = 300;
                }
                else if (eventArgs.BoardItem.OutputText.Equals("G_5"))
                {
                    cost = 25;
                }
                else if (eventArgs.BoardItem.OutputText.Equals("G_10"))
                {
                    cost = 50;
                }
                else if (eventArgs.BoardItem.OutputText.Equals("G_20"))
                {
                    cost = 100;
                }
                else if (eventArgs.BoardItem.OutputText.Equals("B_5"))
                {
                    cost = 50;
                }
                else if (eventArgs.BoardItem.OutputText.Equals("B_10"))
                {
                    cost = 100;
                }
                else if (eventArgs.BoardItem.OutputText.Equals("B_20"))
                {
                    cost = 200;
                }
                if (!GameManager.Instance.gameOver)
                {
                    GameManager.Instance.DecreaseMasterMindCoin(cost);
                    waveMan.AddEnemy(eventArgs.BoardItem.OutputText);
                }
            }

        }
    }

}
