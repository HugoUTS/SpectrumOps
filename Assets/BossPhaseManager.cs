using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPhaseManager : MonoBehaviour
{
    public int phase = 0;
    public Animator levelAnim;
    public GameObject[] wave1Objects;
    public GameObject[] wave2Objects;
    public GameObject[] wave3Objects;
    public GameObject[] wave4Objects;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartPhase1()
    {
        for (int i = 0; i < wave1Objects.Length; i++)
        {
            wave1Objects[i].SetActive(true);
        }
    }

    public void StartPhase2()
    {
        for (int i = 0; i < wave2Objects.Length; i++)
        {
            wave2Objects[i].SetActive(true);
        }
    }

    public void StartPhase3()
    {
        for (int i = 0; i < wave3Objects.Length; i++)
        {
            wave3Objects[i].SetActive(true);
        }
    }

    public void StartPhase4()
    {
        for (int i = 0; i < wave4Objects.Length; i++)
        {
            wave4Objects[i].SetActive(true);
        }
    }
}
