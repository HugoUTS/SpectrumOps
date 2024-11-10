using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootToMovePlatform : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    public float speed;
    private float current, target;

    public string tag;
    public AudioSource platformAudioSource; // Reference to the AudioSource component
    public AudioClip moveSound; // The sound to play when the platform moves

    // Start is called before the first frame update
    void Start()
    {
        // Ensure the target starts at 0
        target = 0;
    }

    // Update is called once per frame
    void Update()
    {
        current = Mathf.MoveTowards(current, target, speed * Time.deltaTime);
        transform.position = Vector3.Lerp(pointA.transform.position, pointB.transform.position, current);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the correct bullet
        if (collision.gameObject.tag == tag)
        {
            // Switch target for platform movement
            target = (target == 0) ? 1 : 0;

            // Play the sound if the platformAudioSource and moveSound are assigned
            if (platformAudioSource != null && moveSound != null)
            {
                platformAudioSource.PlayOneShot(moveSound);
            }
        }
    }
}