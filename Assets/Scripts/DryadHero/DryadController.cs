using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DryadController : CharacterControlBase
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // base.Update(); Use base to call the parent functions
        // Attributes are inherited and can just be used
        base.GroundedCheck();
        base.CalculateGravity();
        base.Jump();
        // Move after other calculations
        base.Move();

    }
}
