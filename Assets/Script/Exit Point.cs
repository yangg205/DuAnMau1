/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitPoint : MonoBehaviour
{
    private float levelLoadDelay = 2f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(LoadNextLevel());
        }
    }

    // Coroutine: là một hàm chạy độc lập với các hàm khác,
    // có thể chạy trong nền, có thể dừng lại và tiếp tục sau đó
    private IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(levelLoadDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

*/