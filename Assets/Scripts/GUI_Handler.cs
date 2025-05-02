using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GUI_Handler : MonoBehaviour
{
    float currLimit = 0;
    int Limit = 60;

    int TimeDelayUpdate = 1;
    float currDelayUpdate = 0;

    int Second = 0;
    int Minute = 0;

    public bool IsPause = false;
    public bool IsPlayAgain = false;

    [SerializeField] private TextMeshProUGUI Time_LBL;
    [SerializeField] public Button PlayAgain_BTN;

    private void FixedUpdate() {
        if (!IsPause) {
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
    }

    public void DisplayPlayAgain() {
        IsPlayAgain = !IsPlayAgain;
        PlayAgain_BTN.gameObject.SetActive(IsPlayAgain);
    }

    public void PlayAgain() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void updateTimerLabel(int Seconds, int Minutes) {
        Time_LBL.text = TwoDIgitConverter(Minutes) + ":" + TwoDIgitConverter(Seconds);
    }

    private string TwoDIgitConverter(int Digit) {
        return (Digit < 10) ? "0" + Digit : Digit.ToString();
    }
}
