using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelPack : MonoBehaviour
{
    public FloatSO currentFuel;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            currentFuel.Value += 20;
            Destroy(gameObject);
        }
    }
}
