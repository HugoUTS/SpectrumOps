using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level3CutsceneController : MonoBehaviour
{
    public GameObject player;
    public GameObject playerCam;
    public GameObject cutsceneCam;
    public GameObject gameHUD;

    private bool startAnim = false;
    public Animator cutsceneAnim;

    private void Update()
    {
        if (startAnim == true)
        {
            cutsceneAnim.enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            player.SetActive(false);
            gameHUD.SetActive(false);
            cutsceneCam.SetActive(true);

            startAnim = true;
        }
    }
}
