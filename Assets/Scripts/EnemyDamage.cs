using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float damage;
    public int health;
    public int speed;
    public PlayerHealth playerHealth;
   

   void Update()
   {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector2.left * speed * Time.deltaTime);
   }
   private void OnCollisionEnter2D(Collision2D collision)
   {
        if(collision.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(damage);
        }
   }
   public void TakeDamage(int damage)
   {
        health -= damage;
        Debug.Log("damage TAKEN ");
       
   }
}
