using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTeleport : MonoBehaviour
{
		public Transform target = null;
		public Transform target2 = null;
		bool firstJump = false;
		bool secondJump = false;


	private void OnTriggerEnter(Collider other)
		{

			if (other.gameObject.tag =="orange" && firstJump == false && secondJump == false)
		{
		
					this.transform.position = target.position;
					firstJump = true;

		}

		if (other.gameObject.tag == "mango" && firstJump == false && secondJump == false)
		{

					this.transform.position = target2.position;
					secondJump = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{

		if (other.gameObject.tag == "orange")
		{

			secondJump = false;
		}

		if (other.gameObject.tag == "mango")
		{

			firstJump = false;
		}
	}

}

