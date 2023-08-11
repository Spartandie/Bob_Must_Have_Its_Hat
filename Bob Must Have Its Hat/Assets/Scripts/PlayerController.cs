using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /*
     * The public variables can be seen and modified thru the UI
     */

    // Variable that sets the move speed and jump force aplied to the player, setted in the UI
    public float moveSpeed;
    public float speedLimit;
    public float speedMultiplier;
    public float speedIncreaseDistance;
    private float speedDistanceCounter;
    // Store the 
    /*private float moveSpeedStore;*/
    public float jumpForce;

    // The time the plaer can hold the jump button to jump higher
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

    //public string killBoxTag = "killBox";

    public bool invencibleActive = false;

    public GameManager theGameManager;

    public CharacterDatabase skinsDB;
    private Character characterSkin;
    //public BobController theBob;
    public GameObject theBob;
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


        // Initialize the Ground Check obj
        //groundCheck = GameObject.Find("GroundCheck");

        /*moveSpeedStore = moveSpeed;
        speedMilestoneCounter*/
        speedDistanceCounter = speedIncreaseDistance;

        string skinEquiped = PlayerPrefs.GetString("PlayerEquipedSkin");
        //Debug.Log(skinEquiped);
        //Debug.Log(skinsDB.CharacterCount);
        
        for (int i = 0; i < skinsDB.CharacterCount; i++)
        {
            if(skinEquiped == skinsDB.GetCharacter(i).characterName)
            {
                characterSkin = skinsDB.GetCharacter(i);//Get the character i from the charactersDB
            }
            Debug.Log(skinsDB.GetCharacter(i).characterName);
        }
        SpriteRenderer playerSprite = GetComponent<SpriteRenderer>();
        playerSprite.sprite = characterSkin.characterSprite;  //Nuestra skin;

        SpriteRenderer bobSprite = theBob.GetComponent<SpriteRenderer>();
        bobSprite.sprite = characterSkin.bobHatlessCharacterSprite;
        bobSprite.transform.localScale += new Vector3(-0.3f, -0.3f, -0.3f);
        //theBob.bobSprite.sprite = characterSkin.bobHatlessCharacterSprite;
        //theBob.bobSprite.transform.localScale += new Vector3(-0.3f, -0.3f, -0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        // Check in what the player is standing at this frame
        //grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);
        // grounded is equal to the state of a circle in the position of our groundCheck obj with groundCheckRadius radious and 
        // comparing if its touchin whatIsGround
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        if (transform.position.x > speedDistanceCounter && moveSpeed < speedLimit)
        {
            speedDistanceCounter += speedIncreaseDistance;

            speedIncreaseDistance *= speedMultiplier;

            moveSpeed *= speedMultiplier;
        }

        // Aply a force in the "x" axis of the player while maintaining it�s velocity in the "y" axis
        player.velocity = new Vector2( moveSpeed, player.velocity.y );

        /*
         *  If SPACE, LEFT-CLICK, UP-ARROW or W are pressed and the player is in the ground, he can jump 
        */
        if( Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || Input.GetKey("up") || Input.GetKey("w") )
        {
            if( grounded )
            {
                // Maintaining the player "x" axis velocity while adding a jumpforce equal to the jump force value in the "y" axis
                player.velocity = new Vector2(player.velocity.x, jumpForce);
                theSFXManager.PlayJumpSound();
            }
        }
        /*
        // If the player wants to jump and is holding down the jump key
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || Input.GetKey("up") || Input.GetKey("w"))
        {
            if(jumpTimeCounter > 0)
            {
                // Apply the jumpForce in the "y" axis of the player while maintaining his "x" axis vector
                player.velocity = new Vector2(player.velocity.x, jumpForce);

                // Subtract values to jumpTimeCounter based on time
                jumpTimeCounter -= jumpTime * Time.deltaTime;
            }
        }
        
        // To avoid infinite jump/flying
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || Input.GetKey("up") || Input.GetKey("w"))
        {
            jumpTimeCounter = 0;
        }

        // To avoid infinite jump/flying
        if ( grounded )
        {
            jumpTimeCounter = jumpTime;
        }
        */
    }

    // When a obj with a box collider touches another obj with a box collider
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //Collider2D other2DCollider;

        // If our player collides with a game obj that have the "killBox" tag
        if(!invencibleActive && collision.gameObject.tag == "killBox")//killboxTag == "killBox" && 
        {
            // Restart the game
            theGameManager.RestartGame();
        }

        /*
        if (killboxTag == "passThru" && other.gameObject.tag == killBoxTag)
        {
            // Set the 2D collider to trigger
            other2DCollider = GetComponent<Collider2D>();
            other2DCollider.isTrigger = true;
        }
        */

        if (invencibleActive && (collision.gameObject.name == "wall" || collision.gameObject.name == "spikes" || collision.gameObject.name == "pothole"))
        {
            collision.gameObject.GetComponent<Collider2D>().isTrigger = true;
        }
    }
}
