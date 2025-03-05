using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ClickToBounceBall : MonoBehaviour
{
    private Rigidbody rb;
    private bool isFalling = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezePositionY;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("detected");

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    ActivateGravity();
                }
            }
        }
    }

    void ActivateGravity()
    {
        if (!isFalling)
        {
            rb.useGravity = true;
            rb.constraints = RigidbodyConstraints.None;
            rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);
            isFalling = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision event: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("detected");
            rb.velocity = new Vector3(rb.velocity.x, Mathf.Abs(rb.velocity.y) * 0.9f, rb.velocity.z);
        }
    }
}