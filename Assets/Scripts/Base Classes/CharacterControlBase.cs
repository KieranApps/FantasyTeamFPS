using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControlBase : MonoBehaviour
{
    public CharacterController player;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;


    private float speed = 15f;
    private const float gravity = -22.5f;
    private float jumpHeight = 1.75f;
    Vector3 velocity;
    bool isGrounded;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");        

        Vector3 move = transform.right * x + transform.forward * z;
        player.Move(speed * Time.deltaTime * move);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        player.Move(velocity * Time.deltaTime);
    }
}
