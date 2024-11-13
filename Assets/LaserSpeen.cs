using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpeen : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0, 0.06f, 0);
    }
}
