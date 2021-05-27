using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathSFX : MonoBehaviour
{
    public AudioClip clip;
    private AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.PlayOneShot(clip);

        StartCoroutine(WaitForSound());
    }

    private IEnumerator WaitForSound()
    {
        yield return new WaitWhile(() => _audioSource.isPlaying); //espera enquanto o som está a tocar no audiosource

        Destroy(gameObject);
    }
}
