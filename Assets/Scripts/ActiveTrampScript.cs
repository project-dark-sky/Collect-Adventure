using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// This Script represents what happen with player collide with the trampoline

public class ActiveTrampScript : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private float jumpForce = 10f;

    const string playerTag = "Player";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == playerTag)
        {
            animator.SetTrigger("jump"); // triger the animation
            collision.gameObject // player jump
                .GetComponent<Rigidbody2D>()
                .AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
