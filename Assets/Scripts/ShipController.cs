using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector2 startPos;
    private Quaternion startRotation;
    public AudioClip onDeathExpl; // Death Explosion Sound
    public AudioClip laserGunSound; // LaserCannon shoot sound
    public float maxVelocity;
    public float rotationSpeed;
    public float currentFuel;
    public float startingFuel = 60f;
    public FuelScript fuelBar;
    AudioSource thrusters; // thruster sound
    bool t_playing; 
    bool isDead = false; // bool for checking if ship is alive
    
    public PShipCannons cannons; // reference to the laser cannon object
    bool canShoot = true;
    public float shootDelay;
    //bool t_changed;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        currentFuel = startingFuel;
        fuelBar.SetMaxFuel(startingFuel);
        startRotation = transform.rotation;
        thrusters = GetComponent<AudioSource>();
    }

    private void Update()
    {
        float yAxis = Input.GetAxis("Vertical");
        float xAxis = Input.GetAxis("Horizontal");
        if(yAxis < 0)
            yAxis = 0;
        if(rb.simulated)
            ThrustForward(yAxis);
        Rotate(transform, xAxis * rotationSpeed);
        ClampVelocity();
        if(currentFuel <= 9.5f)
        {
            Die();
        }
        if(Input.GetKeyDown(KeyCode.P))
        {
            currentFuel = 200f;
            fuelBar.SetFuel(currentFuel);
        }
        if(Input.GetKey(KeyCode.W))
        {
            if (!isDead)
            {
                if (!thrusters.isPlaying)
                {
                    //AudioSource.Play(thrusters);
                    thrusters.Play();
                }
            }
        }
        if(Input.GetKeyUp(KeyCode.W))
        {
            thrusters.Stop();
            //thrusters.Pause();
        }
        if (Input.GetKey("space") || Input.GetMouseButton(0))
        {
            if (!isDead)
            {
                if(canShoot)
                {
                    AudioSource.PlayClipAtPoint(laserGunSound, transform.position);
                    cannons.Shoot(transform.rotation);
                    StartCoroutine(ShootTimer());
                }
                
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*
        if (collision.gameObject.CompareTag("EnemyLaser"))
        {
        // play audio of laser hitting ship?
        Die();
        Destroy(collision.gameObject);

        } 
         */

        if (collision.gameObject.CompareTag("Asteroid"))
        {
            Die();
            Destroy(collision.gameObject); // Destroys asteroid belt, not intended. (fixed)

        }
        if (collision.gameObject.CompareTag("AsteroidBelt"))
        {
            Die();
            //Destroy(collision.gameObject); // Destroys asteroid belt, not intended.
        }
        else if (collision.gameObject.CompareTag("Planet1"))
            SceneManager.LoadScene("Scenes/Planet1");
        else if (collision.gameObject.CompareTag("Planet2"))
            SceneManager.LoadScene("Scenes/Planet2");
        else if (collision.gameObject.CompareTag("Planet3"))
            SceneManager.LoadScene("Scenes/Planet3");
        else if (collision.gameObject.CompareTag("Planet4"))
            SceneManager.LoadScene("Scenes/Planet4");
    }

    private void ClampVelocity()
    {
        float x = Mathf.Clamp(rb.velocity.x, -maxVelocity, maxVelocity);
        float y = Mathf.Clamp(rb.velocity.y, -maxVelocity, maxVelocity);

        rb.velocity = new Vector2(x,y);
    }

    private void ThrustForward(float amount)
    {
        Vector2 force = transform.up * amount;
        rb.AddForce(force * 3
            );
        currentFuel -= amount * 8 * Time.deltaTime;
        fuelBar.SetFuel(currentFuel);
    }

    private void Rotate(Transform t, float amount)
    {
        t.Rotate(0, 0, amount);
    }

    private void Die()
    {
        if (thrusters.isPlaying)
        {
            thrusters.Stop();
        }
        AudioSource.PlayClipAtPoint(onDeathExpl, transform.position);
        currentFuel = startingFuel;
        StartCoroutine(Respawn(3f));
    }

    IEnumerator Respawn(float duration)
    {
        isDead = true;
        rb.simulated = false;
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0;
        transform.rotation = startRotation;
        transform.localScale = new Vector3(0,0,0);
        yield return new WaitForSeconds(duration);
        transform.position = startPos;
        isDead = false;
        transform.localScale = new Vector3(4,4,1);
        rb.simulated = true;
        fuelBar.SetFuel(currentFuel);
    }

    IEnumerator ShootTimer()
    {
        print("Waiting...\n");
        canShoot = false;
        yield return new WaitForSeconds(shootDelay);
        canShoot = true;
    }

}
