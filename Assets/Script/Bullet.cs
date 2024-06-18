using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other )
    {
        // bien mat
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other )
    {
        // bien mat 
        Destroy(gameObject);
    }
}
