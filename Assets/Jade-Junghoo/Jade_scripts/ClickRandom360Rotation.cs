using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickRandom360Rotation : MonoBehaviour
{
    private bool isRotating = false;
    private AudioSource audioSource;
    public Transform wand;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if ((/*Input.GetMouseButtonDown(0) || */CAVE2.GetButtonDown(CAVE2.Button.Button3)) && IsPointingAtThis() && !isRotating)
        {
            StartCoroutine(RotateRandomDirection());
            if (audioSource != null && audioSource.clip != null) audioSource.Play();
        }
    }

    IEnumerator RotateRandomDirection()
    {
        isRotating = true;
        Vector3 randomAxis = Random.insideUnitSphere.normalized;
        float rotatedAmount = 0f;
        while (rotatedAmount < 360f)
        {
            float step = 720f * Time.deltaTime;
            transform.Rotate(randomAxis, step, Space.Self);
            rotatedAmount += step;
            yield return null;
        }
        isRotating = false;
    }

    bool IsPointingAtThis()
    {
        Ray ray = Input.GetMouseButtonDown(0) ? Camera.main.ScreenPointToRay(Input.mousePosition) : new Ray(wand.position, wand.forward);
        return Physics.Raycast(ray, out RaycastHit hit) && hit.collider.gameObject == gameObject;
    }
}
