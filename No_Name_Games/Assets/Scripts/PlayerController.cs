using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Using Unity Engine.UI allows me to use a global variable that effects other scripts
// Player movement messed up when colliders changed to 2D, code will need to be fixed.

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    public bool isGrounded;
    public bool isHidden;
    private float horizontalMove;
    private bool facingRight = true;
    public bool hidingSpot;

    public Transform groundCheck;
    float groundRadius = 0.2f; //setting the radius of the circle that checks if the player is on the ground
    public LayerMask whatIsGround; 

    // public DetectionScript DetectBool; //Allowing this script to access the detection bool from Detection script.

    private Animator _childAnim;
    public GameObject GameOverText, restartButton; //creating the ui for game overs
    Rigidbody2D myRb;

    Collider2D col;
   
    void Start()
    {
        GameOverText.SetActive(false); //getting the text off the screen
        restartButton.SetActive(false); //getting the button off the screen
        hidingSpot = false;
        isHidden = false;
        //DetectBool.Detected = false; //needed to change player speed when detected
        myRb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        _childAnim = GetComponent<Animator>();

    }

    
    void Update()
    {
        _childAnim.SetFloat("speed", Mathf.Abs(myRb.velocity.x));
       /* if (DetectBool.Detected == true) //making the player speed up to get away from guards
        {
            speed = 10;
        }
        else
        { */
            speed = 5;
      //  } 

        if( isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            myRb.AddForce(new Vector2(0, jumpForce)); //makes the player jump when space is pressed
        }
    }

    void FixedUpdate()
    {
        Move(); //runs the Move function
        Hidding();
        if(horizontalMove < 0 && !facingRight) //checks if the player is moving and is not facing right
        {
            Flip();
        }
        else if(horizontalMove < 0 && facingRight)//checks if the player is moving and facing right
        {
            Flip();
        }


        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround); //checks if the player is on the ground
    }

    private void Move()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal"); //Storing the built in horizontal speed as a float
        Vector2 moveVel = myRb.velocity; //creating a new vector for velocity to be changed 
        moveVel.x = horizontalMove * speed; //changing the speed according to our variable
        myRb.velocity = moveVel; //reseting the speed per frame
    }

    private void Flip()
    {
        facingRight = !facingRight; //changes the bool as the player turns
        Vector3 theScale = transform.localScale; //Storing the transform scale of the character as a vector3
        theScale.x *= -1; //inverting the scale to turn the player around
        transform.localScale = theScale;
    }

    private void Hidding()
    {
        if (isHidden == false && Input.GetKeyDown((KeyCode.F)) && hidingSpot == true) //checks if the player is not hidden and if the player pressed f
        {
            gameObject.layer = 11; //changing the player's layer
            isHidden = true;
        }

        if (isHidden == true && Input.GetKeyDown((KeyCode.F))) //checks if the player is hidden and if the player pressed f
        {
            gameObject.layer = 8; //changing the player's layer back to normal
            isHidden = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) //once the collider on the player hits something
    {
        if( other.tag == "HidingSpot") //checking if the tag of the other object is a hiding location
        {
            hidingSpot = true;
        }
        else
        {
            hidingSpot = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other) //once the collider on the player hits something
    {
        if (other.tag == "HidingSpot") //checking if the tag of the other object is a hiding location
        {
            hidingSpot = false;
            gameObject.layer = 8;
            isHidden = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)  //playerkill script
    {
        if(col.gameObject.tag.Equals("Enemy"))
        {
            GameOverText.SetActive(true); //makes Game Over appear
            restartButton.SetActive(true); // makes the button appear
            gameObject.SetActive(false); // halts the player
        }
    }
}
