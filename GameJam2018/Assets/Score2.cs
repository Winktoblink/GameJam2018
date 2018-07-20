using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using UnityEngine.SceneManagement;

public class Score2 : MonoBehaviour
{
    public Text p2score; //UI Text Object
    void Start()
    {

    }
    void Update()
    {       
        p2score.text = GameManager.p2score.ToString();
    }
}