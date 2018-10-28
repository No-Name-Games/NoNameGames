using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderScript : MonoBehaviour {

    public bool ladderCheck = false;

    Rigidbody2D myRb;

    public float ladderSpeed = 10;


	// Use this for initialization
	void Start ()
    {
        myRb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        LadderMovement();
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "LaddersTag")
        {
            ladderCheck = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "LaddersTag") ;
        {
            ladderCheck = false;
        }
    }

    private void LadderMovement()
    {
        float verticleMove = Input.GetAxisRaw("Vertical");
        if(Input.GetKey((KeyCode.Space)) && ladderCheck == true)
        {
            Vector2 ladderMove = myRb.velocity;
            ladderMove.y = ladderSpeed * verticleMove;
            myRb.velocity = ladderMove;
        }
    }
}
