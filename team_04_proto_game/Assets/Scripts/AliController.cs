﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliController : MonoBehaviour
{
    private float moveSpeed;
    private Animator animator;
    private float xposition;
    private Vector3 localRotation;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
        moveSpeed = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal();
        Jump();
    }

    void moveHorizontal()
    {
        //print("Update");
        //xposition = Input.GetAxis("Horizontal");  //left and right movement
        xposition = Input.GetAxis("Horizontal");
        print(xposition);

        //if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        if (xposition > 0.5)
        {
            print("if statement");
            transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
            animator.SetBool("IsRunning", true);
            transform.position += new Vector3(xposition, 0f, 0f) * moveSpeed * Time.deltaTime;
        }
        //else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        else if (xposition < -.5)
        {
            print("else if");
            transform.localRotation = Quaternion.Euler(0f, -90f, 0f);
            animator.SetBool("IsRunning", true);
            transform.position += new Vector3(xposition, 0f, 0f) * moveSpeed * Time.deltaTime;
        }
        else
        {
            print("else statement");
            transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
            animator.SetBool("IsRunning", false);
            transform.position += new Vector3(xposition, 0f, 0f) * moveSpeed * Time.deltaTime;

        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("IsJumping", true);
            animator.SetBool("IsLanding", true);
        }
        else
        {
            animator.SetBool("IsJumping", false);
        }
    }
}
