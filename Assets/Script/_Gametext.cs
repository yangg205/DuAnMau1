/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gametext : MonoBehaviour
{
    [SerializeField] float coinValue = 100;
    *//*[SerializeField] AudioClip coinPickupSFX;*//*

    // đồng xu đã được nhặt chưa
    private bool isCollected = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            isCollected = true;
            // tăng điểm
            FindObjectOfType<GameController>().AddScore((int)coinValue);
           *//* AudioSource.PlayClipAtPoint(coinPickupSFX, Camera.main.transform.position);*//*
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
*/