using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfettScript : MonoBehaviour
{
    public ParticleSystem confettiEmitter;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag =="Player")
		{
            confettiEmitter.Play();
		}
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag =="Player")
		{
            confettiEmitter.Stop();
		}
    }
    void Update()
    {

    }
}
   