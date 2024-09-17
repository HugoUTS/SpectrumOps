using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float damage = 20f; // Damage per hit
    public float attackRange = 2f; // Range within which the enemy can attack
    public float attackCooldown = 1f; // Time between attacks
    private float nextAttackTime = 0f; // Track when the enemy can attack again

    private void Update()
    {
        // Check distance between enemy and player
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);

            // If within attack range and cooldown allows
            if (distance <= attackRange && Time.time >= nextAttackTime)
            {
                // Attack the player
                PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(damage);
                    nextAttackTime = Time.time + attackCooldown;
                }
            }
        }
    }
}
