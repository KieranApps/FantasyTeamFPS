using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControlBase : MonoBehaviour
{
    public CharacterController player;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;


    protected float speed = 15f;
    protected float jumpHeight = 1.75f;
    
    private const float gravity = -22.5f;
    
    Vector3 velocity;
    bool isGrounded;

    public void GroundedCheck()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }

    public void Move() {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");        

        Vector3 move = transform.right * x + transform.forward * z;
        player.Move(velocity * Time.deltaTime);
        player.Move(speed * Time.deltaTime * move);
    }

    public void CalculateGravity ()
    {
        Debug.Log(isGrounded);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        velocity.y += gravity * Time.deltaTime;
    }

    public void Jump()
    {
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }
}
