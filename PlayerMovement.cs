using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Grounded Settings")]
    public bool isGrounded;
    public Vector3 groundBox;
    public Transform groundCheck;
    public LayerMask groundMask;

    [Header("Trampoline Settings")]
    public bool trampolineJump = false;
    public LayerMask trampMask;
    public float trampolinePower;

    [Header("Bed Settings")]
    public bool bedJump = false;
    public LayerMask bedMask;
    public float bedPower;
    public float forwardPower;

    private Rigidbody playerRigidbody;

    [Header("Player Settings")]
    public float playerSpeed = 10;
    public float jumpForce = 5;

    private void Start()
    {
        playerRigidbody = this.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        GroundCheck();
        Jump();
        Crouch();
    }

    private void FixedUpdate()
    {
        Run();
        Jumps();
    }

    public void Run()
    {
        playerRigidbody.AddRelativeForce(Vector3.right * playerSpeed - playerRigidbody.velocity);
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                playerRigidbody.AddForce(0, jumpForce, 0);
            }
        }
    }

    public void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            jumpForce = jumpForce / 2;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            
            if (isGrounded)
            {
                gameObject.transform.localScale = new Vector3(0.4f, 0.25f, 0.4f);
            }
        }else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            jumpForce = jumpForce * 2;
            gameObject.transform.localScale = new Vector3(0.4f, 0.35f, 0.4f);
        }
    }

    public void Jumps()
    {
        if (trampolineJump)
        {
            playerRigidbody.AddForce(0, trampolinePower, 0);
        }

        if (bedJump)
        {
            playerRigidbody.AddForce(forwardPower, bedPower, 0);
        }
    }

    public void GroundCheck()
    {
        isGrounded = Physics.CheckBox(groundCheck.position, groundBox, transform.rotation, groundMask);
        trampolineJump = Physics.CheckBox(groundCheck.position, groundBox, transform.rotation, trampMask);
        bedJump = Physics.CheckBox(groundCheck.position, groundBox, transform.rotation, bedMask);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(groundCheck.position, groundBox);
    }
}
