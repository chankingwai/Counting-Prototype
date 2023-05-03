using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;

    public GameObject ballPrefab;
    Vector3 lookDirection = new Vector3(0, -1, 0);

    public float speed;
    public float changeTime = 1.0f;


    public int direction = 1;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        timer = changeTime;
    }

    // Update is called once per frame
    void Update()
    {
        Leftandright();

        if (Input.GetMouseButtonDown(0))
        {
            Launch();
        }

    }

    // Fixed Update is executed First, then Update, then Lateupdate

    void FixedUpdate()
    {

        Vector3 position = rb.position;

        position.z = position.z + Time.deltaTime * speed * direction;
        rb.MovePosition(position);


    }

   
    void Leftandright ()
    {
        timer += Time.deltaTime;
        //following code move player by time
        //if (timer > 0.4 ) //test the number to ensure it returns at the end
        //{
        //    direction = -direction;
        //    timer = changeTime;
        //}    
    }

    //if player collides Wallbound, it bounces back
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bound"))
        {
            direction = -direction;
            timer = changeTime;
        }
        
    }

    void Launch()
    {
        GameObject ballObject = Instantiate(ballPrefab, rb.position + Vector3.down * 0.5f, Quaternion.identity);

        NormalBall normalball = ballObject.GetComponent<NormalBall>();
        normalball.Launch(lookDirection, 300);

        
    }
}
