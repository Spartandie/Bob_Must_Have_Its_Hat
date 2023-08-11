using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    // Variable that says if the player is touching the ground or not
    public static bool isGrounded;

    // Function that identifies if the player is touching the ground
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // The player is touching the ground
        isGrounded = true;
    }

    // Function that identifies if the player is at the air
    private void OnTriggerExit2D(Collider2D collision)
    {
        // The player is not touching the ground
        isGrounded = false;
    }
}
