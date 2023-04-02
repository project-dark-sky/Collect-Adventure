using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This Script represents the moving platforms from point1 to point2
public class MovingPlatformScript : MonoBehaviour
{
    [SerializeField]
    private GameObject[] targetPoints;

    [SerializeField]
    private float speed = 2f;

    [SerializeField]
    private float eps = .1f;

    private int currentPointIndex = 0;

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
        }
        //move towards current point
        transform.position = Vector2.MoveTowards(
            transform.position,
            targetPoints[currentPointIndex].transform.position,
            Time.deltaTime * speed
        );
    }
}
