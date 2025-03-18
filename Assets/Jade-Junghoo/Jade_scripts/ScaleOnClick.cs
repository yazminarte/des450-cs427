using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleOnClick : MonoBehaviour
{
    private Vector3 originalScale;
    public float scaleFactor = 3.5f;
    private bool isScaledUp = false;
    private AudioSource audioSource;

    void Start()
    {
        originalScale = transform.localScale;
        audioSource = GetComponent<AudioSource>();
    }

    void OnMouseDown()
    {
        if (isScaledUp)
        {
            transform.localScale = originalScale;
        }
        else
        {
            transform.localScale = originalScale * scaleFactor;
        }

        isScaledUp = !isScaledUp;

        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
        }
    }
}
