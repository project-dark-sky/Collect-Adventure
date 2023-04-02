using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movment : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    // Update is called once per frame
    private void Update()
    {
        transform.position = new Vector3(
            target.position.x,
            target.position.y,
            transform.position.z
        );
    }
}
