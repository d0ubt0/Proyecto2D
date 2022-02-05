using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public Animator anim;
    [SerializeField]
    private AudioSource deathSoundEffect;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Death"))
        {
            deathSoundEffect.Play();
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
