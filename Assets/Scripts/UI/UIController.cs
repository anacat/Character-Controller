using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public EnemySpawner enemySpawner;

    public TextMeshProUGUI roundText;
    public TextMeshProUGUI roundTimeText;
    public TextMeshProUGUI spawnTimeText;

    public GameObject pauseGroup;
    private bool isPaused;

    private void Start()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
        roundText.text = "Round: " + enemySpawner.round;
        roundTimeText.text = string.Format("Time Until Next Round: {0:0.0}", enemySpawner.GetRoundTimer());
        spawnTimeText.text = string.Format("Time Until Next Spawn: {0:0.0}", enemySpawner.GetSpawnTimer());

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            pauseGroup.SetActive(isPaused);

            if (isPaused)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
    }

    public void ContinueBtn()
    {
        isPaused = false;
        pauseGroup.SetActive(false);

        Time.timeScale = 1;
    }

    public void ExitBtn()
    {
        SceneManager.LoadScene(0);
    }
}
