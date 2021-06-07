using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingController : MonoBehaviour
{
    public Image progressBar;

    private CanvasGroup _canvasGroup;

    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void LoadLevel(int level)
    {
        StartCoroutine(LoadSceneCoroutine(level));
    }

    private IEnumerator LoadSceneCoroutine(int level)
    {
        AsyncOperation loadLevel = SceneManager.LoadSceneAsync(level);
        float progress = 0f;

        loadLevel.allowSceneActivation = false;

        _canvasGroup.alpha = 1f;
        _canvasGroup.blocksRaycasts = true;

        while (!loadLevel.isDone)
        {
            progress = loadLevel.progress;
            progressBar.fillAmount = progress;

            if (progress >= 0.9f)
            {
                progressBar.fillAmount = 1f;

                loadLevel.allowSceneActivation = true;
            }

            yield return null;
        }

        _canvasGroup.alpha = 0f;
        _canvasGroup.blocksRaycasts = false;
    }
}
