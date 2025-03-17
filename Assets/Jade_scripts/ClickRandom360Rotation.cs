using System.Collections;
using UnityEngine;

public class ClickRandom360Rotation : MonoBehaviour
{
    private bool isRotating = false;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnMouseDown()
    {
        if (!isRotating)
        {
            StartCoroutine(RotateRandomDirection());

            if (audioSource != null && audioSource.clip != null)
            {
                audioSource.Play();
            }
        }
    }

    IEnumerator RotateRandomDirection()
    {
        isRotating = true;

        Vector3 randomAxis = Random.insideUnitSphere.normalized;
        float targetRotation = 360f;
        float rotationSpeed = 720f;

        float rotatedAmount = 0f;

        while (rotatedAmount < targetRotation)
        {
            float rotationStep = rotationSpeed * Time.deltaTime;
            transform.Rotate(randomAxis, rotationStep, Space.Self);
            rotatedAmount += rotationStep;

            yield return null;
        }

        isRotating = false;
    }
}
