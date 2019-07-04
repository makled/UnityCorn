using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Unitycorn
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance = null;
        public Text UniCoinText;
        public Text MMCoinText;
        public Text GameOverText;
        public int UniCoin, MMCoin;

        public bool gameOver;
        public bool mmWon;
        public bool defWon;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else if (Instance != this)
                Destroy(this);

            DontDestroyOnLoad(this);
        }

        // Start is called before the first frame update
        void Start()
        {
            gameOver = false;
            mmWon = false;
            defWon = false;
        }

        // Update is called once per frame
        void Update()
        {
            UniCoinText.text = UniCoin.ToString();
            MMCoinText.text = MMCoin.ToString();

            if(mmWon)
            {
                UniCoinText.text = "Defeat!";
                MMCoinText.text = "Victory!";
            }
            if (defWon)
            {
                UniCoinText.text = "Victory!";
                MMCoinText.text = "Defeat!";
            }
            if (!gameOver)
            {
                testGameOver();
            }
        }

        private void testGameOver()
        {
            if(UniCoin < 0)
            {
                gameOver = true;
                mmWon = true;
                defWon = false;
                GameOverText.text = "You Died!";
            }
            else if (MMCoin < 0)
            {
                gameOver = true;
                mmWon = false;
                defWon = true;
                GameOverText.text = "You Win!";
            } 
        }

        public void IncreasePlayerCoin()
        {
            UniCoin = UniCoin + 10;
        }

        public void IncreaseMasterMindCoin()
        {
            UniCoin = UniCoin + 50;
        }

        public void DecreasePlayerCoin()
        {
            UniCoin = UniCoin - 60;
        }
        public void DecreaseMasterMindCoin(int value)
        {
            MMCoin = MMCoin - value;
        }

    }
}

