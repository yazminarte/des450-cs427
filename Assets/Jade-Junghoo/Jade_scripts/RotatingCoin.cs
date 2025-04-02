using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingCoin : MonoBehaviour
{
    public float speed = 5f;
    private AudioSource audioSource;
    private bool isRotatingFast = false;
    public Transform wand;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
        if (isRotatingFast) transform.Rotate(Vector3.up, 360f * Time.deltaTime);

        if ((/*Input.GetMouseButtonDown(0) || */CAVE2.GetButtonDown(CAVE2.Button.Button3)) && IsPointingAtThis() && !isRotatingFast)
        {
            StartCoroutine(QuickRotate());
            if (audioSource != null && audioSource.clip != null) audioSource.Play();
        }
    }

    IEnumerator QuickRotate()
    {
        isRotatingFast = true;
        yield return new WaitForSeconds(0.5f);
        isRotatingFast = false;
    }

    bool IsPointingAtThis()
    {
        Ray ray = Input.GetMouseButtonDown(0) ? Camera.main.ScreenPointToRay(Input.mousePosition) : new Ray(wand.position, wand.forward);
        return Physics.Raycast(ray, out RaycastHit hit) && hit.collider.gameObject == gameObject;
    }
}