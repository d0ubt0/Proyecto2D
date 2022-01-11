using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour
{
    public Animator anim;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            anim.SetBool("PlayerCollision",true);
            Invoke("SetBool",1);
        }
    }

    void SetBool()
    {
        anim.SetBool("PlayerCollision",false);
    }
}