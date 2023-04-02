using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ActiveTrampScript : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private float jumpForce = 10f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            animator.SetTrigger("jump");

            collision.gameObject
                .GetComponent<Rigidbody2D>()
                .AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
