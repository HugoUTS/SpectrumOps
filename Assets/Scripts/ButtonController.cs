using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public string tagName = "Projectile";
    public UnlockTally unlockTarget;
    public bool activated = false;
    public Material onColor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == tagName)
        {
            if (activated == false)
            {
                unlockTarget.buttonsLeft -= 1;
                activated = true;
                gameObject.GetComponent<MeshRenderer>().material = onColor;
            }
        }
    }
}
