using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This Script represents what happen when an object collide with bullet object.
public class BulletCollisionScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject)
        {
            Destroy(gameObject);
        }
    }
}
