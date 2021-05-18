using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    private float xPosition;
    private Vector3 initialPosition;

    public float distance;

    void Start()
    {
        initialPosition = transform.position;

        distance = Random.Range(1f, 3f);
    }

    void Update()
    {
        xPosition = Mathf.PingPong(Time.time, distance);

        transform.position = initialPosition + new Vector3(xPosition, 0, 0);
    }
}
