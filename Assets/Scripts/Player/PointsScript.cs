using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsScript : MonoBehaviour
{
    private UIScript points;
    private SpriteRenderer spriteApple;

    private void Update()
    {
        if (points == null)
        {
            points = GameObject.Find("UI").GetComponent<UIScript>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Apple"))
        {
            Collected(collision);
            points.fruitPoints += 10f;
            
        }
        else if (collision.CompareTag("Banana"))
        {
            Collected(collision);
            points.fruitPoints += 25f;

        }
        else if (collision.CompareTag("Cherries"))
        {
            Collected(collision);
            points.fruitPoints += 50f;

        }
        else if (collision.CompareTag("Melon"))
        {
            Collected(collision);
            points.fruitPoints += 75f;

        }

    }
    void Collected(Collider2D collision)
    {
        spriteApple = collision.gameObject.GetComponent<SpriteRenderer>();
        spriteApple.enabled = false;
        collision.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        Destroy(collision.gameObject, 0.4f);
       
    }

}
