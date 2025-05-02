using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawnScrip : MonoBehaviour
{
    [SerializeField] public GameObject WallPrefab;
    [SerializeField] public float Spawnrate = 1.5f;
    private float currSpawnRate = 0;
    private void FixedUpdate()
    {
        currSpawnRate += Time.deltaTime;
        if (currSpawnRate > Spawnrate) {
            float[] x_y = GetRandVal();
            Instantiate (WallPrefab, new Vector2(gameObject.transform.position.x,x_y[1]), Quaternion.identity);
            currSpawnRate = 0;
        }
    }

    private float[] GetRandVal() {
        float x = Random.Range(6.5f, -6.5f);
        float y = Random.Range(6.5f, -6.5f);
        float[] randVals = new float[2];
        randVals[0] = x;
        randVals[1] = y;
        return randVals;
    }
}
