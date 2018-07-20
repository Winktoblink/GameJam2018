using UnityEngine;
using System.Collections;
using System.Collections.Generic;       //Allows us to use Lists. 
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
    public GameObject spawnSmoke;
    public GameObject spawnPackage;
    public GameObject spawnLyra;
    public GameObject spawnDyra;
    public static GameObject player1;
    public static GameObject player2;
    public static bool smokeExists;
    public static int p1score = 0;
    public static int p2score = 0;
    public static int roundCount = 1;
    public AudioClip mainTheme;
    public AudioClip smokeBombSound;

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
        if (roundCount == 1)
        {
            p1score = 0;
            p2score = 0;
            SoundManager.instance.PlayMusic(mainTheme);
            player1 = Instantiate(spawnLyra, new Vector3(-10.5f, 0, 0), Quaternion.Euler(0, 0, 0));
            player1.gameObject.tag = "Cat";
            player2 = Instantiate(spawnDyra, new Vector3(10.5f, 0, 0), Quaternion.Euler(0, 0, 0));
            player2.gameObject.tag = "Mouse";
        }
        else if (roundCount == 2)
        {
            player1 = Instantiate(spawnLyra, new Vector3(-10.5f, 0, 0), Quaternion.Euler(0, 0, 0));
            player1.gameObject.tag = "Mouse";
            player2 = Instantiate(spawnDyra, new Vector3(10.5f, 0, 0), Quaternion.Euler(0, 0, 0));
            player2.gameObject.tag = "Cat";
        }
        else
        {
            resetGame();
        }
        object[] obj = GameObject.FindObjectsOfType(typeof(GameObject));
        foreach (object o in obj)
        {
            GameObject g = (GameObject)o;
            if (g.GetComponent<SpriteRenderer>() != null)
            {
                g.GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(g.transform.position.y * 100f) * -1;
            }
            if (g.tag == "Indicator")
            {
                if (g.name == "1PCatIndicator" && player1.gameObject.tag == "Cat")
                {
                    g.GetComponent<SpriteRenderer>().sortingOrder = 1;
                }
                else if (g.name == "1PMouseIndicator" && player1.gameObject.tag == "Mouse")
                {
                    g.GetComponent<SpriteRenderer>().sortingOrder = 1;
                }
                else if (g.name == "2PCatIndicator" && player2.gameObject.tag == "Cat")
                {
                    g.GetComponent<SpriteRenderer>().sortingOrder = 1;
                }
                else if (g.name == "2PMouseIndicator" && player2.gameObject.tag == "Mouse")
                {
                    g.GetComponent<SpriteRenderer>().sortingOrder = 1;
                }
                else if (g.name == "Pounce Item Card" && player2.gameObject.tag == "Cat")
                {
                    g.transform.position = new Vector3(11.625f, 8.625f, 0);
                }
                else if (g.name == "Smoke Bomb Item Card" && player1.gameObject.tag == "Mouse")
                {
                    g.transform.position = new Vector3(-11.625f, 8.625f, 0);
                }
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
            SoundManager.instance.PlayEffects(smokeBombSound);
        }
    }

    public void playPackage(PackageSpawnBehavior spawnPoint)
    {
        Vector3 packageSpawn = spawnPoint.transform.position + new Vector3(0, 0.5f, 0);
        PackageBehavior package = Instantiate(spawnPackage, packageSpawn, spawnPoint.transform.rotation).GetComponent<PackageBehavior>();
        package.setSpawn(spawnPoint);
    }

    public void increaseScore()
    {
        if(roundCount == 1)
        {
            p2score++;
        }
        if(roundCount == 2)
        {
            p1score++;
        }
    }

    public void resetGame()
    {
        roundCount = 1;
        SoundManager.instance.StopMusic(mainTheme);
        SceneManager.LoadScene(2);
    }

    public static void endRound()
    {
        roundCount++;
        if (roundCount == 3)
        {
            GameManager.Instance.resetGame();
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}