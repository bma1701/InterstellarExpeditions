using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public FloatSO currentHealth;
    public float maxHealth = 100;
    private Rigidbody2D rb;
    private Vector2 startPos;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth.Value = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
    }
    public void TakeDamage(float damage)
    {
        currentHealth.Value -= damage;
        if (currentHealth.Value <=0)
        {
            Die();
        }
    }
    private void Die()
    {
        currentHealth.Value = maxHealth;
        StartCoroutine(Respawn(3f));
    }

    IEnumerator Respawn(float duration)
    {
        rb.simulated = false;
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0;
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(duration);
        transform.position = startPos;
        GetComponent<SpriteRenderer>().enabled = true;
        rb.simulated = true;
    }

    public IEnumerator Knockback(float knockbackDuration, float knockbackPower, Transform obj)
    {
        float timer = 0;

        while(knockbackDuration > timer)
        {
            timer += Time.deltaTime;
            Vector2 direction = (obj.position - transform.position).normalized;
            rb.AddForce(-direction * knockbackPower);
        }
        yield return 0;
    }
}
