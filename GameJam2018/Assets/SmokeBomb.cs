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
        if (this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Fade"))
        {
            GameManager.smokeExists = false;
            Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        }
        
    }
}
