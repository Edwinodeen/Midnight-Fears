using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour ///Leos kod
{

    public int playerScore;
    public Text scoreText;

    void Start()
    {
        scoreText = GetComponent<Text>();
    }

    void Update()
    {
        scoreText.text = "Gathered loot - " + playerScore;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Loot")
        {
            scoreText.text = "Gathered loot - " + playerScore; 
        }
    }
}