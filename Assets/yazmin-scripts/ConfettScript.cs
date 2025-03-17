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
		
				confettiEmitter.Emit(300);

		}
        }


        void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                confettiEmitter.Emit(30);

            }
            if (Input.GetKeyDown(KeyCode.Tab))
       
             {
             GetComponent<Rigidbody>().AddForce(transform.forward * 200f);
            }

        }



}
   