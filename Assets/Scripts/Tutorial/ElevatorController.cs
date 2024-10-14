using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ElevatorController : MonoBehaviour
{
    public int hostagesRescued = 1; // Must be zero to open the elevator
    public int hostagesGoal = 1;
    public Animator elevatorAnim; // To access the elevator's animator component
    public TextMeshProUGUI rescueText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hostagesRescued >= hostagesGoal)
        {
            elevatorAnim.SetBool("IsOpen", true);
            if(rescueText != null)
            {
                rescueText.text = "Return to elevator";
            }
        }
        else
        {
            elevatorAnim.SetBool("IsOpen", false);
            if (rescueText != null)
            {
                rescueText.text = hostagesRescued + "/" + hostagesGoal + " Rescued";
            }
        }
    }
}
