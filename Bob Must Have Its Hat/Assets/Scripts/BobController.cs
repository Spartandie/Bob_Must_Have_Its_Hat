using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobController : MonoBehaviour
{
    /*
     * The public variables can be seen and modified thru the UI
     */

    // Variable that sets the move speed and jump force aplied to the bob, setted in the UI
    public float moveSpeed;
    public float speedLimit;
    public float speedMultiplier;
    public float speedIncreaseDistance;
    private float speedDistanceCounter;

    // The rigidbody of the bob, used for movement and physics
    private Rigidbody2D bob;
    public GameManager theGameManager;
    public PlayerController thePlayerController;
    public SpriteRenderer bobSprite;

    // Start is called before the first frame update
    void Start()
    {

        // Get the bob rigidbody
        bob = GetComponent<Rigidbody2D>();

        //thePlayerController = FindObjectOfType<PlayerController>();

        moveSpeed = theGameManager.startSpeed;
        //speedLimit = thePlayerController.speedLimit;
        //speedMultiplier = thePlayerController.speedMultiplier;
        //speedIncreaseDistance = thePlayerController.speedIncreaseDistance;
        //speedDistanceCounter = speedIncreaseDistance;

        bobSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (transform.position.x > speedDistanceCounter && moveSpeed < speedLimit)
        {
            speedDistanceCounter += speedIncreaseDistance;

            speedIncreaseDistance *= speedMultiplier;

            moveSpeed *= speedMultiplier;
        }
        */
        // Aply a force in the "x" axis of the bob while maintaining it´s velocity in the "y" axis
        //bob.velocity = new Vector2(moveSpeed, bob.velocity.y);
        moveSpeed = thePlayerController.moveSpeed;
        bob.velocity = new Vector2(moveSpeed, bob.velocity.y);


    }

}

