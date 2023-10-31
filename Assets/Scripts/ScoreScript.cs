using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI score; // score text component
    public static int scoreCount; // int counter that turns to string to put into score text

    // Update is called once per frame
    void Update()
    {
        score.text = scoreCount.ToString(); // puts to string the score on screen
    }
}
