using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float damage;
    public int health;
    public int speed;
    public float knockbackDuration = 100;
    public float knockbackPower = 1;
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
        var obj = collision.gameObject;
        if (obj.CompareTag("Player"))
        {
            obj.GetComponent<PlayerHealth>().TakeDamage(damage);
            StartCoroutine(obj.GetComponent<PlayerHealth>().Knockback(knockbackDuration, knockbackPower, transform));
        }
    }
   public void TakeDamage(int damage)
   {
        health -= damage;
        Debug.Log("damage TAKEN ");
       
   }
}
