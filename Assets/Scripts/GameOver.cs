using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject deathCamera;
    public GameObject deathUI;
    public GameObject camera;
    public GameObject[] objects;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            // create the new object
            var newObject = Instantiate(deathCamera, gameObject.transform.position, camera.transform.rotation);
            Instantiate(deathUI);

            // give it the same velocity as the current object
            newObject.GetComponent<Rigidbody>().velocity = gameObject.GetComponent<Rigidbody>().velocity;
            newObject.GetComponent<Rigidbody>().angularVelocity = gameObject.GetComponent<Rigidbody>().angularVelocity;

            for (int i = 0; i < objects.Length; i++)
            {
                Destroy(objects[i]);
            }

            // destroy this object
            Destroy(gameObject);
        }
    }
}
