using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using UnityEngine.SceneManagement;

public class CountDown : MonoBehaviour
{
    public int timeLeft = 30; //Seconds Overall
    public Text countdown; //UI Text Object
    void Start()
    {
        StartCoroutine("LoseTime");
        Time.timeScale = 1; //Just making sure that the timeScale is right
    }
    void Update()
    {
        if (timeLeft < 10)
        {
            countdown.text = ("0:0" + timeLeft); //Showing the Score on the Canvas
        }
        else
        {
            countdown.text = ("0:" + timeLeft); //Showing the Score on the Canvas
        }
        if (timeLeft == 0)
        {
            GameManager.endRound();
        }
    }
    //Simple Coroutine
    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }

}