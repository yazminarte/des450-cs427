using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleOnClick : MonoBehaviour
{
    private Vector3 originalScale;
    public float scaleFactor = 3.5f;
    private bool isScaledUp = false;
    private AudioSource audioSource;
    public Transform wand;

    void Start()
    {
        originalScale = transform.localScale;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if ((/*Input.GetMouseButtonDown(0) || */CAVE2.GetButtonDown(CAVE2.Button.Button3)) && IsPointingAtThis())
        {
            transform.localScale = isScaledUp ? originalScale : originalScale * scaleFactor;
            isScaledUp = !isScaledUp;
            if (audioSource != null && audioSource.clip != null) audioSource.Play();
        }
    }

    bool IsPointingAtThis()
    {
        Ray ray = Input.GetMouseButtonDown(0) ? Camera.main.ScreenPointToRay(Input.mousePosition) : new Ray(wand.position, wand.forward);
        return Physics.Raycast(ray, out RaycastHit hit) && hit.collider.gameObject == gameObject;
    }
}
