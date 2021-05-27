using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public InstantiateCoins instantiateCoins;
    public GameData gameData;

    public int coinsCaught = 0;

    private int numberOfCoins;
    private bool gameOver = false;

    void Start()
    {
        numberOfCoins = instantiateCoins.nCoins;

        gameData.LoadGameState();
        coinsCaught = gameData.coinsCaught;

        //utilizar PlayerPrefs é recomendado para guardar settings do jogo, tais como, resulução, qualidade, volume, etc.
        //deve-se evitar utilizar para guardar estados de jogo, porque podem ser facilmente alterados pelo utilizador
        
        //coinsCaught = PlayerPrefs.GetInt("coins");
    }

    void Update()
    {
        if (coinsCaught == numberOfCoins && gameOver == false)
        {
            Debug.Log("Caught all the coins!!!!");

            gameOver = true;
        }

        //Para efeitos de debug, estamos a guardar o estado do jogo qd carregamos numa tecla
        if(Input.GetKeyDown(KeyCode.I))
        {
            gameData.SaveGameState();
        }
    }

    public void OnCoinCaught()
    {
        coinsCaught++;
        gameData.coinsCaught = coinsCaught;

        //PlayerPrefs.SetInt("coins", coinsCaught);
        //PlayerPrefs.Save();
    }

    private void OnApplicationQuit()
    {
        gameData.SaveGameState(); //chamado quando o jogo é fechado
    }
}
