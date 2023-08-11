using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    // The lenght of the element with the script
    private float length;

    // The start position of the object with the script
    private float startPosition;

    // A reference to the camera Game Object
    private GameObject camera;

    // The amount of parallax effect made private to the rest of scripts but available to edit in the UI
    [SerializeField] private float parallaxEffect;

    // Start is called before the first frame update
    void Start()
    {
        // Fetch the camera to the Camera
        camera = GameObject.Find("Main Camera");

        // Get the "x" axis position of the object with the script
        startPosition = transform.position.x;

        // Get the lengt of the Sprite Renderer
        length = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        // The position of the object with the script over time
        float temp = (camera.transform.position.x * (1 - parallaxEffect));

        // Distance to move the background acording to the camera and parallax effect amount
        float distance = (camera.transform.position.x * parallaxEffect);

        // Move the "x" axis of the object with the script while maintaing its "y" and "z" vectors
        transform.position = new Vector3(startPosition + distance, transform.position.y, transform.position.z);

        // If the temp value is greater than the start position and the length added, then move the background to the right
        if (temp > startPosition + length)
        {
            startPosition += length;
            // Else, if the temp value is lower than the start position and the length substracted, then move the background to the left
        }
        else if (temp < startPosition - length)
        {
            startPosition -= length;
        }
    }
}
