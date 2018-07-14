using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lyra : MonoBehaviour {

    Animator anim;

    // Use this for initialization
    void Start () {
        //Fetch the Animator from GameObject
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update () {

        //anim.Play("IdleLoop");
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            anim.Play("MoveLoop");
            gameObject.transform.Translate(Vector3.left * 0.1f);
            anim.SetFloat("FaceX", -1);
            anim.SetFloat("FaceY", 0);
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            anim.Play("MoveLoop");
            gameObject.transform.Translate(Vector3.right * 0.1f);
            anim.SetFloat("FaceX", 1);
            anim.SetFloat("FaceY", 0);
        }

        else if (Input.GetKey(KeyCode.UpArrow))
        {
            anim.Play("MoveLoop");
            gameObject.transform.Translate(Vector3.up * 0.1f);
            anim.SetFloat("FaceX", 0);
            anim.SetFloat("FaceY", 1);
        }

        else if (Input.GetKey(KeyCode.DownArrow))
        {
            anim.Play("MoveLoop");
            gameObject.transform.Translate(Vector3.down * 0.1f);
            anim.SetFloat("FaceX", 0);
            anim.SetFloat("FaceY", -1);
        }
    }
}
