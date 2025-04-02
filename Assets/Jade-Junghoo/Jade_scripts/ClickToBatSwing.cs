using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToBatSwing : MonoBehaviour
{
    private bool isSwinging = false;
    private AudioSource audioSource;
    public Transform wand;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if ((/*Input.GetMouseButtonDown(0) || */CAVE2.GetButtonDown(CAVE2.Button.Button3)) && IsPointingAtThis())
        {
            HandleSwing();
        }
    }

    void HandleSwing()
    {
        if (!isSwinging)
        {
            StartCoroutine(SwingBat());
            if (audioSource != null && audioSource.clip != null) audioSource.Play();
        }
    }

    IEnumerator SwingBat()
    {
        isSwinging = true;
        float duration = 0.9f;
        Quaternion originalRotation = transform.rotation;
        Quaternion backswing = Quaternion.Euler(0, 20f, 0) * originalRotation;
        Quaternion swing = Quaternion.Euler(0, -100f, 0) * originalRotation;

        float t = 0f;
        while (t < duration / 2)
        {
            transform.rotation = Quaternion.Lerp(originalRotation, backswing, t / (duration / 2));
            t += Time.deltaTime * 5f;
            yield return null;
        }

        transform.rotation = backswing;
        yield return new WaitForSeconds(0.1f);

        t = 0f;
        while (t < duration)
        {
            transform.rotation = Quaternion.Lerp(backswing, swing, t / duration);
            t += Time.deltaTime * 5f;
            yield return null;
        }

        transform.rotation = swing;
        yield return new WaitForSeconds(0.2f);

        t = 0f;
        while (t < duration)
        {
            transform.rotation = Quaternion.Lerp(swing, originalRotation, t / duration);
            t += Time.deltaTime * 3f;
            yield return null;
        }

        transform.rotation = originalRotation;
        isSwinging = false;
    }

    bool IsPointingAtThis()
    {
        Ray ray = Input.GetMouseButtonDown(0) ? Camera.main.ScreenPointToRay(Input.mousePosition) : new Ray(wand.position, wand.forward);
        return Physics.Raycast(ray, out RaycastHit hit) && hit.collider.gameObject == gameObject;
    }
}
