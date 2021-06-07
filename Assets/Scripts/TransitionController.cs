using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionController : MonoBehaviour
{
    private Animator _animator;
    private AsyncOperation loadLevel;

    void Start()
    {
        DontDestroyOnLoad(gameObject);

        _animator = GetComponent<Animator>();
    }

    public void TransitionToLevel(int level)
    {
        StartCoroutine(LoadSceneCoroutine(level));
    }

    private IEnumerator LoadSceneCoroutine(int level)
    {
        loadLevel = SceneManager.LoadSceneAsync(level);
        float progress = 0f;

        loadLevel.allowSceneActivation = false;

        _animator.SetTrigger("in");

        yield return new WaitForSecondsRealtime(0.5f);

        while (!loadLevel.isDone)
        {
            progress = loadLevel.progress;

            if (progress >= 0.9f)
            {
                loadLevel.allowSceneActivation = true;
            }

            yield return null;
        }

        _animator.SetTrigger("out");

        yield return new WaitForSecondsRealtime(0.5f);

        Destroy(gameObject);
    }
}
