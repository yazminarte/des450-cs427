﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWall1 : MonoBehaviour
{

    public float speed = 50;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         
       transform.Rotate(Vector3.up, 50 * Time.deltaTime);
    
    }
}
