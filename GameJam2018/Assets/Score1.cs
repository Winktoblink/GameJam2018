using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using UnityEngine.SceneManagement;

public class Score1 : MonoBehaviour
{
    public Text p1score; //UI Text Object
    void Start()
    {

    }
    void Update()
    {
        p1score.text = GameManager.p1score.ToString();
    }
}