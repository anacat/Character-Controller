using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float angle = 0f;

    void Update()
    {
        transform.rotation = Quaternion.Euler(0, -angle, 0);

        angle += Time.deltaTime;
    }
}
