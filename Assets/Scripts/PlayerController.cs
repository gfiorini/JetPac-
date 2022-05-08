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

    private Rigidbody2D rb;

    private SpriteRenderer sr;

    private IInputController ic;



    private void Awake()
    {
        
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        ic = new DefaultController();
        
    }

    
    void Update()
    {

    }

    void FixedUpdate()
    {

        if (ic.MoveRight())
        {
            rb.AddForce(Vector2.right * horizontalStrength, ForceMode2D.Force);
            if (!facingRight)
            {
                sr.flipX = !sr.flipX;
                facingRight = true;
            }
        }

        if (ic.MoveLeft())
        {
            rb.AddForce(- Vector2.right * horizontalStrength, ForceMode2D.Force);
            if (facingRight)
            {
                sr.flipX = !sr.flipX;
                facingRight = false;
            }
        }

        if (ic.Jump())
        {
            
            rb.AddForce(transform.up * verticalStrength, ForceMode2D.Impulse);

        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
