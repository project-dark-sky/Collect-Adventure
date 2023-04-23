using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This Script represents what happen when player collide with a fruit.

public class CollectScript : MonoBehaviour
{
    private const int PlayerLayer = 3;
    private const string logicScriptTag = "Logic";
    private LogicManagerScript logic;

    [SerializeField]
    private AudioClip collectSoundEffect;

    private void Start()
    {
        logic = GameObject.FindGameObjectWithTag(logicScriptTag).GetComponent<LogicManagerScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == PlayerLayer)
        {
            Destroy(gameObject); // destroy the fruit
            AudioSource.PlayClipAtPoint(collectSoundEffect, transform.position); //collect sound
            logic.addScore(1); //increamnt the score by 1
        }
    }
}
