using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToBounceBall : MonoBehaviour
{
    private Rigidbody rb;
    private bool isFalling = false;
    private AudioSource audioSource;
    public AudioClip clickSound;
    public AudioClip bounceSound;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezePositionY;

        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    ActivateGravity();

                    if (audioSource != null && clickSound != null)
                    {
                        audioSource.PlayOneShot(clickSound);
                    }
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
        if (collision.gameObject.CompareTag("Ground"))
        {
            rb.velocity = new Vector3(rb.velocity.x, Mathf.Abs(rb.velocity.y) * 0.9f, rb.velocity.z);

            if (audioSource != null && bounceSound != null)
            {
                audioSource.PlayOneShot(bounceSound);
            }
        }
    }
}
