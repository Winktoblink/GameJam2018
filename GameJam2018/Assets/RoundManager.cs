using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundManager : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    // Use this for initialization
    void Start () {
        Vector3 upscale = new Vector3(0.1f, 0, 0);
        SoundManager.instance.StopMusic();
        if (GameManager.roundCount == 1)
        {            
            player1 = Instantiate(GameManager.Instance.spawnLyra, new Vector3(-10.5f, 0, 0), Quaternion.Euler(0, 0, 0));
            player1.gameObject.tag = "Cat";
            player2 = Instantiate(GameManager.Instance.spawnDyra, new Vector3(10.5f, 0, 0), Quaternion.Euler(0, 0, 0));
            player2.gameObject.tag = "Mouse";
        }
        else if (GameManager.roundCount == 2)
        {
            player1 = Instantiate(GameManager.Instance.spawnLyra, new Vector3(-10.5f, 0, 0), Quaternion.Euler(0, 0, 0));
            player1.gameObject.tag = "Mouse";
            player2 = Instantiate(GameManager.Instance.spawnDyra, new Vector3(10.5f, 0, 0), Quaternion.Euler(0, 0, 0));
            player2.gameObject.tag = "Cat";
        }
        player1.transform.localScale = new Vector3(3, 3, 0);
        player2.transform.localScale = new Vector3(3, 3, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyUp("return") || Input.GetKeyUp("return")))
        {
            SoundManager.instance.StopMusic();
            SceneManager.LoadScene(1);
        }
    }
}
