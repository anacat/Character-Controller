using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public InstantiateCoins instantiateCoins;

    public int coinsCaught = 0;

    private int numberOfCoins;
    private bool gameOver = false;

    void Start()
    {
        numberOfCoins = instantiateCoins.nCoins;
    }

    void Update()
    {
        if (coinsCaught == numberOfCoins && gameOver == false)
        {
            Debug.Log("Caught all the coins!!!!");

            gameOver = true;
        }
    }

    public void OnCoinCaught()
    {
        coinsCaught++;
    }
}
