﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lyra : MonoBehaviour
{
    public AudioClip wallHit;
    Animator anim;
    float speed;
    Vector3 direction;
    const float dashLength = 1.5f;
    float dashCount;
    bool isDashing;

    // Use this for initialization
    void Start()
    {
        //Fetch the Animator from GameObject
        anim = GetComponent<Animator>();
        anim.SetFloat("FaceX", 0);
        anim.SetFloat("FaceY", -1);
        speed = 5f;
        dashCount = 0;
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
        if (Input.GetAxis("1P_Horizontal") < 0)
        {
            anim.Play("MoveLoop");
            gameObject.transform.Translate(Vector3.left * speed * Time.deltaTime);
            anim.SetFloat("FaceX", -1);
            anim.SetFloat("FaceY", 0);
        }

        else if (Input.GetAxis("1P_Horizontal") > 0)
        {
            anim.Play("MoveLoop");
            gameObject.transform.Translate(Vector3.right * speed * Time.deltaTime);
            anim.SetFloat("FaceX", 1);
            anim.SetFloat("FaceY", 0);
        }

        else if (Input.GetAxis("1P_Vertical") > 0)
        {
            anim.Play("MoveLoop");
            gameObject.transform.Translate(Vector3.up * speed * Time.deltaTime);
            anim.SetFloat("FaceX", 0);
            anim.SetFloat("FaceY", 1);
        }

        else if (Input.GetAxis("1P_Vertical") < 0)
        {
            anim.Play("MoveLoop");
            gameObject.transform.Translate(Vector3.down * speed * Time.deltaTime);
            anim.SetFloat("FaceX", 0);
            anim.SetFloat("FaceY", -1);
        }
        else
        {
            anim.Play("IdleLoop");
        }

        if (Input.GetButtonDown("1P_Action") && this.tag == "Cat")
        {
            isDashing = true;
            //Infer direction for dash based on current heading
            direction = new Vector3(anim.GetFloat("FaceX"), anim.GetFloat("FaceY"), 0);
        }
        if (Input.GetButtonDown("1P_Action") && this.tag == "Mouse")
        {
            GameManager.Instance.playSmoke(this.transform.position, this.transform.rotation);
        }
    }

    void Dashing()
    {
        anim.Play("DashLoop");
        if (dashCount > dashLength)
        {
            dashCount = 0;
            isDashing = false;
        }
        else
        {
            //Dash at 2x speed
            gameObject.transform.Translate(direction * speed * 2.0f * Time.deltaTime * (dashLength - dashCount) / dashLength);
            dashCount += Time.deltaTime;
        }
    }

    // called when the cat dashes into other mouse
    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Mouse") && isDashing)
        {
            GameManager.endRound();
        }

        if (col.gameObject.CompareTag("Wall"))
        {
            SoundManager.instance.PlayEffects(wallHit);
        }
    }

    

}
