using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompletedScript : MonoBehaviour
{
    [SerializeField]
    private AudioClip endSoundEffect;

    private bool completedGame = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !completedGame)
        {
            AudioSource.PlayClipAtPoint(endSoundEffect, transform.position);
            completedGame = true;
            Invoke("CompleteGameLevel", 2f);
        }
    }

    private void CompleteGameLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
