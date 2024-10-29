using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2ActivateTrigger : MonoBehaviour
{
    public GameObject[] triggers;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            for (int i = 0; i < triggers.Length; i++)
            {
                triggers[i].SetActive(true);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        for (int i = 0; i < triggers.Length; i++)
        {
            triggers[i].SetActive(true);
        }
    }
}
