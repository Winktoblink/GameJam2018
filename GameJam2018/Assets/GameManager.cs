using UnityEngine;
using System.Collections;
using System.Collections.Generic;       //Allows us to use Lists. 

public class GameManager : MonoBehaviour
{

    public static GameManager Instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
    public GameObject spawnSmoke;
    public GameObject spawnLyra;
    public GameObject spawnDyra;
    public static bool smokeExists;
    public enum spiritAnimal {cat, mouse};
    public static spiritAnimal lyraAnimal;
    public static spiritAnimal dyraAnimal;
    
    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (Instance == null)

            //if not, set instance to this
            Instance = this;

        //If instance already exists and it's not this:
        else if (Instance != this)

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
        lyraAnimal = spiritAnimal.cat;
        dyraAnimal = spiritAnimal.mouse;
        Instantiate(spawnLyra, new Vector3(-10.5f, 0, 0), Quaternion.Euler(0, 0, 0));
        Instantiate(spawnDyra, new Vector3(10.5f, 0, 0), Quaternion.Euler(0, 0, 0));
        object[] obj = GameObject.FindObjectsOfType(typeof(GameObject));
        foreach (object o in obj)
        {
            GameObject g = (GameObject)o;
            if (g.GetComponent<SpriteRenderer>() != null)
            {
                g.GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(g.transform.position.y * 100f) * -1;
            }
        }
    }



    //Update is called every frame.
    void Update()
    {

    }

    public void playSmoke(Vector3 pos, Quaternion quat)
    {
        if (GameManager.smokeExists == false)
        {
            Vector3 smokeSpawn = pos + new Vector3(0, -2.25f, 0);
            Instantiate(spawnSmoke, smokeSpawn, quat);
            GameManager.smokeExists = true;
        }
    }
}