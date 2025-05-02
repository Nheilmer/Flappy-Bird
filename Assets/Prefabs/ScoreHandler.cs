using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    [SerializeField] public int Score = 0;

    private void OnEnable() {
        BirdDetector.onCall += AddScore;
    }

    private void OnDisable() {
        BirdDetector.onCall -= AddScore;
    }

    public void AddScore() {
        Score++;
        Debug.Log(Score);
    }
}
