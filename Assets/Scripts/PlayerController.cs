using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rigidbody = null;
    public float moveSpeed = 5f;
    public float jumpForce = 500f;

    private float horizontal = 0f;
    private float vertical = 0f;

    private bool horizontalDown = false;
    private float eulerAngleY = 0f;

    private bool onGround = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        horizontalDown = horizontal != 0;
        eulerAngleY = horizontal < 0 ? 180 : 0;

        transform.position += Vector3.right * moveSpeed * Time.deltaTime * horizontal;

        if (horizontalDown)
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, eulerAngleY, transform.eulerAngles.z);

        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            Jump();
        }
    }

    private void Jump()
    {
        rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Force);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground") || collision.gameObject.layer == 6)
        {
            onGround = true;
            Debug.Log("OnGround");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground") || collision.gameObject.layer == 6)
        {
            onGround = false;
            Debug.Log("Exit Ground");
        }
    }
}
