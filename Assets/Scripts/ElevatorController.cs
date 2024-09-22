using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    public int hostagesLeft = 1; // Must be zero to open the elevator
    public Animator elevatorAnim; // To access the elevator's animator component

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hostagesLeft <= 0)
        {
            elevatorAnim.SetBool("IsOpen", true);
        }
        else
        {
            elevatorAnim.SetBool("IsOpen", false);
        }
    }
}
