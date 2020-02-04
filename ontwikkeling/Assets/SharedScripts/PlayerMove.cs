using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody rb;
    public float moveSpeed = 4;
    public float jumpForce = 3;
    Vector3 moveDir;
    bool canJump = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //movement
        // rb.MovePosition(transform.position + (transform.forward * Input.GetAxis("Vertical") * moveSpeed * Time.fixedDeltaTime) +
        //     (transform.right * Input.GetAxis("Horizontal") * moveSpeed * Time.fixedDeltaTime));

        moveDir.x = Input.GetAxis("Horizontal");
        moveDir.z = Input.GetAxis("Vertical");

        transform.Translate(moveDir * moveSpeed * Time.fixedDeltaTime);


        //jump
        if (Input.GetButtonDown("Jump") && canJump)
        {
            canJump = false;
            rb.velocity = new Vector3(0, jumpForce, 0);
            rb.AddForce(transform.forward * 50f);
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
