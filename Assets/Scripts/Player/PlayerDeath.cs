using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public Animator anim;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Death"))
        {
            anim.SetBool("Death",true);
            Invoke("SetActive",0.5f);
            Invoke("SceneChange",1.5f);
        }   
        
    }

    void SetActive()
    {
        gameObject.SetActive(false);
    }
    void SceneChange()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
