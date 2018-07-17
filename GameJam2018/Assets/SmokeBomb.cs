using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeBomb : MonoBehaviour {

    Animator anim;
	// Use this for initialization
	void Start () {
        //Fetch the Animator from GameObject
        anim = GetComponent<Animator>();
        anim.Play("Init");
    }
	
	// Update is called once per frame
	void Update () {
        //If we're in "Fade" animation, destroy the smoke bomb
        if (this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("End"))
        {
            GameManager.smokeExists = false;
            Destroy(gameObject);
        }
    }
}
