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
    public Transform groundDetection;
    public Transform wallDetection;
    public int milliseconds; //Made public to allow different guards to have different delays in their patrol route
   // public DetectionScript DetectBool; //Allowing this script to access the detection bool from Detection script.
    
    void Start()
    {
        
       // DetectBool.Detected = false; //Guards will start with the player undetected
    }

    void Update()
    {
     
            RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f); //Raycast for detecting floor
         //  RaycastHit2D wallInfo = Physics2D.Raycast(wallDetection.position, Vector2.right, 2f); //Raycast for detecting walls


        if ( groundInfo.collider == false /*|| wallInfo.collider == true */ ) // Getting info from colliders
            {
                if (movingRight == true)
                {
                    Thread.Sleep(milliseconds); //Delay in the patrol
                    transform.eulerAngles = new Vector3(0, -180, 0); //Flipping sprite
                    movingRight = false;  //Changing sprite movement direction
                }
                else
                {
                    Thread.Sleep(milliseconds);
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    movingRight = true;
                }
            }
            else
            { 
                transform.Translate(Vector2.right * speed * Time.deltaTime); //Guards forward movement
            }
      
    }
   
}