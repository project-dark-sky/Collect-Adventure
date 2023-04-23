using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This Script represents the player life durning the game
public class PlayerLife : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private AudioClip deathSoundEffect;

    // if the player collide with a trap
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap") || collision.gameObject.CompareTag("Enemy"))
        {
            PlayerDie();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FireTrap"))
        {
            PlayerDie();
        }
    }

    private void PlayerDie()
    {
        rb.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("death"); // triger the death animation
        AudioSource.PlayClipAtPoint(deathSoundEffect, transform.position);
    }

    //inside the animation after seconds this function will invoke
    private void RestartGameLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
