﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lyra : MonoBehaviour
{

    Animator anim;
    float speed;
    Vector3 direction;
    const int dashLength = 30;
    int dashCount;
    bool isDashing;

    // Use this for initialization
    void Start()
    {
        //Fetch the Animator from GameObject
        anim = GetComponent<Animator>();
        anim.SetFloat("FaceX", 0);
        anim.SetFloat("FaceY", -1);
        speed = 0.2f;
        dashCount = 1;
        isDashing = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Set sorting order based on y value, enables rendering behind/infront of objects
        GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(transform.position.y * 100f) * -1;

        //Only allow movement input if not dashing
        if (isDashing)
        {
            Dashing();
        }
        else
        {
            Movement();
        }
    }

    void Movement()
    {
        //Movement inputs
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            anim.Play("MoveLoop");
            gameObject.transform.Translate(Vector3.left * speed);
            anim.SetFloat("FaceX", -1);
            anim.SetFloat("FaceY", 0);
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            anim.Play("MoveLoop");
            gameObject.transform.Translate(Vector3.right * speed);
            anim.SetFloat("FaceX", 1);
            anim.SetFloat("FaceY", 0);
        }

        else if (Input.GetKey(KeyCode.UpArrow))
        {
            anim.Play("MoveLoop");
            gameObject.transform.Translate(Vector3.up * speed);
            anim.SetFloat("FaceX", 0);
            anim.SetFloat("FaceY", 1);
        }

        else if (Input.GetKey(KeyCode.DownArrow))
        {
            anim.Play("MoveLoop");
            gameObject.transform.Translate(Vector3.down * speed);
            anim.SetFloat("FaceX", 0);
            anim.SetFloat("FaceY", -1);
        }
        else
        {
            anim.Play("IdleLoop");
        }

        if (Input.GetKey(KeyCode.Q))
        {
            isDashing = true;
            //Infer direction for dash based on current heading
            direction = new Vector3(anim.GetFloat("FaceX"), anim.GetFloat("FaceY"), 0);
        }
    }

    void Dashing()
    {
        anim.Play("DashLoop");
        if (dashCount > dashLength)
        {
            dashCount = 1;
            isDashing = false;
        }
        else
        {
            //Dash at 2x speed
            gameObject.transform.Translate(direction * speed * 2f * (dashLength - dashCount)/dashLength);
            dashCount++;
        }
    }

}
