using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMoveScript : MonoBehaviour
{
    float MoveSpeed = 2f;

    void Update()
    {
        gameObject.transform.position += (new Vector3(-1, 0)) * MoveSpeed * Time.deltaTime;

        if (gameObject.transform.position.x < (-9.5f)) {
            Destroy(gameObject);
        }
    }
}
