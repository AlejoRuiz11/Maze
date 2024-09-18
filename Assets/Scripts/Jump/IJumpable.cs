using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IJumpable
{
    Rigidbody Rb { get; }

    float JumpForce { get; }
    bool IsJumping { get; }

    void Jump();
}
