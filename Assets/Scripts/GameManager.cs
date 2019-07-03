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
        public int UniCoin, MMCoin;
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

        }

        // Update is called once per frame
        void Update()
        {
            UniCoinText.text = UniCoin.ToString();
            MMCoinText.text = MMCoin.ToString();
        }

        public void IncreasePlayerCoin()
        {
            UniCoin = UniCoin + 100;
        }

        public void IncreaseMasterMindCoin()
        {
            UniCoin = UniCoin + 250;
        }

        public void DecreasePlayerCoin()
        {
            UniCoin = UniCoin - 100;
        }
        public void DecreaseMasterMindCoin(int value)
        {
            UniCoin = UniCoin - value;
        }

    }
}

