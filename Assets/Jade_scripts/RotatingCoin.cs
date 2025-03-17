using System.Collections;
using UnityEngine;

public class RotatingCoin : MonoBehaviour
{
    public float speed = 15f;
    private AudioSource audioSource;
    private bool isRotatingFast = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        transform.Rotate(Vector3.up, speed * Time.deltaTime);

        if (isRotatingFast)
        {
            transform.Rotate(Vector3.up, 360f * Time.deltaTime);
        }
    }

    void OnMouseDown()
    {
        if (!isRotatingFast)
        {
            StartCoroutine(QuickRotate());

            if (audioSource != null && audioSource.clip != null)
            {
                audioSource.Play();
            }
        }
    }

    IEnumerator QuickRotate()
    {
        isRotatingFast = true;

        yield return new WaitForSeconds(0.5f);

        isRotatingFast = false;
    }
}
