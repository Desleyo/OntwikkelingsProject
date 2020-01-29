using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody rb;
    public float moveSpeed = 5;
    public float jumpForce = 5;
    public bool canJump = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //movement
        rb.MovePosition(transform.position + (transform.forward * Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime) +
            (transform.right * Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime));

        //jump
        if (Input.GetButtonDown("Jump") && canJump)
        {
            canJump = false;
            rb.velocity = new Vector3(0, jumpForce, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }
    }
}
