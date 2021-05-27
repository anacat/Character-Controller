using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float lifeTime;
    public float timer;

    public GameManager gameManager;
    private Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddRelativeForce(0f, 0f, 1000f, ForceMode.Acceleration);
    }

    private void Update()
    {
        //Destroi passado X tempo
        timer += Time.deltaTime;

        if(timer > lifeTime)
        {
            Destroy(gameObject);
        }
        
        //Destroi por altura
        //if(transform.position.y < -100)
        //{
        //    Destroy(gameObject);
        //}
    }

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider.tag);

        if(collider.CompareTag("Coin"))
        {
            gameManager.coinsCaught++;
            Destroy(collider.gameObject);
        }

        if(collider.CompareTag("Enemy"))
        {
            EnemyController enemy = collider.gameObject.GetComponent<EnemyController>();

            if(enemy != null)
            {
                enemy.BulletHit();
            }
        }

        Destroy(gameObject);
    }
}
