using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobController : MonoBehaviour
{
    // The public variables can be seen and modified thru the UI

    // Group of variables that set the move speed of "the bob", setted in the UI
    public float moveSpeed;
    public float speedLimit;
    public float speedMultiplier;
    public float speedIncreaseDistance;
    private float speedDistanceCounter;

    // The rigidbody of the bob, used for movement and physics
    private Rigidbody2D bob;

    // A Game Manager reference
    public GameManager theGameManager;

    // A Player Controller reference
    public PlayerController thePlayerController;

    // A reference to the Sprite of bob
    public SpriteRenderer bobSprite;

    // Start is called before the first frame update
    void Start()
    {
        // Get the bob rigidbody
        bob = GetComponent<Rigidbody2D>();

        // Set the inital move speed for Bob
        moveSpeed = theGameManager.startSpeed;

        // Set the inital Sprite for Bob
        bobSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Change the Bob move speed to match the player speed, so he is always catching up
        moveSpeed = thePlayerController.moveSpeed;

        // Aply a force in the "x" axis of Bob while maintaining it´s velocity in the "y" axis
        bob.velocity = new Vector2(moveSpeed, bob.velocity.y);
    }

}

