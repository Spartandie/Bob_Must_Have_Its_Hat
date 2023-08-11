using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    // Get the ground objects
    public GameObject theGround;

    // Create the instance of the floor generation point
    public Transform generationPoint;

    // The distance between ground
    public float distanceBetween;
    public float distanceBetweenMin;
    public float distanceBetweenMax;

    // The width of the ground to generate
    private float groundWidth;

    // Ground array
    public GameObject[] theGroundArray;

    // Counter that will select wich ground is generated
    private int groundSelector;

    // List of the diferent ground widths
    private float[] groundWidths;

    // A reference to the Object Pool
    public ObjectPooler theObjectPool;

    // A array of Object Poolers
    public ObjectPooler[] theObjectPools;

    // A reference to the coin generator
    private CoinGenerator theCoinGenerator;

    // Start is called before the first frame update
    void Start()
    {
        // Set the width of the ground
        groundWidth = theGround.GetComponent<BoxCollider2D>().size.x;

        // Here we set the coin generator using FindObjectOfType, in this way Unity handle the search of the desired object
        // so we dont have to do it manually using the UI
        theCoinGenerator = FindObjectOfType<CoinGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        // If the generation point is behind the transform.position.x, generate more ground ahead
        if (transform.position.x < generationPoint.position.x)
        {
            // Random distance between platforms generation
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

            // Move the position of the object
            transform.position = new Vector3(transform.position.x + groundWidth + distanceBetween, transform.position.y, transform.position.z);

            groundSelector = Random.Range(0, theGroundArray.Length);

            // Create the ground
            Instantiate(theGroundArray[groundSelector], transform.position, transform.rotation);

            // Add coins
            theCoinGenerator.SpawnCoins(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z));
        }
    }
}
