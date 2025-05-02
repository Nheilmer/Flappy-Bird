using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    private Constants constants;
    private GUI_Handler gui_handler;
    public bool disabledJump = false;
    [SerializeField] public float FlapStrength = 5f;

    public static Action onCall;

    private void Start() {
        constants = GameObject.FindGameObjectWithTag("LogicHandler").GetComponent<Constants>();
        gui_handler = GameObject.FindGameObjectWithTag("LogicHandler").GetComponent<GUI_Handler>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && !disabledJump) {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, FlapStrength, 0);
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            onCall?.Invoke();
            constants.PauseGame();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Wall")) {
            constants.PauseGame();
            gui_handler.DisplayPlayAgain();
            Destroy(this.gameObject);
        }
    }
}
