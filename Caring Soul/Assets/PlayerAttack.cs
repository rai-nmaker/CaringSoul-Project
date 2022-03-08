using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public Animator animator;

    public Transform attackPoint;
    public LayerMask enemylayers;

    public float attackRange = 0.5f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    void Attack()
    {
        // Attack animation 
        animator.SetTrigger("Attack");

        // Detect enemy
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemylayers);

        // Damage enemy
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(40);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
