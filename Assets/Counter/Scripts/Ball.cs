using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    public class Ball : MonoBehaviour
    {
        public Rigidbody rb;


        // Start is called before the first frame update
        void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        public virtual void Launch(Vector3 direction, float force)
        {
            rb.AddForce(direction * force);
        }

        // If Ball collides with sensor, destroy balls
        public void OnTriggerEnter(Collider other)
        {


            if (other.gameObject.CompareTag("Sensor")) //&& gameManagerX.isGameActive)
            {
                Destroy(gameObject);
                //gameManagerX.UpdateLives(-1);
            }

        }


    }

