using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level2CutsceneController : MonoBehaviour
{
    public GameObject player;
    public GameObject playerCam;
    public GameObject gameHUD;
    public float time = 0;
    public float lerpTime = 0;
    public GameObject cutsceneCam;
    public GameObject cutscenePoint;
    public GameObject cutsceneEndPoint;
    public GameObject laserWall;

    private bool startAnim;
    public Animator cutsceneAnim;

    private void Update()
    {
        if (startAnim == true)
        {
            lerpTime += 0.09f * Time.deltaTime;
            time += Time.deltaTime;
            cutsceneCam.transform.position = Vector3.Lerp(cutsceneCam.transform.position, cutscenePoint.transform.position, lerpTime);
            cutsceneCam.transform.rotation = Quaternion.Lerp(cutsceneCam.transform.rotation, cutscenePoint.transform.rotation, lerpTime);
            
            if(time > 1.5f)
            {
                cutsceneAnim.enabled = true;
                laserWall.SetActive(true);
            }

            if (time > 7f)
            {
                player.SetActive(true);
                gameHUD.SetActive(true);
                
                Destroy(cutsceneCam);
                Destroy(cutscenePoint);
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            cutsceneCam.SetActive(true);
            cutsceneCam.transform.position = playerCam.transform.position;
            cutsceneCam.transform.rotation = playerCam.transform.rotation;

            player.transform.position = cutsceneEndPoint.transform.position;
            player.transform.rotation = Quaternion.Euler(0, 180, 0);
            playerCam.transform.rotation = Quaternion.Euler(0, 0, 0);

            player.SetActive(false);
            gameHUD.SetActive(false);

            startAnim = true;
        }
    }
}
