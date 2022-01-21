using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private Transform playerTransform;
    public BoxCollider2D BoxCollider2D;

    
    void Update()
    {
        if(playerTransform == null)
        {
            playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        }

        if(playerTransform.transform.position.y-0.16f>gameObject.transform.position.y)
        {
            BoxCollider2D.isTrigger = false;
        }
        else if(playerTransform.transform.position.y-0.16f<gameObject.transform.position.y)
        {
            BoxCollider2D.isTrigger = true;
        }
    }
}
