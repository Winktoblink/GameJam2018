using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    GameObject[] pauseObjects;
    public AudioClip menuTheme;


    // Use this for initialization
    void Start () {
        SoundManager.instance.PlayMusic(menuTheme);
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyUp("enter") || Input.GetKeyUp("return"))
        {
            LoadLevel();
        }
    }

    //Reloads the Level
    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //loads inputted level
    public void LoadLevel()
    {
        SceneManager.LoadScene(3);
    }

    //loads inputted level
    public void QuitLevel()
    {
        Application.Quit();
    }
}
