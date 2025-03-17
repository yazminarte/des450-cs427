using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotating : MonoBehaviour
{

    public float speed = 15;

    void Start()
    {

    }

    void Update()
    {
        transform.Rotate(Vector3.up, speed);
    }
}
