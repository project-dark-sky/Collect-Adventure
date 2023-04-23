using UnityEngine;

// This Script enable object to move toward a targetpoint

public class Mover : MonoBehaviour
{
    [Tooltip("Move an object towards a point")]
    [SerializeField]
    Vector3 targetPoint;

    [SerializeField]
    private float speed = 10f;

    [SerializeField]
    void Update()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            targetPoint,
            Time.deltaTime * speed
        );
    }

    public void setTargetPoint(Vector3 tagetPoint)
    {
        this.targetPoint = tagetPoint;
    }
}
