using System.Collections;
using UnityEngine;

public class MoveLaser : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    public float duration;
    private float current, target;

    public AudioSource laserActivationSound; // Assign the AudioSource in the Inspector

    // Start is called before the first frame update
    void Start()
    {
        PlayLaserSound(); // Play the sound on activation
        StartCoroutine(Wait());
    }

    // Update is called once per frame
    void Update()
    {
        current = Mathf.MoveTowards(current, target, 0.02f * Time.deltaTime);
        transform.position = Vector3.Lerp(
            pointA.transform.position,
            pointB.transform.position,
            current
        );
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);

        if (target == 0)
        {
            target = 1;
        }
    }

    private void PlayLaserSound()
    {
        if (laserActivationSound != null && !laserActivationSound.isPlaying)
        {
            laserActivationSound.Play();
        }
    }
}