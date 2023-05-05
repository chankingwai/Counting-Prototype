using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;

    //different ball type
    public GameObject ballNormalPrefab;

    public GameObject ballTriplePrefab;
    public GameObject ballTriplePrefab1;
    public GameObject ballTriplePrefab2;

    public GameObject ballBigPrefab;



    Vector3 lookDirection = new Vector3(0, -1, 0);


    public float speed;
    public float changeTime = 1.0f;


    public int direction = 1;
    public float timer;

    public string currentBall = "normal";

    private bool disableLaunch = false;

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
        if (disableLaunch == false)
    
        { 
            if (currentBall == "normal")
            {
                NormalBallcurrent();
            }

            if (currentBall == "triple")
            {
                TripleBallcurrent();
            }

            if (currentBall == "big")
            {
                BigBallcurrent();
            }
        }
    }


    public void DisableLaunch()
    {
        disableLaunch = true;
    }

    public void EnableLaunch()
    {
        disableLaunch = false;
    }


    //attach normal ball button
    public void Normalbutton()
    {
        currentBall = "normal";
    }

    //attach triple ball button
    public void Triplebutton()
    {
        currentBall = "triple";
    }

    //attach big ball button
    public void Bigbutton()
    {
        currentBall = "big";
    }

    private void NormalBallcurrent()
    {
        GameObject ballObject = Instantiate(ballNormalPrefab, rb.position + Vector3.down * 0.5f, Quaternion.identity);

        NormalBall currentBallType = ballObject.GetComponent<NormalBall>();
        currentBallType.Launch(lookDirection, 300);
    }

    private void TripleBallcurrent()
    {
        GameObject ballObject = Instantiate(ballTriplePrefab, rb.position + new Vector3(0,-0.5f,0) , Quaternion.identity);
        GameObject ballObject1 = Instantiate(ballTriplePrefab1, rb.position + new Vector3(0,-0.5f,0.3f), Quaternion.identity);
        GameObject ballObject2 = Instantiate(ballTriplePrefab2, rb.position + new Vector3(0, -0.5f,-0.3f), Quaternion.identity);

        TripleBall currentBallType = ballObject.GetComponent<TripleBall>();
        currentBallType.Launch(lookDirection, 300);

        TripleBall currentBallType1 = ballObject1.GetComponent<TripleBall>();
        currentBallType1.Launch(lookDirection + Vector3.forward, 300);

        TripleBall currentBallType2 = ballObject2.GetComponent<TripleBall>();
        currentBallType2.Launch(lookDirection + Vector3.back, 300);
    }

    private void BigBallcurrent()
    {
        GameObject ballObject = Instantiate(ballBigPrefab, rb.position + Vector3.down * 1f, Quaternion.identity);

        BigBall currentBallType = ballObject.GetComponent<BigBall>();
        currentBallType.Launch(lookDirection, 300);
    }


}
