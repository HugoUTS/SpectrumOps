using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWall : MonoBehaviour
{
    public string tagName = "Projectile";
    public GameObject destroyedWall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == tagName)
        {
            Instantiate(destroyedWall,gameObject.transform.position,gameObject.transform.rotation);
            Destroy(gameObject);
        }
    }
}
