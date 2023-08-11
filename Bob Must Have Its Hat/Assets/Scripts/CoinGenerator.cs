using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    // A reference to the coin pool
    public ObjectPooler coinPool;

    public float distanceBetweenCoins;

    // Start is called before the first frame update
    public void SpawnCoins(Vector3 startPosition)
    {
        // Get a coin
        GameObject coin1 = coinPool.GetPooledObject();
        // Set the coin in the game
        coin1.transform.position = startPosition;
        coin1.SetActive(true);

        // Get a coin
        GameObject coin2 = coinPool.GetPooledObject();
        // Set the coin in the game
        coin2.transform.position = new Vector3(startPosition.x - distanceBetweenCoins, startPosition.y, startPosition.z);
        coin2.SetActive(true);


        // Get a coin
        GameObject coin3 = coinPool.GetPooledObject();
        // Set the coin in the game
        coin3.transform.position = new Vector3(startPosition.x + distanceBetweenCoins, startPosition.y, startPosition.z);
        coin3.SetActive(true);
    }
}
