using UnityEngine;
using System.Collections;
using System.Collections.Generic;       //Allows us to use Lists. 

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
    public GameObject smokeBomb;
    public static bool smokeExists;

    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        //Call the InitGame function to initialize the first level 
        InitGame();
    }

    //Initializes the game for each level.
    void InitGame()
    {
        smokeExists = false;
        object[] obj = GameObject.FindObjectsOfType(typeof(GameObject));
        foreach (object o in obj)
        {
            GameObject g = (GameObject)o;
            //Debug.Log(g.name);
            if (g.GetComponent<SpriteRenderer>() != null)
            {
                g.GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(g.transform.position.y * 100f) * -1;
                //Debug.Log(g.GetComponent<SpriteRenderer>().sortingOrder);
            }
        }
    }



    //Update is called every frame.
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (smokeExists == false)
            {
                GameObject thePlayer = GameObject.Find("Lyra");
                Vector3 smokeSpawn = thePlayer.transform.position + new Vector3(0, -2.25f, 0);
                Instantiate(smokeBomb, smokeSpawn, thePlayer.transform.rotation);
                smokeExists = true;
            }
        }
    }
}