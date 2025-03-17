using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntGroupMovement : MonoBehaviour
{
    public static bool isStopped = false;
    public float speed = 0.2f;
    public float maxDistance = 10f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (!isStopped)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);

            if (Vector3.Distance(transform.position, startPosition) > maxDistance)
            {
                transform.position = startPosition;
            }
        }
    }

    void OnMouseDown()
    {
        isStopped = !isStopped;
    }
}
