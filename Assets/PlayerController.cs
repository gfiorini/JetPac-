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


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {

    }

    void FixedUpdate()
    {

        float deltaX = speed * Time.fixedDeltaTime;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            float x = transform.position.x + deltaX;
            Debug.Log("move to x: " + x);
            rb.MovePosition(new Vector2(x, transform.position.y));
            if (!right)
            {
                sr.flipX = !sr.flipX;
                right = true;
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow)){
            float x = transform.position.x - deltaX;
            Debug.Log("move to x: " + x);
            rb.MovePosition(new Vector2(x, transform.position.y));
            if (right)
            {
                sr.flipX = !sr.flipX;
                right = false;
            }
        }


    }
}
