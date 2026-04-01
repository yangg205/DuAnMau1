using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float coinValue = 100;
    [SerializeField] AudioClip coinPickupSFX;
    //dong xu da duoc nhat hay chua
    private bool isCollected = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            isCollected = true;
            //tang diem
            FindObjectOfType<GameController>().AddScore((int)coinValue);
            AudioSource.PlayClipAtPoint(coinPickupSFX, Camera.main.transform.position);
            Destroy(gameObject);
        }
    }
}
