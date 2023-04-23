using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This Script represents what happen when the finished a level
public class LevelCompletedScript : MonoBehaviour
{
    [SerializeField]
    private AudioClip endSoundEffect;

    private bool completedGame = false;
    private const string playerTag = "Player";
    private float dely = 2f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == playerTag && !completedGame)
        {
            AudioSource.PlayClipAtPoint(endSoundEffect, transform.position);
            completedGame = true;
            Invoke("CompleteGameLevel", dely); // invoke the function after dealy of 2f
        }
    }

    private void CompleteGameLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // go to the next lvl
    }
}
