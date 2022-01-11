using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathCollision : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D other) 
    {

        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
            Invoke("SceneChange",2);
        }
        
    }

void SceneChange()
{
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}
}
