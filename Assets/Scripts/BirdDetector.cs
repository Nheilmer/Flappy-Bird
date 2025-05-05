using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdDetector : MonoBehaviour
{
    public static Action onCall;
    private Constants constants;

    private void Start()
    {
        constants = GameObject.FindGameObjectWithTag("LogicHandler").GetComponent<Constants>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        onCall?.Invoke();
        if (constants.DEBG_IsSurvival) {
            constants.CheckSurvivalLevel();
        }
    }
}
