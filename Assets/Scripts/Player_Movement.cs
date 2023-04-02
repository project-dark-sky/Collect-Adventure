using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// This Script represents the player movments inside the game

public class Player_Movement : MonoBehaviour
{
    [SerializeField]
    private float speed = 14f;

    [SerializeField]
    private float jumpForce = 4f;

    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private SpriteRenderer sb;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private BoxCollider2D boxColl;

    [SerializeField]
    private LayerMask jumpableGround;

    [SerializeField]
    private AudioSource jumpSoundEffect;

    private const float eps = .1f;

    public InputAction moveUp = new InputAction(type: InputActionType.Button);
    public InputAction moveLeft = new InputAction(type: InputActionType.Button);
    public InputAction moveRight = new InputAction(type: InputActionType.Button);

    enum MovmentState
    {
        IDLE,
        RUNNING,
        JUMPING,
        FALLING,
        NOTHING
    }

    private void Start()
    {
        moveUp.Enable();
        moveLeft.Enable();
        moveRight.Enable();
    }

    private void Update()
    {
        MovmentState state = MovmentState.NOTHING;

        if (moveUp.WasPerformedThisFrame() && isGrounded())
        {
            jumpSoundEffect.Play();
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        if (moveRight.IsPressed())
        {
            transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
            sb.flipX = false;
            state = MovmentState.RUNNING;
        }
        if (moveLeft.IsPressed())
        {
            transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;
            sb.flipX = true;
            state = MovmentState.RUNNING;
        }

        if (!moveRight.IsPressed() && !moveLeft.IsPressed() && !moveUp.IsPressed())
        {
            state = MovmentState.IDLE;
        }

        if (rb.velocity.y > eps)
        {
            state = MovmentState.JUMPING;
        }
        else if (rb.velocity.y < -eps)
        {
            state = MovmentState.FALLING;
        }

        animator.SetInteger("state", (int)state);
    }

    private bool isGrounded()
    {
        //box cast
        // detect if boxcast is overlaping with the ground
        return Physics2D.BoxCast(
            boxColl.bounds.center,
            boxColl.bounds.size,
            0f,
            Vector2.down,
            .1f,
            jumpableGround
        );
    }
}
