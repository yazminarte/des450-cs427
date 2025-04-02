using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StretchObject : MonoBehaviour
{
    public Transform meterObject;
    public Transform wand;
    public CAVE2.Button dragButton = CAVE2.Button.Button3;

    public TextMeshPro feetText;
    public TextMeshPro meterText;

    private Vector3 initialWandPos;
    private Vector3 initialFeetScale;
    private Vector3 initialMeterScale;
    private Vector3 initialFeetPosition;
    private Vector3 initialMeterPosition;
    private float scaleRatio = 0.305f;

    private bool isDragging = false;

    void Start()
    {
        initialFeetPosition = transform.position;
        initialMeterPosition = meterObject.position;

        UpdateText();
    }

    void Update()
    {
        if (!isDragging && CAVE2.GetButtonDown(dragButton))
        {
            isDragging = true;
            initialWandPos = wand.position;
            initialFeetScale = transform.localScale;
            initialMeterScale = meterObject.localScale;
            initialFeetPosition = transform.position;
            initialMeterPosition = meterObject.position;
        }

        if (isDragging && CAVE2.GetButton(dragButton))
        {
            float delta = (wand.position.x - initialWandPos.x);

            float newFeetX = Mathf.Max(0.1f, initialFeetScale.x + delta);
            transform.localScale = new Vector3(newFeetX, initialFeetScale.y, initialFeetScale.z);
            meterObject.localScale = new Vector3(newFeetX, initialMeterScale.y, initialMeterScale.z);

            float feetDelta = (newFeetX - initialFeetScale.x) / 2f;
            transform.position = new Vector3(initialFeetPosition.x - feetDelta, initialFeetPosition.y, initialFeetPosition.z);
            meterObject.position = new Vector3(initialMeterPosition.x - feetDelta, initialMeterPosition.y, initialMeterPosition.z);

            UpdateText();
        }

        if (isDragging && CAVE2.GetButtonUp(dragButton))
        {
            isDragging = false;
        }
    }

    void UpdateText()
    {
        if (feetText != null)
        {
            feetText.text = $"{transform.localScale.x:F2} FEET";
        }

        if (meterText != null)
        {
            float meterValue = transform.localScale.x * scaleRatio;
            meterText.text = $"{meterValue:F2} METER";
        }
    }
}
