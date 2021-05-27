using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour
{
    public Camera mainCamera;

    public Image lifebar;
    public float lifeTotal = 10;
    public float currentLife = 0;
    
    void Start()
    {
        mainCamera = Camera.main;

        currentLife = lifeTotal;
    }

    void Update()
    {
        transform.LookAt(mainCamera.transform);

        if(Input.GetKeyDown(KeyCode.V))
        {
            currentLife--;
        }

        lifebar.fillAmount = currentLife / lifeTotal;

        if(currentLife < 5)
        {
            lifebar.color = Color.red;
        }
    }
}
