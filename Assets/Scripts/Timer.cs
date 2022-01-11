using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{       
    private float miliseconds;
    private float seconds;
    private float minutes;
    private Text UIText;
    void Start()
    {
        UIText = GetComponent<Text>();
    }

    void Update()
    {

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

        UIText.text= minutes +" : " + seconds + " : " + Mathf.FloorToInt(miliseconds);
           
    }
}
