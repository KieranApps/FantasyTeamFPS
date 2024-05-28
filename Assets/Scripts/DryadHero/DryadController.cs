using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DryadController : CharacterControlBase
{
    public override void Jump()
    {
        if (isGrounded && Input.GetButtonDown("Jump"))
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
    }
    void Update()
    {
        // base.Update(); Use base to call the parent functions
        // Attributes are inherited and can just be used
        base.GroundedCheck();
        base.CalculateGravity();
        Jump();
        // Move after other calculations
        base.Move();

    }
}
