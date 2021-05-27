using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName ="Data/GameData")]
public class GameData : ScriptableObject //um asset para guardar vários tipos de informação; tipo um game object, mas é um asset
{
    public int coinsCaught;
    public string gameString;

    public void SaveGameState()
    {
        GameSave newGameSave = new GameSave();

        newGameSave.coinsCaught = coinsCaught;
        newGameSave.gameString = "hello";

        SaveManager.SaveGame(newGameSave);
    }

    public void LoadGameState()
    {
        GameSave currentState = SaveManager.Load();

        coinsCaught = currentState.coinsCaught;
        gameString = currentState.gameString;
    }
}
