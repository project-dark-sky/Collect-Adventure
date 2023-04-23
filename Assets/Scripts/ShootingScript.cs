using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// This Script represents the enemy shooting.
public class ShootingScript : MonoBehaviour
{
    [SerializeField]
    private GameObject BulletObject;

    private Boolean playerInsideZone = false;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    float shootRate = 3f;

    [SerializeField]
    float nextTimetoShoot = 0f;

    [SerializeField]
    private GameObject shootTarget;

    [SerializeField]
    private float awayFromShooter = -1f;

    public void ExecuteZoneBehavior(Boolean insideTheZone)
    {
        playerInsideZone = insideTheZone;
        animator.SetBool("isShooting", insideTheZone);
    }

    //spawn bullet objects and let them move towards a target point.
    protected virtual GameObject SpawnBullet()
    {
        Vector3 positionOfSpawnedObject = new Vector3(
            transform.position.x - awayFromShooter,
            transform.position.y,
            transform.position.z
        );
        Quaternion rotationOfSpawnedObject = Quaternion.identity;
        GameObject newObject = Instantiate(
            BulletObject,
            positionOfSpawnedObject,
            rotationOfSpawnedObject
        );

        Mover newObjectMover = newObject.GetComponent<Mover>();
        if (newObjectMover)
        {
            newObjectMover.setTargetPoint(shootTarget.transform.position);
        }

        nextTimetoShoot = Time.time + 1f / shootRate;
        return newObject;
    }

    void Update()
    {
        if (Time.time >= nextTimetoShoot && playerInsideZone) //delay
        {
            SpawnBullet();
        }
    }
}
