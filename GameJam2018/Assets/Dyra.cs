using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dyra : MonoBehaviour {

    Animator anim;

    // Use this for initialization
    void Start () {
        //Fetch the Animator from GameObject
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKey(KeyCode.A))
        {
            anim.Play("MoveLoop");
            gameObject.transform.Translate(Vector3.left * 0.1f);
            anim.SetFloat("FaceX", -1);
            anim.SetFloat("FaceY", 0);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            anim.Play("MoveLoop");
            gameObject.transform.Translate(Vector3.right * 0.1f);
            anim.SetFloat("FaceX", 1);
            anim.SetFloat("FaceY", 0);
        }

        else if (Input.GetKey(KeyCode.W))
        {
            anim.Play("MoveLoop");
            gameObject.transform.Translate(Vector3.up * 0.1f);
            anim.SetFloat("FaceX", 0);
            anim.SetFloat("FaceY", 1);
        }

        else if (Input.GetKey(KeyCode.S))
        {
            anim.Play("MoveLoop");
            gameObject.transform.Translate(Vector3.down * 0.1f);
            anim.SetFloat("FaceX", 0);
            anim.SetFloat("FaceY", -1);
        }
        else
        {
            anim.Play("IdleLoop");
        }
    }
}
