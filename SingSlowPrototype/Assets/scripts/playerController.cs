using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class playerController : MonoBehaviour
{
    public float jumpPower = 1;
    private Rigidbody2D rb;
    private Vector2 jumpVelocity;
    private bool canJump = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpVelocity = new Vector2(0, jumpPower);
    }

    // Update is called once per frame
    void Update()
    {
        if (canJump && Input.GetKey(KeyCode.Space)) {
            rb.velocity = jumpVelocity;
            canJump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
    }
}
