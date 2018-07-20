using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageBehavior : MonoBehaviour {
    Animator anim;
    PackageSpawnBehavior spawnPoint;


	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        anim.Play("Spawn");        
    }
	
	// Update is called once per frame
	void Update () {
        if (this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("End"))
        {
            Destroy(gameObject);
        }
    }

    //Give the package a reference to relay information back to
    public void setSpawn(PackageSpawnBehavior spawn)
    {
        spawnPoint = spawn;
    }

    // called when the cat dashes into other mouse
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Package hit"); 
        if (col.gameObject.tag == "Mouse")
        {
            anim.Play("Point_Get");
            spawnPoint.packageDespawned(); //Let the spawn point known that there is no longer a package
            GameManager.Instance.increaseScore(); //Let the game manager known to increase the score
        }

        if (col.gameObject.tag == "Cat")
        {
            anim.Play("Point_Denied");
            spawnPoint.packageDespawned(); //Let the spawn point known that there is no longer a package
        }
    }
}
