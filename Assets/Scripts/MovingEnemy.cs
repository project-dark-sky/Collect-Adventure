using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This Script represents the enemy that moves from start point to end point.
public class MovingEnemy : MonoBehaviour
{
    [SerializeField]
    private GameObject[] targetPoints;

    [SerializeField]
    private float speed = 2f;

    [SerializeField]
    private float eps = .1f;

    [SerializeField]
    private SpriteRenderer sb;

    [SerializeField]
    private Animator animator;

    private int currentPointIndex = 0;
    private Boolean isInZone;

    void Update()
    {
        // check the distance from the platform and current point
        if (
            Vector2.Distance(targetPoints[currentPointIndex].transform.position, transform.position)
            < eps
        )
        {
            currentPointIndex++;
            if (currentPointIndex >= targetPoints.Length)
            {
                currentPointIndex = 0;
            }
            flipEnemy(currentPointIndex);
        }

        MoveEnemy();
    }

    //move towards current point
    void MoveEnemy()
    {
        if (isInZone)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                targetPoints[currentPointIndex].transform.position,
                Time.deltaTime * speed
            );
        }
    }

    void flipEnemy(int currentPoint)
    {
        if (currentPoint == 0)
        {
            sb.flipX = false;
        }
        else
        {
            sb.flipX = true;
        }
    }

    //this function executed from ZoneScript whenever a player leave or enters the specfic enemy zone.
    public void ExecuteZoneBehavior(Boolean entersZone)
    {
        isInZone = entersZone;
        animator.SetBool("isMoving", entersZone);
    }
}
