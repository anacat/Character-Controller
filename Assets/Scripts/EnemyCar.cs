using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCar : MonoBehaviour
{
    public Image lifeBar;
    public int lifeTotal;
    public int currentHP;

    public CarExplosionController explosion;

    public Transform meshParent;

    [Header("Car damage prefabs")]
    public GameObject noDamage;
    public GameObject halfDamage;
    public GameObject fullDamage;


    void Start()
    {
        currentHP = lifeTotal;
    }

    void Update()
    {
        lifeBar.fillAmount = (currentHP / (float)lifeTotal);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.tag);

        if(collision.collider.CompareTag("Player"))
        {
            currentHP--;

            if(currentHP <= lifeTotal / 2f && currentHP > 0)
            {
                Destroy(meshParent.GetChild(0).gameObject);
                Instantiate(halfDamage, transform.position, transform.rotation, meshParent);
            }
            else if(currentHP == 0)
            {
                explosion.PlayExplosion();
                Destroy(meshParent.GetChild(0).gameObject);
                Instantiate(fullDamage, transform.position, transform.rotation, meshParent);
            }
        }
    }
}
