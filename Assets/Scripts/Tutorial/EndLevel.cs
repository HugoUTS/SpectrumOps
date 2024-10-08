using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    private bool startEndLevel = false;
    public GameObject playerCamera;
    public GameObject playerController;
    public float lerpTime = 0;
    public Animator elevatorAnim;
    public RevolverChamber revolver;
    public GameObject gunHUD;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startEndLevel == true)
        {
            playerCamera.transform.parent = null;
            revolver.enabled = false;
            gunHUD.SetActive(false);
            Destroy(playerController);
            lerpTime += Time.deltaTime * 0.1f;
            playerCamera.transform.position = Vector3.Lerp(playerCamera.transform.position, transform.position, lerpTime);
            playerCamera.transform.rotation = Quaternion.Lerp(playerCamera.transform.rotation, Quaternion.Euler(0, 0, 0), lerpTime);
        }

        if (lerpTime >= 0.1)
        {
            elevatorAnim.SetTrigger("EndStage");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            startEndLevel = true;
        }
    }
}
