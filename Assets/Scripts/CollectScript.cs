using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectScript : MonoBehaviour
{
    private const int PlayerLayer = 3;
    private LogicManagerScript logic;

    [SerializeField]
    private AudioClip collectSoundEffect;

    private void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManagerScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == PlayerLayer)
        {
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(collectSoundEffect, transform.position);

            logic.addScore(1);
        }
    }
}
