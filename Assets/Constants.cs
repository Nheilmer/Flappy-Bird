using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants : MonoBehaviour
{
    private Rigidbody2D bird;
    private BirdScript birdScript;
    public float WallSpeed = 3f;
    public bool DisableWallSpawn = false;
    public bool isPaused = false;

    private void Start() {
        bird = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        birdScript = GameObject.FindGameObjectWithTag("Player").GetComponent<BirdScript>();
    }

    public void PauseGame() {
        isPaused = !isPaused;
        if (isPaused) {
            WallSpeed = 0f;
            DisableWallSpawn = true;
            birdScript.disabledJump = true;
            bird.velocity = Vector2.zero;
            bird.gravityScale = 0f;
        } else {
            WallSpeed = 3f;
            DisableWallSpawn = false;
            bird.gravityScale = 4f;
            birdScript.disabledJump = false;
        }
    }
}
