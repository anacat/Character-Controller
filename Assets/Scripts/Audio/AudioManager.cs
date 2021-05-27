using System;
using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public GameObject backgroundMusicHolder;

    public AudioData buttonSelect;
    public AudioData buttonHightlight;

    public AudioData menuMusic;
    public AudioData gameMusic;

    private AudioSource _soundEffectAudioSource;
    private AudioSource _menuAudioSource;
    private AudioSource _gameAudioSource;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else if(Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject); //n destroi o objecto quando a proxima cena é carregada

        _soundEffectAudioSource = GetComponent<AudioSource>();

        _menuAudioSource = backgroundMusicHolder.AddComponent<AudioSource>();
        _gameAudioSource = backgroundMusicHolder.AddComponent<AudioSource>();

        _menuAudioSource.clip = menuMusic.clip;
        _menuAudioSource.loop = true;
        _menuAudioSource.volume = menuMusic.volume;
        _menuAudioSource.playOnAwake = false;

        _gameAudioSource.clip = gameMusic.clip;
        _gameAudioSource.loop = true;
        _gameAudioSource.volume = gameMusic.volume;
        _menuAudioSource.playOnAwake = true;
        _gameAudioSource.Play();
    }

    public void ButtonSelectSFX()
    {
        _soundEffectAudioSource.PlayOneShot(buttonSelect.clip, buttonSelect.volume);
    }

    public void ButtonHighlightSFX()
    {
        AudioSource source = gameObject.AddComponent<AudioSource>();
        source.PlayOneShot(buttonHightlight.clip, buttonHightlight.volume);

        StartCoroutine(DestroyAudioSource(source));
    }

    //Coroutine
    private IEnumerator DestroyAudioSource(AudioSource source)
    {
        yield return new WaitWhile(() => source.isPlaying); //espera enquanto o audiosource estiver a tocar

        Destroy(source);
    }

    public void ChangeToGameMusic()
    {
        _gameAudioSource.UnPause();
        _menuAudioSource.Stop();
    }

    public void ChangeToMenuMusic()
    {
        _menuAudioSource.Play();
        _gameAudioSource.Pause();
    }
}

[Serializable]
public class AudioData //agregador de dados por audio clip
{
    public AudioClip clip;
    [Range(0, 1)] public float volume;
}
