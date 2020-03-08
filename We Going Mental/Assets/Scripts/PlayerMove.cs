using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 moveVector;
    private int h, v, direction = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    private void OnDisable()
    {
        anim.SetBool("IsWalking", false);
        if (direction == 0)
        {
            direction = 2;
            anim.SetInteger("Direction", 2);
        }
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
        }
        else
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
        }
        else
        {
            h = 0;
        }
        if (v == 0)
        {
            if (h == 1)
            {
                direction = 1;
            }
            else if (h == -1)
            {
                direction = 3;
            }
        }
        else if (v == 1)
        {
            direction = 0;
        }
        else if (v == -1)
        {
            direction = 2;
        }
        if (anim.GetInteger("Direction") != direction) {
            anim.SetInteger("Direction", direction);
        }
        moveVector = new Vector2(h, v).normalized * speed * 10;
        if (moveVector != Vector2.zero) {
            anim.SetBool("IsWalking", true);
            rb.AddForce(moveVector);
        }
        else
        {
            anim.SetBool("IsWalking", false);
        }
    }
}
