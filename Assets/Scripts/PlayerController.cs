using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 500f;

    private float horizontal = 0f;
    private float vertical = 0f;

    private bool horizontalDown = false;
    private float eulerAngleY = 0f;

    private bool onGround = false;
    private bool onJumpKey = false;
    private bool firtJump = true;

    private Rigidbody2D rigidbody = null;
    private Animator characterAnimator = null;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        characterAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        horizontalDown = horizontal != 0;
        eulerAngleY = horizontal < 0 ? 180 : 0;

        transform.position += Vector3.right * moveSpeed * Time.deltaTime * horizontal;

        if (horizontalDown)
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, eulerAngleY, transform.eulerAngles.z);

        onJumpKey = Input.GetKeyDown(KeyCode.Space) && !Input.GetKeyUp(KeyCode.Space);

        if (onJumpKey && onGround)
        {
            Jump();
        }
        SetAnimation();
    }

    private void SetAnimation()
    {
        if (horizontalDown)
            characterAnimator.SetBool("Run", true);
        else
        {
            if (onGround)
                characterAnimator.SetBool("Run", false);
        }

        if (onJumpKey && onGround)
            characterAnimator.SetTrigger("Jump");
    }

    private void Jump()
    {
        rigidbody.AddForce(transform.up * jumpForce * Time.deltaTime, ForceMode2D.Impulse);

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground") || collision.gameObject.layer == 6)
        {
            if (!firtJump)
                characterAnimator.SetTrigger("Idle");

            onGround = true;
            firtJump = false;
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
