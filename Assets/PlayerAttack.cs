using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float betAttack;
    public float starttimeAttack;
    public Transform attackPos;
    public LayerMask whatIsEnemeies;
    public float attackRange;
    
    public Animator playerAnim;
    public int damage;
    // Update is called once per frame
    void Update()
    {
        if(betAttack <= 0)
        {
            if(Input.GetMouseButton(0))
            {
                playerAnim.SetTrigger("attack");
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemeies );
                for(int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<EnemyDamage>().TakeDamage(damage);
                }
            }
            betAttack = starttimeAttack;
        }
        else
        {
            betAttack -= Time.deltaTime;
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
