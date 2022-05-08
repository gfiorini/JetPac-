using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float verticalStrength = 2f;

    [SerializeField]
    private float horizontalStrength = 0.5f;

    private bool facingRight = true;

    private Rigidbody2D rigidBody;

    private SpriteRenderer spriteRenderer;

    private IInputController inputController;

    private Animator animator;

    private void Awake()
    {
        
    }

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        inputController = new DefaultController();
    }

    
    void Update()
    {

    }

    void FixedUpdate()
    {

        if (inputController.MoveRight())
        {
            rigidBody.AddForce(Vector2.right * horizontalStrength, ForceMode2D.Force);
            if (!facingRight)
            {
                spriteRenderer.flipX = !spriteRenderer.flipX;
                facingRight = true;
            }
        }

        if (inputController.MoveLeft())
        {
            rigidBody.AddForce(-Vector2.right * horizontalStrength, ForceMode2D.Force);
            if (facingRight)
            {
                spriteRenderer.flipX = !spriteRenderer.flipX;
                facingRight = false;
            }
        }

        DoFly(inputController.Jump());
    }

    private void DoFly(bool flag)
    {
        if (flag)
        {
            rigidBody.AddForce(transform.up * verticalStrength, ForceMode2D.Impulse);
        }

        animator.SetBool("isFlying", flag);
    }

   
}
