using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public int spawnRate = 10;
    private Vector3 randomPosition;
    private int spawn;

    void Start()
    {
        spawnRate = 1000 - spawnRate;
    }

    // Update is called once per frame
    void Update()
    {
        spawn = Random.Range(0, spawnRate);
        if(spawn == 7)
        {
            int NSEW = Random.Range(0,10);
            if(NSEW == 0)
            {
                randomPosition = new Vector3(Random.Range(-40, 40), 40, 0);
                GameObject objectClone = Instantiate(asteroidPrefab, randomPosition, Quaternion.identity);
                objectClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-5, 5), -5));
            }
            else if(NSEW == 1)
            {
                randomPosition = new Vector3(Random.Range(-40, 40), -40, 0);
                GameObject objectClone = Instantiate(asteroidPrefab, randomPosition, Quaternion.identity);
                objectClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-5, 5), 5));
            }
            else if(NSEW == 2)
            {
                randomPosition = new Vector3(-40, Random.Range(-40, 40), 0);
                GameObject objectClone = Instantiate(asteroidPrefab, randomPosition, Quaternion.identity);
                objectClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(5, Random.Range(-5, 5)));
            }
            else if(NSEW == 3)
            {
                randomPosition = new Vector3(40, Random.Range(-40, 40), 0);
                GameObject objectClone = Instantiate(asteroidPrefab, randomPosition, Quaternion.identity);
                objectClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(-5, Random.Range(-5, 5)));
            }
            
        }
    }
}
