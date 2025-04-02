using UnityEngine;

public class ParticleSound : MonoBehaviour
{
    private AudioSource audioSource;
    private ParticleSystem particleSystem;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        particleSystem = GetComponent<ParticleSystem>();

        var main = particleSystem.main;
        main.stopAction = ParticleSystemStopAction.Callback;
    }

    void Update()
    {
        if (particleSystem.isPlaying && !audioSource.isPlaying)
        {
            audioSource.Play();
        }

        if (!particleSystem.isPlaying && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
