using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 1 asset usage
public class Coin : MonoBehaviour
{
   /* [SerializeField] AudioClip coinPickupSFX;*/
    // Event function
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
