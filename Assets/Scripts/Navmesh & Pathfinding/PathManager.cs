using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    public List<Transform> pathPointList = new List<Transform>();

    void Awake()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            pathPointList.Add(transform.GetChild(i));
        }
    }
}
