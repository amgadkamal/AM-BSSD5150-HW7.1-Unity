using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public GameObject[] enemies;
    public Transform[] spawnPoint;
    
    private int random;
    private int random2;
    public GameObject[] findenemy;
    
    public float y;
    private float z;

    private void Start()
    {
        enemies[0].SetActive(false);
        enemies[1].SetActive(false);
        enemies[2].SetActive(false);
        z = y; }


    private void Update()
    {
        StartCoroutine("bulletss");
    }

    IEnumerator bulletss()
    {
        //3 seconds before balls appear
        yield return new WaitForSecondsRealtime(3);
        Bulletsss();
        
        //60 seconds then los scene, no need for and (no of enemies<10) as if user already succesewd to get 10 , wil scene will be on
        yield return new WaitForSecondsRealtime(60);
        SceneManager.LoadScene("Lose");
    }

      public void Bulletsss()
      { 
          if(z <= 0)
          {
              //random anemeis, and random spawn points
              random = Random.Range(0,enemies.Length);
              random2 = Random.Range( 0,spawnPoint.Length);
              Instantiate(enemies[random], spawnPoint[random2].transform.position, Quaternion.identity);
              enemies[random].SetActive(true);
             
              z = y;
          }
          else
          {
              z -= Time.deltaTime;
          }
          
      }
    
      
      
}