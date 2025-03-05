using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickRandom360Rotation : MonoBehaviour
{
    private bool isRotating = false;

    void OnMouseDown()
    {
        if (!isRotating)
        {
            StartCoroutine(RotateRandomDirection());
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
