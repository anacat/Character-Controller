using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public void PlayBtnClick()
    {
        SceneManager.LoadScene(1);
        //SceneManager.LoadScene("Level1");
    }

    public void ExitBtnClick()
    {
        Application.Quit();
    }
}
