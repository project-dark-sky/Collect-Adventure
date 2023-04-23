using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This Script represents the Enemy Zone.

public class ZoneScript : MonoBehaviour
{
    const string playerTag = "Player";

    private MovingEnemy enemyScript;
    private ShootingScript shootingScript;
    const Boolean enable = true;
    const Boolean disable = false;

    [SerializeField]
    private GameObject Enemy;

    private void Start()
    {
        //enemyScript = GameObject.FindGameObjectWithTag("Enemy").GetComponent<MovingEnemy>();
        enemyScript = Enemy.GetComponent<MovingEnemy>();
        shootingScript = Enemy.GetComponent<ShootingScript>();
    }

    //if a player enters the zone, execute what the enemy should do.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag))
        {
            if (enemyScript != null)
            {
                enemyScript.ExecuteZoneBehavior(enable);
            }
            if (shootingScript != null)
            {
                shootingScript.ExecuteZoneBehavior(enable);
            }
        }
    }

    //if a player exists the zone, execute what the enemy should do.
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag))
        {
            if (enemyScript != null)
            {
                enemyScript.ExecuteZoneBehavior(disable);
            }
            if (shootingScript != null)
            {
                shootingScript.ExecuteZoneBehavior(disable);
            }
        }
    }
}
