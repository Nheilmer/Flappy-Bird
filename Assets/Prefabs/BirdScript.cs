using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    private Constants constants;
    public bool disabledJump = false;
    [SerializeField] public float FlapStrength = 5f;

    private void Start() {
        constants = GameObject.FindGameObjectWithTag("LogicHandler").GetComponent<Constants>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && !disabledJump) {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, FlapStrength, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Wall")) {
            constants.WallSpeed = 0;
            constants.DisableWallSpawn = true;
            Destroy(this.gameObject);
        }
    }
}
