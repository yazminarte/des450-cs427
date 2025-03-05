using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ClickToBatSwing : MonoBehaviour
{
    private bool isSwinging = false;

    void OnMouseDown()
    {
        if (!isSwinging)
        {
            StartCoroutine(SwingBat());
        }
    }

    IEnumerator SwingBat()
    {
        isSwinging = true;

        float backswingAngle = 20f;
        float swingAngle = -100f;
        float returnSpeed = 3f;
        float swingSpeed = 5f;

        Quaternion originalRotation = transform.rotation;
        Quaternion backswingRotation = Quaternion.Euler(0, backswingAngle, 0) * originalRotation;
        Quaternion swingRotation = Quaternion.Euler(0, swingAngle, 0) * originalRotation;

        float elapsedTime = 0f;
        float duration = 0.9f;

        while (elapsedTime < duration)
        {
            transform.rotation = Quaternion.Lerp(originalRotation, backswingRotation, elapsedTime / (duration / 2));
            elapsedTime += Time.deltaTime * swingSpeed;

            yield return null;
        }

        transform.rotation = backswingRotation;

        yield return new WaitForSeconds(0.1f);

        elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            transform.rotation = Quaternion.Lerp(backswingRotation, swingRotation, elapsedTime / duration);
            elapsedTime += Time.deltaTime * swingSpeed;

            yield return null;
        }

        transform.rotation = swingRotation;

        yield return new WaitForSeconds(0.2f);

        elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            transform.rotation = Quaternion.Lerp(swingRotation, originalRotation, elapsedTime / duration);
            elapsedTime += Time.deltaTime * returnSpeed;

            yield return null;
        }

        transform.rotation = originalRotation;
        isSwinging = false;
    }
}
