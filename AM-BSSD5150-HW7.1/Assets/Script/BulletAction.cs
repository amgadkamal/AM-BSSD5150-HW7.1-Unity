using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]

public class BulletAction : MonoBehaviour
{

    [SerializeField]
    private float speed = 6f;
    private Rigidbody2D rb;
    private int killedenemies = 0;
    public GameObject[] PowerUp;
  
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.up * speed;
        PowerUp = GameObject.FindGameObjectsWithTag("powerUp");
        PowerUp[0].SetActive(false);
    }
    
//code from class
    private void OnBecameVisible()
    {
        rb.velocity = Vector2.up * speed;
    }
    
    private void OnBecameInvisible()
    {
        this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Destroy(collision.gameObject);
            this.gameObject.SetActive(false);
            killedenemies += 1;
            //powerup
            if (killedenemies == 5)
            {
                PowerUp[0].SetActive(true);
            }
            //winscene, lose scene in enemy control script
            if (killedenemies == 10)
            {
                SceneManager.LoadScene("Win");
            }
            
            
           
            
        }
    }
   
    


   
}
