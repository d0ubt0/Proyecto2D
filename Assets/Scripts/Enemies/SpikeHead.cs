using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHead : MonoBehaviour
{
    public Transform spikeTransform;
    private Transform playerTransform;
    public Animator anim;

    
    void Start()
    {       

    }

    void Update()
    {
        if(playerTransform == null)
        {
            playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        }
        PlayerNear();
    }

    void PlayerNear()
    {
        Vector2 spikePosition;
        Vector2 playerPosition;
        Vector2 deltaPosition;
        spikePosition = spikeTransform.position;
        playerPosition = playerTransform.position;
        deltaPosition = spikePosition - playerPosition;

        if(Mathf.Abs(deltaPosition.x)<0.6 && deltaPosition.y>0.5)
        {
            anim.SetBool("PlayerNear",true);
        }
        else
        {
            anim.SetBool("PlayerNear",false);
        }  
    }

    

}
