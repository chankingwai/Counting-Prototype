using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBall : Ball
{

    public override void Launch(Vector3 direction, float force)
    {
        rb.AddForce(direction * force * 0.5f);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Player") && rb.transform.localScale.x > 0.4 ) 
        {
            transform.localScale -= new Vector3(0.02f, 0.02f, 0.02f);
        }
        
    }

    

}
