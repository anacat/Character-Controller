using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject prefab;

    public int round = 0;
    [Space(10)]
    //public float timeBetweenSpawns;
    public float timeBetweenRounds;
    public int maxEnemies;

    [Header("Spawn data")]
    public List<RoundData> roundData;

    private float spawnTimer;
    private float roundTimer;
    private List<GameObject> spawnedEnemies = new List<GameObject>();
    private int enemyCounter;

    // Start is called before the first frame update
    void Start()
    {
        roundTimer = timeBetweenRounds;
        //spawnTimer = timeBetweenSpawns;
    }

    // Update is called once per frame
    void Update()
    {
        if(round > roundData.Count - 1)
        {
            return;
        }

        spawnTimer += Time.deltaTime;

        if (spawnTimer > roundData[round].timeBetweenSpawns)
        {
            if (enemyCounter < roundData[round].numberOfEnemies)
            {
                Debug.Log("Spawned enemy " + enemyCounter);

                GameObject enemy = Instantiate(prefab, transform.position, transform.rotation, transform);
                //spawnedEnemies.Add(enemy);
                enemyCounter++;

                spawnTimer = 0;
            }
            else
            {
                Debug.Log("Waiting for round to finish");

                roundTimer += Time.deltaTime;

                if (roundTimer > timeBetweenRounds)
                {
                    Debug.Log("Changed to round: " + round);

                    round++;
                    roundTimer = 0f;

                    enemyCounter = 0;
                    spawnTimer = 0;
                }
            }
        }
    }

    public float GetRoundTimer()
    {
        return roundTimer;
    }

    public float GetSpawnTimer()
    {
        return spawnTimer;
    }
}

[Serializable]
public class RoundData
{
    public int numberOfEnemies;
    public float timeBetweenSpawns;
}
