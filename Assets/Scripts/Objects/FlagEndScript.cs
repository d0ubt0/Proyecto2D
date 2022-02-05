using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlagEndScript : MonoBehaviour
{
    public Animator anim;
    [SerializeField]
    private AudioSource winSoundEffect;

    private bool levelCompleted = false;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && levelCompleted == false)
        {
            levelCompleted = true;
            winSoundEffect.Play();
            anim.SetBool("PlayerCollision",true);
            Invoke("ChangeScene",2);
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    
        
}
