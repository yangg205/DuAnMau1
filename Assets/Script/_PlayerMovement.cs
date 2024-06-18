/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;


public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpSpeed = 10f;
    [SerializeField] float climbSpeed = 1f;
*//*    private Rigidbody2D rigidbody2D;
*//*    Vector2 moveInput;
    private Animator animator;
    CapsuleCollider2D capsuleCollider2D;
    private float gravotyScaleAtStart;
    private bool isAlive;
    [SerializeField] GameObject Bullet;
    [SerializeField] Transform Gun;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
*//*        gravityScaleAtStart = rigidbody2D.gravityScale;
*//*        isAlive = true;
    }
    void Update()
    {
        Run();
        FlipSprite();
        ClimbLadder();
        Die();
    }
    void OnMove(InputValue value)
    {
        if (!isAlive)
        {
            return;
        }
        moveInput = value.Get<Vector2>();
        Debug.Log("===> Move Input: " + moveInput);
    }
    void OnJump(InputValue value)
    {
        if (!isAlive)
        {
            return ;
        }
        var isTouchingGround = capsuleCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground"));
        if (!isTouchingGround) return;
        if (value.isPressed)
        {
            Debug.Log(">>>>> Jump ");
            GetComponent<Rigidbody2D>().velocity += new Vector2(0, jumpSpeed);
        }
    }
    void OnFire()
    {
        if (!isAlive)
        {
            return;
        }
        Debug.Log("===> Fire");
        var oneBullet = Instantiate(Bullet, Gun.position, transform.rotation);
        if(transform.localScale.x < 0)
        {
            oneBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-15, 0);
        }
        else
        {
            oneBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(15, 0);
        }
        Destroy(oneBullet, 2);
    }
    void Run()
    {
        var moveVelocity = new Vector2(moveInput.x * moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        GetComponent<Rigidbody2D>().velocity = moveVelocity;

        bool playerhorizontalSpeed = Mathf.Abs(moveInput.x) > Mathf.Epsilon;
        animator.SetBool("isRun", playerhorizontalSpeed);
    }
    // Abs: gia tri tuyet doi
    // Sign: dau cua gia tri
    // Epsilon: gia tri nho nhat co the so sanh
    // xoay huong nhan vat theo chieu chuyen dong
    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(GetComponent<Rigidbody2D>().velocity.x), 1f);
        }
    }
    void ClimbLadder()
    {
        var isTouchingLadder = capsuleCollider2D.IsTouchingLayers(LayerMask.GetMask("Climbing"));
        if (!isTouchingLadder)
        {
            GetComponent<Rigidbody2D>().gravityScale = gravityScaleAtStart;
            return;
        }
        var climbVelocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, moveInput.y * climbSpeed);
        GetComponent<Rigidbody2D>().velocity = climbVelocity;

        var playerHasVerticalSpeed = Mathf.Abs(moveInput.y) > Mathf.Epsilon;
        animator.SetBool("isClimb", playerHasVerticalSpeed);
        //tat gravity khi leo thang
        GetComponent<Rigidbody2D>().gravityScale = 0;
    }
    void Die()
    {
        var isTouchingEnemy = capsuleCollider2D.IsTouchingLayers(LayerMask.GetMask("Enemy", "Trap"));
        if(isTouchingEnemy)
        {
            isAlive = false;
            animator.SetTrigger("Dying");
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            FindObjectOfType<GameController>().ProcessPlayerDeath;
        }
    }
}
*/