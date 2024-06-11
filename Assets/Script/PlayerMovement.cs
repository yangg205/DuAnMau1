using System.Collections;
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
    public GameObject bulletprefabs;
    public Transform guntransform;
    private bool right = true;
    private Rigidbody2D rigidbody2D;
    Vector2 moveInput;
    private Animator animator;
    CapsuleCollider2D capsuleCollider2D;
    private float gravityScaleAtStart;
    [SerializeField]
    private static int lives = 3;
    [SerializeField]
    private GameObject[] _livesimage;
    [SerializeField]
    private GameObject _Gameover;
    [SerializeField]
    private GameObject _Win;
    boss _boss;
    void Start()
    {
        _boss = FindObjectOfType<boss>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        gravityScaleAtStart = rigidbody2D.gravityScale;
    }

    // Update is called once per frame
    private void Fire()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            //tao ra dan
            var oneBullet = Instantiate(bulletprefabs, guntransform.position, Quaternion.identity);
            //dan bay
            if (moveInput.x == -1) right = false;
            var velocity = new Vector2(5f, 0);
            if (right == false)
            {
                velocity = new Vector2(-5f, 0);
            }

            oneBullet.GetComponent<Rigidbody2D>().velocity = velocity;
            Destroy(oneBullet, 2f);//huy dien sau 2s

        }
    }
    void Update()
    {
        Run();
        FlipSprite();
        ClimbLadder();
        Fire();
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
        if (playerHasHorizontalSpeed)
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
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("quai"))
        {
            //bat su kien nhan vat cham quai
            //mat 1 mang reload lai mang choi
            lives -= 1;
            // xoa 1 anh trai tim
            for (int i = 0; i < 3; i++)
            {
                if (i < lives)
                {
                    _livesimage[i].SetActive(true);
                }
                else
                {
                    _livesimage[i].SetActive(false);
                }
            }
            if (lives == 0)
            {
                //hien panel
                _Gameover.SetActive(true);
                //dung game
                Time.timeScale = 0;
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            
        }
    }
}
