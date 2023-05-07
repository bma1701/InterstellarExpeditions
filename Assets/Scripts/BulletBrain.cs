using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBrain : MonoBehaviour
{
    public AudioClip asdestroid;
    public AudioClip asteroidBeltHit;
    public AudioClip planetHit;
    //public float Speed = 5f;
    //public float expiryTimer = 6f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //print("Collision Detected!\n");
        
        Destroy(gameObject);
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            Destroy(collision.gameObject); // Destroys asteroids upon laser strike
            AudioSource.PlayClipAtPoint(asdestroid, transform.position); // plays asteroid destruction sound
        }
        if (collision.gameObject.CompareTag("AsteroidBelt"))
        {
            AudioSource.PlayClipAtPoint(asteroidBeltHit, transform.position); // plays asteroid belt laser hit sound
        }
        if (collision.gameObject.CompareTag("Planet1") || collision.gameObject.CompareTag("Planet2") || collision.gameObject.CompareTag("Planet3") || collision.gameObject.CompareTag("Planet4"))
        {
            AudioSource.PlayClipAtPoint(planetHit, transform.position); // plays planet laser hit sound
        }
    }

    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        //transform.position += 
    }

    void Move()
    {
        //Vector3 temp
    } 
    */



}
