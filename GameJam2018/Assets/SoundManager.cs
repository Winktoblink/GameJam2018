using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    public AudioSource musicSource;
    public static SoundManager instance = null;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void PlayMusic(AudioClip clip)//We don't need Play for your problem.
    {
        musicSource.clip = clip;
        musicSource.Play();
    }

    public void StopMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Stop();
    }
}