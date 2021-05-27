using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int maxHp;
    public int hp;

    public GameObject deathAudioPrefab;

    private AudioSource _audioSource;
    private bool _isDead;

    private void Start()
    {
        hp = maxHp;

        _audioSource = GetComponent<AudioSource>();
    }

    public void BulletHit()
    {
        hp--;

        if (hp <= 0 && !_isDead)
        {
            _isDead = true;

            Instantiate(deathAudioPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
