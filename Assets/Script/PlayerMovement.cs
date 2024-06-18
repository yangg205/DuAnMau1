using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpSpeed = 10f;
    [SerializeField] float climbSpeed = 0.25f;
    private Rigidbody2D rigidbody2D;
    Vector2 moveInput;
    private Animator animator;
    CapsuleCollider2D capsuleCollider2D;
    private float gravityScaleAtStart;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        gravityScaleAtStart = rigidbody2D.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        FlipSprite();
        ClimbLadder();
    }
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        Debug.Log(">>>>> Move Input: " + moveInput);
    }
    void OnJump(InputValue value)
    {
        var isTouchingGround = capsuleCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground"));
        if (!isTouchingGround) return;
        if (value.isPressed)
        {
            Debug.Log(">>>>> Jump ");
            rigidbody2D.velocity += new Vector2(0, jumpSpeed);
        }
    }
    void Run()
    {
        var moveVelocity = new Vector2(moveInput.x * moveSpeed, rigidbody2D.velocity.y);
        rigidbody2D.velocity = moveVelocity;

        bool playerhorizontalSpeed = Mathf.Abs(moveInput.x) > Mathf.Epsilon;
        animator.SetBool("isRun", playerhorizontalSpeed);
    }
    // Abs: gia tri tuyet doi
    // Sign: dau cua gia tri
    // Epsilon: gia tri nho nhat co the so sanh
    // xoay huong nhan vat theo chieu chuyen dong
    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(rigidbody2D.velocity.x) > Mathf.Epsilon;
        if(playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rigidbody2D.velocity.x), 1f);
        }
    }
    void ClimbLadder()
    {
        var isTouchingLadder = capsuleCollider2D.IsTouchingLayers(LayerMask.GetMask("Climbing"));
        if (!isTouchingLadder)
        {
            rigidbody2D.gravityScale = gravityScaleAtStart;
            return;
        }
        var climbVelocity = new Vector2(rigidbody2D.velocity.x, moveInput.y * climbSpeed);
        rigidbody2D.velocity = climbVelocity;
        
        var playerHasVerticalSpeed = Mathf.Abs(moveInput.y) > Mathf.Epsilon;
        animator.SetBool("isClimb", playerHasVerticalSpeed);
        //tat gravity khi leo thang
        rigidbody2D.gravityScale = 0;
    }
}
