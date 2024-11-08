using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3CloseDoors : MonoBehaviour
{
    public GameObject player;
    public GameObject gameHUD;
    public GameObject cutsceneObject;

    public Animator frontDoorAnim;
    public Animator backDoorAnim;

    public EnemyWaveManager waveManager;
    public void CloseFrontDoor()
    {
        frontDoorAnim.enabled = true;
    }

    public void CloseBackDoor()
    {
        backDoorAnim.enabled = true;
    }

    public void EndCutscene()
    {
        player.SetActive(true);
        gameHUD.SetActive(true);
        waveManager.enabled = true;

        Destroy(cutsceneObject);
    }
}
