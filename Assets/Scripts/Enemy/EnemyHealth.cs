using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100f;           // Enemy's health
    public string enemyColor;             // Either "Red" or "Blue"

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        // Destroy the enemy or trigger death animations
        Destroy(gameObject);
    }
}

