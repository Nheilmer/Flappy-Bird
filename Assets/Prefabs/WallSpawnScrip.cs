using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawnScrip : MonoBehaviour
{
    [SerializeField] public GameObject WallPrefab;
    [SerializeField] public float Spawnrate = 1.5f;
    private float currSpawnRate = 0;

    private void Start()
    {
        Instantiate (WallPrefab, new Vector2(9.5f, GetRandVal()), Quaternion.identity);
    }

    private void FixedUpdate()
    {
        currSpawnRate += Time.deltaTime;
        if (currSpawnRate > Spawnrate) {
            float T_D = GetRandVal();
            Instantiate (WallPrefab, new Vector2(9.5f, T_D), Quaternion.identity);
            currSpawnRate = 0;
        }
    }

    private float GetRandVal() {
        float rand = Random.Range(1.4f, -1.4f);
        return rand;
    }
}
