using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{

    public GameObject pooledObject;

    public int pooledAmount;

    // List of our pooled Game Objects
    List<GameObject> pooledObjects;

    // Start is called before the first frame update
    void Start()
    {
        // Create a list for our pooled rojects
        pooledObjects = new List<GameObject>();

        // For each number in the "pooledAmount" variable, add a new Game Object to the Pooled Objects list
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(pooledObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Function that return a Game Object
    public GameObject GetPooledObject()
    {
        // For each pooled object
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            // If the obj is active in the scene
            if (pooledObjects[i].activeInHierarchy)
            {
                // Return the pooled object
                return pooledObjects[i];
            }
        }

        // Else, add a new object and return it
        GameObject obj = (GameObject)Instantiate(pooledObject);
        obj.SetActive(false);
        pooledObjects.Add(obj);

        return obj;
    }
}
