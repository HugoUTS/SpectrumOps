using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects : MonoBehaviour
{
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
