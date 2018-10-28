using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;
using UnityEngine.AI;

//Using UnityEngine.AI to allow persuit of player.
//Using threading to allow delay script to work
//Using Unity Engine.UI allows me to use a global variable that effects other scripts

public class Patrol_Script : MonoBehaviour
{
    public float speed;
    private bool movingRight = true;
   
   // public int milliseconds; //Made public to allow different guards to have different delays in their patrol route
  //  public DetectionScript DetectBool; //Allowing this script to access the detection bool from Detection script.
    
    void Start()
    {
        
       // DetectBool.Detected = false; //Guards will start with the player undetected
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime); //Guards forward movement


    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall" || collision.tag == "ENEMY")
        {
            if (movingRight == true)
            {
               // Thread.Sleep(milliseconds); //Delay in the patrol
                transform.eulerAngles = new Vector3(0, -180, 0); //Flipping sprite
                movingRight = false;  //Changing sprite movement direction
            }
            else
            {
               // Thread.Sleep(milliseconds);
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            if (movingRight == true)
            {
                // Thread.Sleep(milliseconds); //Delay in the patrol
                transform.eulerAngles = new Vector3(0, -180, 0); //Flipping sprite
                movingRight = false;  //Changing sprite movement direction
            }
            else
            {
                // Thread.Sleep(milliseconds);
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }

}