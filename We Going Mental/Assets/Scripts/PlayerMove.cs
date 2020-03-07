using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;
    private Vector2 moveVector;
    private int h, v = 0;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            v = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            v = -1;
        } else
        {
            v = 0;
        }
        if (Input.GetKey(KeyCode.A))
        {
            h = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            h = 1;
        } else
        {
            h = 0;
        }
        moveVector = new Vector2(h, v).normalized * speed * 10;
        rb.AddForce(moveVector);
    }
}
