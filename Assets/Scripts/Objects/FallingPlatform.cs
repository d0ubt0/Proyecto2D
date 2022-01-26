using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public Rigidbody2D Rigidbody2D;
    public BoxCollider2D boxCollider2D;
    public Animator animator;
    
    
    void Start()
    {
        Rigidbody2D.gravityScale = 0;
        boxCollider2D.isTrigger = false;
        Rigidbody2D.bodyType =RigidbodyType2D.Kinematic;
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if(collisionInfo.gameObject.CompareTag("Player"))
        {
            Invoke("Off",0.4f);
            Invoke("Destroy",5f);

        }
    }

    void Off()
    {
        Rigidbody2D.bodyType =RigidbodyType2D.Dynamic;
        animator.SetBool("isOn",false);
        Rigidbody2D.gravityScale = 1;
        boxCollider2D.isTrigger = true;
    }

    void Destroy()
    {
        Destroy(gameObject);
    }
}
