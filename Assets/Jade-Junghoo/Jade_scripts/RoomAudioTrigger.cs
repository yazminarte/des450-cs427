using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class RoomAudioTrigger : MonoBehaviour
{
    public AudioClip roomMusic;
    public float fadeDuration = 1.5f;

    private AudioSource audioSource;
    private Coroutine fadeCoroutine;

    void Start()
    {
        GameObject musicPlayer = GameObject.Find("MusicPlayer");
        if (musicPlayer != null)
        {
            audioSource = musicPlayer.GetComponent<AudioSource>();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("PlayerController"))
        {
            if (roomMusic != null)
            {
                if (audioSource.clip != roomMusic)
                {
                    if (fadeCoroutine != null) StopCoroutine(fadeCoroutine);
                    fadeCoroutine = StartCoroutine(FadeToNewMusic(roomMusic));
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.name.Contains("PlayerController"))
        {
            if (roomMusic != null && audioSource.clip == roomMusic)
            {
                if (fadeCoroutine != null) StopCoroutine(fadeCoroutine);
                fadeCoroutine = StartCoroutine(FadeOut());
            }
        }
    }

    IEnumerator FadeToNewMusic(AudioClip newClip)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0.01f)
        {
            audioSource.volume -= Time.deltaTime / fadeDuration;
            yield return null;
        }

        audioSource.Stop();
        audioSource.clip = newClip;
        audioSource.Play();

        while (audioSource.volume < startVolume)
        {
            audioSource.volume += Time.deltaTime / fadeDuration;
            yield return null;
        }

        audioSource.volume = startVolume;
    }

    IEnumerator FadeOut()
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0.01f)
        {
            audioSource.volume -= Time.deltaTime / fadeDuration;
            yield return null;
        }

        audioSource.Stop();
        audioSource.clip = null;
        audioSource.volume = startVolume;
    }
}
