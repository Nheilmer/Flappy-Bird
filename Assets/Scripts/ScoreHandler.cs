using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Score_LBL;
    [SerializeField] public int Score = 0;

    private void OnEnable() {
        BirdDetector.onCall += AddScore;
    }

    private void OnDisable() {
        BirdDetector.onCall -= AddScore;
    }

    public void AddScore() {
        Score++;
        Score_LBL.text = "Score: " + Score.ToString();
    }
}
