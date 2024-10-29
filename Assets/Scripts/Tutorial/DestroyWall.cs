using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWall : MonoBehaviour
{
    public string tagName = "Projectile";      // Tag of the bullet
    public GameObject destroyedWall;           // Broken wall prefab
    public AudioClip destructionClip;          // Sound effect for the destruction
    public float soundVolume = 1.0f;           // Volume for the destruction sound

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == tagName || collision.gameObject.tag == "Laser")
        {
            // Play the destruction sound at the wall's position without requiring the wall to exist afterward
            AudioSource.PlayClipAtPoint(destructionClip, transform.position, soundVolume);

            // Instantiate the broken wall prefab immediately
            GameObject brokenWall = Instantiate(destroyedWall, transform.position, transform.rotation);

            brokenWall.transform.localScale = new Vector3(transform.localScale.x, gameObject.transform.localScale.y * 0.2f, gameObject.transform.localScale.z * 0.2f);

            // Destroy the original wall object immediately
            Destroy(gameObject);
        }
    }
    
}