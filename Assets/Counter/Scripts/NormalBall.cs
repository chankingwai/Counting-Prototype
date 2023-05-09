using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBall : Ball
{
    // INHERITANCE
    public override void Launch(Vector3 direction, float force)
    {
        rb.AddForce(direction * force);
    }
}
