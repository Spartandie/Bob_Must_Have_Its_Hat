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

    private float[] groundWidths;

    public ObjectPooler theObjectPool;

    public ObjectPooler[] theObjectPools;

    private CoinGenerator theCoinGenerator;

    // Start is called before the first frame update
    void Start()
    {
        // Width of the ground
        groundWidth = theGround.GetComponent<BoxCollider2D>().size.x;
        /*
        groundWidths = new float[theObjectPools.Length];

        for(int i = 0; i < theObjectPools.Length; i++)
        {
            groundWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }
        */
        /*
        groundWidths = new float[theGroundArray.Length];

        for (int i = 0; i < theGroundArray.Length; i++)
        {
            groundWidths[i] = theGroundArray[i].GetComponent<BoxCollider2D>().size.x;
        }
        */
        theCoinGenerator = FindObjectOfType<CoinGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        // If the generation point is behind the transform.position.x, generate more ground ahead
        if ( transform.position.x < generationPoint.position.x)
        {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);


            // Move the position of the object
            transform.position = new Vector3(transform.position.x + groundWidth + distanceBetween, transform.position.y, transform.position.z);
            
            groundSelector = Random.Range(0, /*theObjectPools*/theGroundArray.Length);

            // Create the ground
            Instantiate(theGroundArray[groundSelector], transform.position, transform.rotation);
            /*
            GameObject newGround = theObjectPools[groundSelector].GetPooledObject();

            newGround.transform.position = transform.position;
            newGround.transform.rotation = transform.rotation;
            newGround.SetActive(true);

            transform.position = new Vector3(transform.position.x + (groundWidths[groundSelector] / 2), transform.position.y, transform.position.z);
            */
            theCoinGenerator.SpawnCoins(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z));
        }
    }
}
