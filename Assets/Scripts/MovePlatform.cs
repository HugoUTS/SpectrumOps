using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    public float speed;
    public float current, target;

    //public AudioSource platformAudioSource; // Reference to the AudioSource component
    //public AudioClip moveSound; // The sound to play when the platform moves

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
}
