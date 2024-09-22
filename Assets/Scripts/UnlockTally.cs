using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockTally : MonoBehaviour
{
    public int buttonsLeft;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonsLeft <= 0)
        {
            Destroy(gameObject);
        }
    }
}
