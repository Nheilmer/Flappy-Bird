using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class GUI_Handler : MonoBehaviour
{
    float currLimit = 0;
    int Limit = 60;

    int TimeDelayUpdate = 1;
    float currDelayUpdate = 0;

    int Second = 0;
    int Minute = 0;

    int Score = 0;

    [SerializeField] private TextMeshProUGUI Time_LBL;

    private void FixedUpdate() {
        currLimit += Time.deltaTime;
        currDelayUpdate += Time.deltaTime;
        Second = (int) currLimit;
        
        if (currDelayUpdate > TimeDelayUpdate) {
            currDelayUpdate = 0;
            updateTimerLabel(Second, Minute);
        }

        if (currLimit > Limit) {
            currLimit = 0;
            Minute++;
        }
    }
    private void updateTimerLabel(int Seconds, int Minutes) {
        Time_LBL.text = Minutes + ":" + Seconds;
    }
}
