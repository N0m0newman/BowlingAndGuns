using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class scoreTracker : MonoBehaviour
{
    int score;
    [SerializeField]
    TextMeshProUGUI scoreText;

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
