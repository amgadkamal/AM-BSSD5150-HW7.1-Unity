using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ShipController : MonoBehaviour

{
    [SerializeField]
    private Transform spawnPoint;

    public static int noofbullets = 2;
    public float delayInSeconds=3;
    public int i;
  

    float speed = 10f;
    Rigidbody2D rb;

    GameObject[] bullet= new GameObject[noofbullets];

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }
    

    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        rb.velocity = Vector2.right * move * speed;
        
        if (Input.GetKeyDown("space"))
        {
            for (i = 0; i < noofbullets; i++)
            {
                //double ball when hit space
                bullet[i] = Instantiate(Resources.Load("ball"), spawnPoint.position, Quaternion.identity) as GameObject;
                bullet[i].transform.position = spawnPoint.transform.position;
                bullet[i].SetActive(true);
                
               
            }
        }
    }







}
