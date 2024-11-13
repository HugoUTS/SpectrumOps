using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePhaseTrigger : MonoBehaviour
{
    public BossPhaseManager bossManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            bossManager.levelAnim.SetInteger("PhaseInt", bossManager.levelAnim.GetInteger("PhaseInt") + 1);
            Destroy(gameObject);
        }
    }
}
