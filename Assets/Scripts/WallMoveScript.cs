using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMoveScript : MonoBehaviour
{
    private Constants constants;

    private void Start() {
        constants = GameObject.FindGameObjectWithTag("LogicHandler").GetComponent<Constants>();
    }

    void Update() {
        gameObject.transform.position += (new Vector3(-1, 0)) * constants.WallSpeed * Time.deltaTime;

        if (gameObject.transform.position.x < (-9.5f)) {
            Destroy(gameObject);
        }
    }
}
