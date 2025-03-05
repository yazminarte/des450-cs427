using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StretchObject : MonoBehaviour
{
    public Transform meterObject;
    private Vector3 initialMousePosition;
    private Vector3 initialFeetScale;
    private Vector3 initialMeterScale;
    private Vector3 initialFeetPosition;
    private Vector3 initialMeterPosition;
    private float scaleRatio;

    private bool isDragging = false;

    void Start()
    {
        scaleRatio = meterObject.localScale.x / transform.localScale.x;
        initialFeetPosition = transform.position;
        initialMeterPosition = meterObject.position;
    }

    void OnMouseDown()
    {
        isDragging = true;
        initialMousePosition = Input.mousePosition;
        initialFeetScale = transform.localScale;
        initialMeterScale = meterObject.localScale;
        initialFeetPosition = transform.position;
        initialMeterPosition = meterObject.position;
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            float mouseDelta = (Input.mousePosition.x - initialMousePosition.x) * 0.01f;

            float newFeetX = Mathf.Max(0.1f, initialFeetScale.x + mouseDelta);
            transform.localScale = new Vector3(newFeetX, initialFeetScale.y, initialFeetScale.z);

            float newMeterX = newFeetX * scaleRatio;
            meterObject.localScale = new Vector3(newMeterX, initialMeterScale.y, initialMeterScale.z);

            float feetDelta = (newFeetX - initialFeetScale.x) / 2f;
            transform.position = new Vector3(initialFeetPosition.x - feetDelta, initialFeetPosition.y, initialFeetPosition.z);
            meterObject.position = new Vector3(initialMeterPosition.x - feetDelta, initialMeterPosition.y, initialMeterPosition.z);
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
    }
}
