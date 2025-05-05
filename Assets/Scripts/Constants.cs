using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;

public class Constants : MonoBehaviour
{
    private static string dataPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
    private static string filePath = Path.Combine(dataPath, "DificultyData.txt");

    private Rigidbody2D bird;
    private BirdScript birdScript;
    private GUI_Handler gui_handler;
    private WallMoveScript wallMoveScript;
    
    private static float easy = 6f;
    private static float hard = 12f;
    private static float easyS = 0.8f;
    private static float hardS = 0.5f;

    // Survival

    public float WallSpeed = 6f;
    public float Spawnrate = 1.5f;

    public float SelectedSpeed = 6f;
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
        UpdateSpeed();
        Debug.Log("Spawnrate: " + Spawnrate);
        bird = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        birdScript = GameObject.FindGameObjectWithTag("Player").GetComponent<BirdScript>();
        gui_handler = GameObject.FindGameObjectWithTag("LogicHandler").GetComponent<GUI_Handler>();
        wallMoveScript = GameObject.FindGameObjectWithTag("LogicHandler").GetComponent<WallMoveScript>();
        initialPause();
    }
    
    public void UpdateSpeed() {
        string dificultyType = File.ReadAllText(filePath);
        if (dificultyType.Equals("1")) {
            SelectedSpeed = easy;
            Spawnrate = easyS;
        }
        if (dificultyType.Equals("2")) {
            SelectedSpeed = hard;
            Spawnrate = hardS;
        }
        if (dificultyType.Equals("3")) {
            SelectedSpeed = DEBG_survival;
            Spawnrate = DEBG_survivalS;
        }
    }
    
    
    private float DEBG_survival = 2.5f;
    private float DEBG_survivalS = 1.2f;
    private float DEBG_DificultyLevelCount = 0;
    private float DEBG_DifficultyLimit = 10;
    private float DEBG_CurrentDifficultyCount = 0;

    public void CheckSurvivalLevel() {
        DEBG_CurrentDifficultyCount++;
        Debug.Log("I love Warthunder");

        if (DEBG_DificultyLevelCount >= 5) return;
        if (DEBG_CurrentDifficultyCount >= DEBG_DifficultyLimit) {
            DEBG_survival += 2.5f;
            DEBG_survivalS -= 0.2f;
            DEBG_DifficultyLimit += 5;
            DEBG_DificultyLevelCount++;
            DEBG_CurrentDifficultyCount = 0;
        }

        WallSpeed = DEBG_survival;
        Spawnrate = DEBG_survivalS;
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
            WallSpeed = SelectedSpeed;
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
            WallSpeed = SelectedSpeed;
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
