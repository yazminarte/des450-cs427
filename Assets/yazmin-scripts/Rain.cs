using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain: MonoBehaviour
{

 void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
            other.attachedRigidbody.useGravity = true;
    }


}
