using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        transform.position = Vector2.MoveTowards(
            transform.position,
            targetPoints[currentPointIndex].transform.position,
            Time.deltaTime * speed
        );
    }
}
