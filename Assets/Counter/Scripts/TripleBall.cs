using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleBall : Ball
{
    


    public override void Launch(Vector3 direction, float force)
    {
        rb.AddForce(direction * force * 1.5f);
    }
}
