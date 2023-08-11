using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    // Variable that says if the player is touching the ground or not
    public static bool isGrounded;

    // Note that this script doesnt have the Start and Update methods

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // The player is touching the ground
        isGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // The player is not touching the ground
        isGrounded = false;
    }
}
