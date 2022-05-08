using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private bool right = true;

    [SerializeField]
    private float speed = 20;

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

        float deltaX = speed * Time.fixedDeltaTime;

        if (ic.MoveRight())
        {
            float x = transform.position.x + deltaX;
            rb.MovePosition(new Vector2(x, transform.position.y));
            if (!right)
            {
                sr.flipX = !sr.flipX;
                right = true;
            }
        }

        if (ic.MoveLeft())
        {
            float x = transform.position.x - deltaX;
            rb.MovePosition(new Vector2(x, transform.position.y));
            if (right)
            {
                sr.flipX = !sr.flipX;
                right = false;
            }
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
