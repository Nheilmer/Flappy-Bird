using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    [SerializeField] public float FlapStrength = 5f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, FlapStrength, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall")) {
            Destroy(this.gameObject);
        }
    }
}
