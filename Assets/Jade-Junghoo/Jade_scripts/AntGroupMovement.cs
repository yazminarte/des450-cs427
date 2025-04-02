using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntGroupMovement : MonoBehaviour
{
    public static bool isStopped = false;
    public float speed = 0.2f;
    public float maxDistance = 10f;
    public Transform wand;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (wand == null)
        {
            return;
        }

        if (!isStopped)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);

            if (Vector3.Distance(transform.position, startPosition) > maxDistance)
            {
                transform.position = startPosition;
            }
        }

        if (CAVE2.GetButtonDown(CAVE2.Button.Button3) && IsPointingAtThis())
        {
            isStopped = !isStopped;
        }
    }

    bool IsPointingAtThis()
    {
        Ray ray = new Ray(wand.position, wand.forward);
        return Physics.Raycast(ray, out RaycastHit hit) && hit.collider.gameObject == gameObject;
    }
}
