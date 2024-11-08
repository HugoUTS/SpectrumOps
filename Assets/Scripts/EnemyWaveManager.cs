using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveManager : MonoBehaviour
{
    public int kills;
    public bool[] isWaveDone;
    public GameObject[] wave1Objects;
    public GameObject[] wave2Objects;
    public GameObject[] wave3Objects;
    public GameObject lastLight;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < wave1Objects.Length; i++)
        {
            wave1Objects[i].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (kills >= 2)
        {
            if(isWaveDone[0] == false)
            {
                for (int i = 0; i < wave2Objects.Length; i++)
                {
                    wave2Objects[i].SetActive(true);
                }
                isWaveDone[0] = true;
            }
        }

        if (kills >= 5)
        {
            if (isWaveDone[1] == false)
            {
                for (int i = 0; i < wave3Objects.Length; i++)
                {
                    wave3Objects[i].SetActive(true);
                }
                isWaveDone[1] = true;
            }
        }

        if (kills >= 9)
        {
            lastLight.SetActive(true);
        }
    }
}
