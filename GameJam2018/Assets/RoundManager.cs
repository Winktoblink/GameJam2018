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
                    g.transform.position = new Vector3(11.625f, 7.625f, 0);
                }
                else if (g.name == "Smoke Bomb Item Card" && player1.gameObject.tag == "Mouse")
                {
                    g.transform.position = new Vector3(-11.625f, 7.625f, 0);
                }
            }
        }
    }
}
