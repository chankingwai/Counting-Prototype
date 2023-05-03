using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public Text scoreText;
    
    public int score;


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        
    }

    // Update is called once per frame
    void Update()
    {


    }

    // Update score with value from balls get into slot
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "score: " + score.ToString();
    }
}
