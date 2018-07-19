using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageSpawnBehavior : MonoBehaviour
{
    private const int cooldownTime = 3;
    private float cooldown = cooldownTime;
    private bool packageSpawned = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //check distance between mouse and spawn point

        //if mouse is far enough and package doesn't not exist, reduce cooldown
        if(!packageSpawned)
        {
            cooldown -= Time.deltaTime;
        }

        //if cooldown is over spawn package and package doesn't exist, spawn package
        if(cooldown <= 0f && !packageSpawned)
        {
            Debug.Log("Spawn Location : " + this.transform.position.ToString());
            GameManager.Instance.playPackage(this);
            cooldown = cooldownTime;
            packageSpawned = true;
        }
    }

    public void packageDespawned()
    {
        packageSpawned = false;
    }

}
