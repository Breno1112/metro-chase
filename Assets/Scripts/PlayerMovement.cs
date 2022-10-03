using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float velocity;
    public Animator animator;

    private Rigidbody2D rb;
    private bool colliding = false;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (Input.touches.Length == 1 && Input.GetTouch(0).phase == TouchPhase.Began && this.colliding) {
            rb.gravityScale *= -1;
        }
    }

    private void FixedUpdate() {
        rb.velocity = new Vector2(velocity, 0);
    }


    private void OnCollisionEnter2D(Collision2D other) {
        this.colliding = true;
        this.resetAllVariables();
        Debug.Log("OnCollisionEnter2d is " + other.gameObject.tag);
        if (other.transform.tag == "Enemy") {
            GameManager.IsGameOver = true;
            gameObject.SetActive(false);
        } else if (other.transform.tag == "Ground") {
            animator.SetBool("Player_running", true);
        } else if (other.transform.tag == "Ceiling") {
            animator.SetBool("Player_running_ceiling", true);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        this.colliding = false;
        this.resetAllVariables();
        Debug.Log("on trigger exit is" + other.gameObject.tag);
        if (other.gameObject.tag == "Ground") {
            animator.SetBool("Player_jumping_to_ceiling", true);
        } else  if (other.gameObject.tag == "Ceiling") {
            animator.SetBool("Player_jumping_to_floor", true);
        }
    }

    private void resetAllVariables() {
        animator.SetBool("Player_running", false);
        animator.SetBool("Player_jumping_to_ceiling", false);
        animator.SetBool("Player_running_ceiling", false);
        animator.SetBool("Player_jumping_to_floor", false);
    }
}
