using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Using Unity Engine.UI allows me to use a global variable that effects other scripts

public class DetectionScript : MonoBehaviour {

    PlayerController pController;
    GameObject player;

    
    public Image blackOverlay;
    public float fadeTime = 3f;
    float timeCounter = 0;
    float fadePercentage;
    public bool caught= false;
    public GameObject GameOverText, restartButton;
    

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pController = player.GetComponent<PlayerController>();

        restartButton.SetActive(false);


       blackOverlay.color = new Color(0, 0, 0, 0);
       blackOverlay.gameObject.SetActive(true);

    }

    

    private void Update()
    {
        if(caught == true)
        {
            timeCounter += Time.deltaTime;
            fadePercentage = timeCounter / fadeTime;

            blackOverlay.color = new Color(0, 0, 0, fadePercentage);

            GameOverText.SetActive(true); 
            restartButton.SetActive(true);

            if (timeCounter > fadeTime + 3)
            {
            restartButton.SetActive(true);
            }

            // if restart button clicked, reload level
            // ->

        }
    }

    
    private void OnTriggerEnter2D(Collider2D other) //once the collider on the player hits something
    {
        if (other.tag == "Player")
        {
            pController.speed = 0;
            pController.jumpForce = 0;
            caught = true;
        }
    }
} 
