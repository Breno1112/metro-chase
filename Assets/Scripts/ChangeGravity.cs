using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGravity : MonoBehaviour
{
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundDetection;
    private Rigidbody2D rb;
    private bool touchingGround;
    private bool canSwitch;

    // Start is called before the first frame update
    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        touchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundDetection);
    }

    // Update is called once per frame
    void Update(){
        if (!canSwitch && touchingGround) {
            canSwitch = true;
        }
        if (Input.touches.Length == 1 && Input.GetTouch(0).phase == TouchPhase.Began && canSwitch) {
            rb.gravityScale *= -1;
            canSwitch = false;
        }
    }
}
