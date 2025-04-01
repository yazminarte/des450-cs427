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
    public Transform wand;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezePositionY;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if ((/*Input.GetMouseButtonDown(0) || */CAVE2.GetButtonDown(CAVE2.Button.Button3)) && IsPointingAtThis())
        {
            ActivateGravity();
            if (audioSource != null && clickSound != null)
            {
                audioSource.PlayOneShot(clickSound);
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
            float newYVelocity = Mathf.Abs(rb.velocity.y) * 0.85f;
            rb.velocity = new Vector3(rb.velocity.x, newYVelocity, rb.velocity.z);

            if (audioSource != null && bounceSound != null)
            {
                audioSource.PlayOneShot(bounceSound);
            }
        }
    }

    bool IsPointingAtThis()
    {
        Ray ray = Input.GetMouseButtonDown(0)
            ? Camera.main.ScreenPointToRay(Input.mousePosition)
            : new Ray(wand.position, wand.forward);

        return Physics.Raycast(ray, out RaycastHit hit) && hit.collider.gameObject == gameObject;
    }
}
