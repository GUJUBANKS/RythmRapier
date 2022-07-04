using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static int score = 0;
    public static int missedBox = 0;
    [SerializeField]
    private TextMeshProUGUI ScoreText;  
    private void Update()
    {
        ScoreText.text = "Score:" + score;  // just manages score and missed count
    }

}
