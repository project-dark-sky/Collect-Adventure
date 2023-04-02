using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private AudioClip deathSoundEffect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Debug.Log("die");
            PlayerDie();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FireTrap"))
        {
            PlayerDie();
            AudioSource.PlayClipAtPoint(deathSoundEffect, transform.position);
        }
    }

    private void PlayerDie()
    {
        rb.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("death");
        AudioSource.PlayClipAtPoint(deathSoundEffect, transform.position);
    }

    private void RestartGameLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
