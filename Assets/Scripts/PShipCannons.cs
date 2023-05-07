using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PShipCannons : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform BSP;
    public float fireForce = 15f;
    
    public void Shoot(Quaternion angler)
    {
        GameObject laser = Instantiate(bulletPrefab, BSP.position, angler);
        laser.GetComponent<Rigidbody2D>().AddForce(BSP.up * fireForce, ForceMode2D.Impulse);
        print("Firing!\n");
    }


    /*
     // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    } */
}
