using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMoveScript : MonoBehaviour
{
    float MoveSpeed = 2f;

    void Update()
    {
        Vector3 movDir = new Vector2(-1, 0);
        gameObject.transform.position += movDir * MoveSpeed * Time.deltaTime;
    }
}
