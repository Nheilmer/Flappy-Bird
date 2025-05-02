using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdDetector : MonoBehaviour
{
    public static Action onCall;

    private void OnTriggerEnter2D(Collider2D collision) {
        onCall?.Invoke();
    }
}
