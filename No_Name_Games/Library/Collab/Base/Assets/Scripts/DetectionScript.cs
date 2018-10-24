using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Using Unity Engine.UI allows me to use a global variable that effects other scripts

public class DetectionScript : MonoBehaviour {

   /* public bool Detected = false; //Needed to effect other scripts
    public Transform playerDetection; //Detection variable
    int layerMask = 1 << 8; // This makes the detection raycast only check the 8th layer/the 'detection' layer.
   

 
    void Start () {
		
	}
	
	
	void Update ()
    {
        RaycastHit2D playerInfo = Physics2D.Raycast(playerDetection.position, Vector2.right, 4f); //The raycast to detect the player, attached to a game object that is a child of the guard
        

        if ( playerInfo.collider == true && Physics.Raycast(transform.position, Vector3.forward, Mathf.Infinity, layerMask )) //This changes the global variable of detected to true if the player is within detection range and not in the hiding layer.
        {
            Detected = true;
        }
        else
        {
            Detected = false;
        }
    } */
} 
