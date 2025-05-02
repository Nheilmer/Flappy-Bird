using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Constants : MonoBehaviour
{
    private Rigidbody2D bird;
    private BirdScript birdScript;
    private GUI_Handler gui_handler;
    public float WallSpeed = 3f;
    public bool DisableWallSpawn = false;
    public bool isPaused = false;
    [SerializeField] public GameObject DimPanel;
    [SerializeField] public GameObject ResumeButton;

    private void Start() {
        bird = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        birdScript = GameObject.FindGameObjectWithTag("Player").GetComponent<BirdScript>();
        gui_handler = GameObject.FindGameObjectWithTag("LogicHandler").GetComponent<GUI_Handler>();
    }
    
    private void OnEnable() {
        BirdScript.onCall += showPauseMenu;
    }

    private void OnDisable() {
        BirdScript.onCall -= showPauseMenu;
    }

    public void showPauseMenu() {
        ResumeButton.SetActive(!isPaused);
    }

    public void PauseGame() {
        isPaused = !isPaused;
        DimPanel.SetActive(isPaused);
        if (isPaused) {
            WallSpeed = 0f;
            DisableWallSpawn = true;
            birdScript.disabledJump = true;
            bird.velocity = Vector2.zero;
            bird.gravityScale = 0f;
            gui_handler.IsPause = true;
        } else {
            WallSpeed = 3f;
            DisableWallSpawn = false;
            bird.gravityScale = 4f;
            birdScript.disabledJump = false;
            gui_handler.IsPause = false;
        }
    }

}
