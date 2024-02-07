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
    [SerializeField] private AudioClip singSFX;
    private AudioSource audioSource;
    bool readyToSing = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpVelocity = new Vector2(0, jumpPower);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canJump && Input.GetKey(KeyCode.Space)) {
            rb.velocity = jumpVelocity;
            canJump = false;
            sing();
        }
    }

    void sing()
    {
        if (readyToSing)
        {
            audioSource.pitch = Random.Range(0.8f, 1.8f);
            audioSource.PlayOneShot(singSFX);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "ground")
        {
            canJump = true;
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "singTrigger")
        {
            readyToSing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "singTrigger")
        {
            readyToSing = false;
        }
    }
}
