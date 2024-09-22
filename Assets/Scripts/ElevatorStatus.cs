using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorStatus : MonoBehaviour
{
    public Animator elevatorAnim; // To access the elevator's animations
    public int hostagesLeft = 1; // To record how many hostages are remaining before the elevator opens
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hostagesLeft <= 0)
        {
            elevatorAnim.SetBool("Open",true);
        }
    }
}
