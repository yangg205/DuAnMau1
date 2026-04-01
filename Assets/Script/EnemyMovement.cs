using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    private Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody2D.velocity = new Vector2(moveSpeed, 0);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        moveSpeed *= -1;
        //xoay huong quai vat
        transform.localScale = new Vector2(-(Mathf.Sign(rigidbody2D.velocity.x)), 1f);
        if (other.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}
