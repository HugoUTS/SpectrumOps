using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2ActivateTrigger : MonoBehaviour
{
    public GameObject[] triggers;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            for (int i = 0; i < triggers.Length; i++)
            {
                triggers[i].SetActive(true);
            }
        }
    }
}
