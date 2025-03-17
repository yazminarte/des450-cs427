using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleOnClick : MonoBehaviour
{
    private Vector3 originalScale;
    public float scaleFactor = 1.5f;
    private bool isScaledUp = false;

    void Start()
    {
        originalScale = transform.localScale;
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
    }
}
