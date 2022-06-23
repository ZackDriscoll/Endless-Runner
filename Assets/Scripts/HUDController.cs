using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    //Reference to score text
    public Text scoreText;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "X " + GameManager.instance.score.ToString();
    }
}
