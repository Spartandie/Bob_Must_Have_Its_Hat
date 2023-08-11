using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /*
     * The public variables can be seen and modified thru the UI
     */

    // Variables that set the move speed and jump force aplied to the player, setted in the UI
    public float moveSpeed;
    public float speedLimit;
    public float speedMultiplier;
    public float speedIncreaseDistance;
    private float speedDistanceCounter;
    public float jumpForce;

    // The time the player can hold the jump button to jump higher
    public float jumpTime;
    private float jumpTimeCounter;

    // The rigidbody of the player, used for movement and physics
    private Rigidbody2D player;

    // Bool to see if the player is in the ground
    public bool grounded;

    // The layer wich is suposed to act as ground to let the player jump when standing on it
    public LayerMask whatIsGround;

    // Our Ground Ckeck obj inside the player
    public Transform groundCheck;

    // The radius of the Ground Check circle beneath out player
    public float groundCheckRadius;

    // Collider to register if the player is touching the floor
    private Collider2D myCollider;

    public bool invencibleActive = false;

    // The Game Manager reference
    public GameManager theGameManager;

    // A reference to the Character database
    public CharacterDatabase skinsDB;

    // A reference to the Character (skin of the player)
    private Character characterSkin;

    // A reference to "the bob" Game Object
    public GameObject theBob;

    // A reference to the SFX Manager
    public SFXManager theSFXManager;

    // Start is called before the first frame update
    void Start()
    {

        // Get the player rigidbody
        player = GetComponent<Rigidbody2D>();

        // Get the collider of the player
        myCollider = GetComponent<Collider2D>();

        // Initialize jumpTimeCounter
        jumpTimeCounter = jumpTime;

        // Set the speedDistanceCounter to later on increase the movement speed of the player
        speedDistanceCounter = speedIncreaseDistance;

        // Get the skin equiped of the player
        string skinEquiped = PlayerPrefs.GetString("PlayerEquipedSkin");

        // For each skin in our skins database search four our equiped skin and set it to the "characterSkin" of our player 
        for (int i = 0; i < skinsDB.CharacterCount; i++)
        {
            // If the name of our equiped skin is equal to the "i" skin at our skins database
            if (skinEquiped == skinsDB.GetCharacter(i).characterName)
            {
                //Get the character i from the charactersDB
                characterSkin = skinsDB.GetCharacter(i);
            }
        }

        // Create a Sprite Renderer for the player skin
        SpriteRenderer playerSprite = GetComponent<SpriteRenderer>();

        // Set the player equiped skin
        playerSprite.sprite = characterSkin.characterSprite;

        // Create a Sprite Renderer for "the bob" skin
        SpriteRenderer bobSprite = theBob.GetComponent<SpriteRenderer>();

        // Set the bob equiped skin
        bobSprite.sprite = characterSkin.bobHatlessCharacterSprite;
        bobSprite.transform.localScale += new Vector3(-0.3f, -0.3f, -0.3f);
    }

    // Update is called once per frame
    void Update()
    {

        // Grounded state depends of the circle in the position of our groundCheck object with groundCheckRadius radius and 
        // comparing if it's touching whatIsGround
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        // If the player is beyond the "speedDistanceCounter" and it's move speed is not above the speed limit
        if (transform.position.x > speedDistanceCounter && moveSpeed < speedLimit)
        {
            // Increase the "speedDistanceCounter" by "speedIncreaseDistance" so the speed increments in x + y meters next time (more distance)
            speedDistanceCounter += speedIncreaseDistance;

            // Change the value of the "speedIncreaseDistance" using the speedMultiplier
            speedIncreaseDistance *= speedMultiplier;

            // Change the value of the "moveSpeed" using the speedMultiplier
            moveSpeed *= speedMultiplier;
        }

        // Aply a force in the "x" axis of the player while maintaining it�s velocity in the "y" axis
        player.velocity = new Vector2(moveSpeed, player.velocity.y);

        /*
         *  If SPACE, LEFT-CLICK, UP-ARROW or W are pressed and the player is in the ground, he can jump 
        */
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || Input.GetKey("up") || Input.GetKey("w"))
        {
            if (grounded)
            {
                // Maintaining the player "x" axis velocity while adding a jumpforce equal to the jump force value in the "y" axis
                player.velocity = new Vector2(player.velocity.x, jumpForce);
                theSFXManager.PlayJumpSound();
            }
        }
    }

    // When a object with a box collider touches another object with a box collider
    public void OnCollisionEnter2D(Collision2D collision)
    {
        // If our player collides with a Game object that have the "killBox" tag
        if (!invencibleActive && collision.gameObject.tag == "killBox")//killboxTag == "killBox" && 
        {
            // Restart the game
            theGameManager.RestartGame();
        }

        // If the player is invencible and collides with a wall, spikes or pothole, set the collision GO trigger to true
        if (invencibleActive && (collision.gameObject.name == "wall" || collision.gameObject.name == "spikes" || collision.gameObject.name == "pothole"))
        {
            collision.gameObject.GetComponent<Collider2D>().isTrigger = true;
        }
    }
}
