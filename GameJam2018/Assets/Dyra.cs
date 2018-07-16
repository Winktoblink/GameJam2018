using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dyra : MonoBehaviour {

    Animator anim;
    float speed;

    // Use this for initialization
    void Start () {
        //Fetch the Animator from GameObject
        anim = GetComponent<Animator>();
        speed = 0.1f;

    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKey(KeyCode.A))
        {
            anim.Play("MoveLoop");
            gameObject.transform.Translate(Vector3.left * speed);
            anim.SetFloat("FaceX", -1);
            anim.SetFloat("FaceY", 0);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            anim.Play("MoveLoop");
            gameObject.transform.Translate(Vector3.right * speed);
            anim.SetFloat("FaceX", 1);
            anim.SetFloat("FaceY", 0);
        }

        else if (Input.GetKey(KeyCode.W))
        {
            anim.Play("MoveLoop");
            gameObject.transform.Translate(Vector3.up *speed );
            anim.SetFloat("FaceX", 0);
            anim.SetFloat("FaceY", 1);
        }

        else if (Input.GetKey(KeyCode.S))
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
    }
}
