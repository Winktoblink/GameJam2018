using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinnerScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Vector3 upscale = new Vector3(0.1F, 0, 0);

        if (GameManager.p1score > GameManager.p2score)
        {
            GameObject winner = Instantiate(GameManager.Instance.spawnLyra, new Vector3(0.5f, 1.5f, 0), Quaternion.Euler(0, 0, 0));
            winner.transform.localScale = new Vector3(3, 3, 0);
        }
        else if (GameManager.p1score < GameManager.p2score)
        {
            GameObject winner = Instantiate(GameManager.Instance.spawnDyra, new Vector3(0.5f, 1.5f, 0), Quaternion.Euler(0, 0, 0));
            winner.transform.localScale = new Vector3(3, 3, 0);
        }
        else
        {
            GameObject winner1 = Instantiate(GameManager.Instance.spawnLyra, new Vector3(-0.75f, 1.5f, 0), Quaternion.Euler(0, 0, 0));
            GameObject winner2 = Instantiate(GameManager.Instance.spawnDyra, new Vector3(1.75f, 1.5f, 0), Quaternion.Euler(0, 0, 0));
            winner1.transform.localScale = new Vector3(3, 3, 0);
            winner2.transform.localScale = new Vector3(3, 3, 0);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
