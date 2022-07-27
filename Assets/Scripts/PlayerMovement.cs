using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float velocity;
    private Rigidbody2D rb;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        rb.velocity = new Vector2(velocity, 0);
    }


    private void OnCollisionEnter2D(Collision2D other) {
        if (other.transform.tag == "Enemy") {
            Debug.Log("Entered collision");
        }
    }
}
