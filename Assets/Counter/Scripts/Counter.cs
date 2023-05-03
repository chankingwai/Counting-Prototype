using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public GameManager gameManager;

    [SerializeField] public int pointValue;
    
    private void Start()
    {
    
    }

   

    public void OnTriggerEnter(Collider other)
    {

        //add score to gameManager
        gameManager.UpdateScore(pointValue);

    }
}
