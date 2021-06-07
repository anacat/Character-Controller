using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public LoadingController loadingScreen;

    public void PlayBtnClick()
    {
        //SceneManager.LoadScene(1);
        //SceneManager.LoadScene("Level1");
        loadingScreen.LoadLevel(1);
    }

    public void ExitBtnClick()
    {
        Application.Quit();
    }
}
