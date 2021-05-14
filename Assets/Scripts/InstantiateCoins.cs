using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateCoins : MonoBehaviour
{
    public GameObject prefab;
    public float raio = 2f;
    public int nCoins;

    public List<GameObject> coinList = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < nCoins; i++)
        {
            Vector2 randomPoint = Random.insideUnitCircle * raio;

            GameObject coin = Instantiate(prefab, transform.position +
                new Vector3(randomPoint.x, 0, randomPoint.y),
                Random.rotation, transform);

            coinList.Add(coin);
        }
    }
}
