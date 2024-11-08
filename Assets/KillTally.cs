using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillTally : MonoBehaviour
{
    public string tagName = "Projectile";     // Tag to identify the bullet
    public EnemyWaveManager waveManager;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == tagName || collision.gameObject.tag == "Laser")
        {
            waveManager.kills += 1;
        }
    }
}