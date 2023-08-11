using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Create an instance to get the player
    public PlayerController player;

    // Variable to store the last position of the player
    private Vector3 lastPlayerPosition;

    // Variable to store the distance to move the camera so it follows the player
    private float distanceToMove;

    // Start is called before the first frame update
    void Start()
    {
        // Get the player in the scene
        player = FindObjectOfType<PlayerController>();

        // Set the position of the player to the lastPlayerPosition variable
        lastPlayerPosition = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Get the distance to move the camera
        distanceToMove = player.transform.position.x - lastPlayerPosition.x;

        // Move the camera
        transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);

        // Set the lastPlayerPosition to the current position, so the movement continues thru the update loop
        lastPlayerPosition = player.transform.position;
    }
}
