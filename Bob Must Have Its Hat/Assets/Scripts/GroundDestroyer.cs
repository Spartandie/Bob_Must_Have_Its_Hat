using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDestroyer : MonoBehaviour
{
    // The point where to destroy the ground
    public GameObject groundDestructionPoint;

    // Start is called before the first frame update
    void Start()
    {
        // Get the ground destruction point from the scene
        groundDestructionPoint = GameObject.Find("GroundDestructionPoint");
    }

    // Update is called once per frame
    void Update()
    {
        // If the position of the scene object is less than the groundDestructionPoint
        if (transform.position.x < groundDestructionPoint.transform.position.x)
        {
            // Then destroy the ground
            Destroy(gameObject);
        }
    }
}
