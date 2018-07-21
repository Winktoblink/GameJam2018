using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageSpawnBehavior : MonoBehaviour
{
    Animator anim;
    private const int cooldownTime = 3;
    private float cooldown = cooldownTime;
    private bool packageSpawned = false;
    private float triggerDist = 3;
    private float dist;
    private GameObject mouse;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        //check distance between mouse and spawn point
        mouse = GameObject.FindGameObjectWithTag("Mouse");
        dist = Vector3.Distance(mouse.transform.position, this.transform.position);

        //if mouse is far enough and package doesn't not exist, reduce cooldown
        if(!packageSpawned && dist > triggerDist)
        {
            cooldown -= Time.deltaTime;
        }

        //if cooldown is over spawn package and package doesn't exist, spawn package
        if(cooldown <= 0f && !packageSpawned && dist > triggerDist)
        {
            GameManager.Instance.playPackage(this);
            cooldown = cooldownTime;
            packageSpawned = true;
            anim.Play("Idle");
        }
        if(!packageSpawned && dist < triggerDist)
        {
            anim.Play("Cooldown");
        }
        else
        {
            anim.Play("Idle");
        }


    }

    public void packageDespawned()
    {
        packageSpawned = false;
    }

}
