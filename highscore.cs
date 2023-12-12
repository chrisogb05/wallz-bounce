using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class highscore : MonoBehaviour
{
	Data d;
	Text txtcomp;
    // Start is called before the first frame update
    void Start()
    {
        d = GameObject.Find("player").GetComponent<Data>();
        txtcomp = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        txtcomp.text = /*"Highscore " + */d.highScore.ToString();
    }
}
