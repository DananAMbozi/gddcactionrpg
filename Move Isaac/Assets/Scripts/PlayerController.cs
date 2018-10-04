using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*attach this script to any object to be able to control it with WASD*/

public class PlayerController : MonoBehaviour {

    /*png's used to change the sprite image when player changes movement direction*/
    public Sprite rightProfile;
    public Sprite leftProfile;
    public Sprite frontProfile;
    public Sprite backProfile;

    //we can alter movement speed in user interface
    public float movementSpeed;

    //used to store references to player components
    private Rigidbody2D playerRigidBody;       
    private SpriteRenderer playerSpriteRenderer;


    private int moveRight, moveLeft, moveUp, moveDown;
    private bool jump;

    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component and SpriteRenderer component so that we can access it.
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();

        //initially stationary
        moveRight = 0;
        moveLeft = 0;
        moveUp = 0;
        moveDown = 0;
    }

    // Update is called once per frame
    void Update () {
		
	}

    void FixedUpdate()
    {

        //movement
        if (Input.GetKey(KeyCode.W)) { moveUp = 1; playerSpriteRenderer.sprite = backProfile; } else moveUp = 0;

        if (Input.GetKey(KeyCode.S)) { moveDown = 1; playerSpriteRenderer.sprite = frontProfile; } else moveDown = 0;

        if (Input.GetKey(KeyCode.D)) { moveRight = 1; playerSpriteRenderer.sprite = rightProfile; } else moveRight = 0;

        if (Input.GetKey(KeyCode.A)) { moveLeft = 1; playerSpriteRenderer.sprite = leftProfile; } else moveLeft = 0;

        if (Input.GetKeyDown(KeyCode.Space)) jump = true;

        /*NOTE: jump doesnt really do anything; just moves character closer to camera then back to original position*/
        if (jump && transform.position.z > -3) transform.position += new Vector3(0, 0, -0.3f); else jump = false;
        
        //returning from jump
        if (transform.position.z < 0 && !jump) transform.position += new Vector3(0, 0, 0.3f);

        //create movement vector based on what keys are pressed
        Vector2 movement = new Vector2((moveRight - moveLeft) * movementSpeed, (moveUp - moveDown) * movementSpeed);
        //update player position
        playerRigidBody.position += movement;
    }
}

