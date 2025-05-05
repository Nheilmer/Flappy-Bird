using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using TMPro;

public class Constants : MonoBehaviour
{
    private Rigidbody2D bird;
    private BirdScript birdScript;
    private GUI_Handler gui_handler;
    public float WallSpeed = 3f;
    public bool DisableWallSpawn = false;
    public bool IsPaused = false;
    public bool StartGame = false;
    [SerializeField] public GameObject DimPanel;
    [SerializeField] public GameObject ResumeButton;
    [SerializeField] public GameObject RestartButton;
    [SerializeField] public GameObject MainMenuButton;
    [SerializeField] public GameObject ExitToDesktopButtton;

    [SerializeField] public TextMeshProUGUI score;
    [SerializeField] public TextMeshProUGUI time;

    private void Start() {
        bird = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        birdScript = GameObject.FindGameObjectWithTag("Player").GetComponent<BirdScript>();
        gui_handler = GameObject.FindGameObjectWithTag("LogicHandler").GetComponent<GUI_Handler>();
        initialPause();
    }
    
    private void OnEnable() {
        BirdScript.onCall += showPauseMenu;
    }

    private void OnDisable() {
        BirdScript.onCall -= showPauseMenu;
    }

    public void showPauseMenu() {
        ResumeButton.SetActive(!IsPaused);
        RestartButton.SetActive(!IsPaused);
    }

    public void initialPause() {
        if (!StartGame) {
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

    public void PauseGame() {
        IsPaused = !IsPaused;
        DimPanel.SetActive(IsPaused);
        MainMenuButton.SetActive(IsPaused);
        ExitToDesktopButtton.SetActive(IsPaused);
        if (IsPaused) {
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

    public void LoadMainMenu() {
        SceneManager.LoadScene("Menu");
    }

    public void SaveScore() {
        ScoreDataHandler.SaveScore(score.text, time.text);
    }
}
