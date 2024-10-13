using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevel : MonoBehaviour
{
    public GameObject[] LevelStartUI;

    public ElevatorController elevator;
    public GameObject EndTrigger;
    public int rescueGoal;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            LevelStartUI[0].SetActive(true);
            LevelStartUI[1].SetActive(true);
            elevator.hostagesGoal = 1;
            EndTrigger.SetActive(true);
            Destroy(gameObject);
        }
    }
}
