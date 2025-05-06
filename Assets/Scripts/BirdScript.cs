using System;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    private Constants constants;
    private GUI_Handler gui_handler;
    public bool disabledJump = false;
    public Color BirdColor;
    [SerializeField] public float FlapStrength = 5f;
    [SerializeField] public SpriteRenderer birdSprite;

    public static Action onCall;

    private void Start() {
        constants = GameObject.FindGameObjectWithTag("LogicHandler").GetComponent<Constants>();
        gui_handler = GameObject.FindGameObjectWithTag("LogicHandler").GetComponent<GUI_Handler>();
        string[] preset = SkinSelector.storePresetToArray();
        if (ColorUtility.TryParseHtmlString(preset[0], out BirdColor)) {
            birdSprite.color = BirdColor;
        }
    }

    void Update() {
        if(!constants.StartGame) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                constants.StartGame = true;
                constants.UpdateSpeed();
                constants.initialPause();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && !disabledJump) {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, FlapStrength, 0);
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            onCall?.Invoke();
            constants.PauseGame();
        }

        if (gameObject.transform.position.y > 5.00 || gameObject.transform.position.y < -5.00) {
            destroyBird();
        }
    }

    public void destroyBird() {
        constants.PauseGame();
        gui_handler.DisplayPlayAgain();
        if (constants.StartGame) {
            constants.SaveScore();
        }
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Wall")) {
            destroyBird();
        }
    }
}
