using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{       
    private float timer;
    private float miliseconds;
    private float seconds;
    private float minutes;
    private Text UIText;
    public float fruitPoints;
    private float points;
    void Start()
    {
        UIText = GetComponent<Text>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        miliseconds =(Time.deltaTime*100f)+miliseconds;
        
        if(miliseconds>=100)
        {
            seconds = seconds + 1f;
            miliseconds = 0f;
        }
        
        if(seconds>=60)
        {
            minutes = minutes + 1f;
            seconds = 0f;
        }
        points = (timer * -2f) + 300+fruitPoints;

        UIText.text= minutes +" : " + seconds + " : " + Mathf.FloorToInt(miliseconds)+ "       "+ Mathf.FloorToInt(points) + " Points";
           
    }
}
