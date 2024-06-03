using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DryadController : CharacterControlBase
{
    private bool usedDoubleJump = false;
    private float doubleJumpBoost = 2f;
    public override void Jump()
    {
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if (!isGrounded && !usedDoubleJump && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(doubleJumpBoost * -2f * gravity);
            usedDoubleJump = true;
        }
    }


    void Update()
    {
        base.GroundedCheck();
        if (isGrounded && usedDoubleJump)
        {
            usedDoubleJump = false;
        }
        base.CalculateGravity();
        Jump();
        // Move after other calculations
        base.Move();

    }
}
