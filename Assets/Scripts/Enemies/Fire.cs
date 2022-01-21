using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public Animator anim;
    public GameObject fireCollider;
    private float timer;

    void Start()
    {
        
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer>5f)
        {
            anim.SetBool("FireBool",true);
            timer = 0f;
        }
        else
        {
            anim.SetBool("FireBool",false);
        }

        if(anim.GetBool("FireBool") == true)
        {
            fireCollider.tag = "Death";
        }
        else
        {
            fireCollider.tag = "Untagged";
        }
    
    }
}
