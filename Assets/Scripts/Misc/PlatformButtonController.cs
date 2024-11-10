using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformButtonController : MonoBehaviour
{
    // Start is called before the first frame update
    public string tagName = "Projectile";     // Tag to identify the bullet
    public Material buttonMaterial;           // Material assigned to the button (set this in the Inspector
    public MovePlatform platform;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == tagName)
        {
            // Switch target for platform movement
            platform.target = (platform.target == 0) ? 1 : 0;
        }
    }
}
