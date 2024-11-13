using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorManager : MonoBehaviour
{
    public bool isDestroyed = false;
    public string tagName = "Projectile"; // Tag of the bullet
    public BossPhaseManager bossManager;

    public Material destroyedMaterial;
    public MeshRenderer[] rend;

    public GameObject connectedLaser;

    public AudioSource destroyedSound;

    private void Start()
    {
        for (int i = 0; i < rend.Length; i++)
        {
            rend[i].enabled = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == tagName || collision.gameObject.tag == "Laser")
        {
            if(isDestroyed == false)
            {
                for (int i = 0; i < rend.Length; i++)
                {
                    rend[i].material = destroyedMaterial;
                }
                bossManager.levelAnim.SetInteger("PhaseInt", bossManager.levelAnim.GetInteger("PhaseInt") + 1);
                connectedLaser.SetActive(false);
                destroyedSound.Play();
                isDestroyed = true;
            }
        }
    }
}
