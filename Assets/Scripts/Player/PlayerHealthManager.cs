using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour
{
    public float playerHealth;
    public int playerMaxHealth = 100;

    public Image healthBar;

    public GameObject deathCamera;
    public GameObject deathUI;
    public GameObject camera;
    public GameObject[] objects;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = playerMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = playerHealth / playerMaxHealth;
        if(playerHealth <= 0)
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

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "ProjectileRed":
                playerHealth -= 20;
                break;
            case "ProjectileYellow":
                playerHealth -= 20;
                break;
            case "ProjectileGreen":
                playerHealth -= 20;
                break;
            case "ProjectileBlue":
                playerHealth -= 20;
                break;
        }
    }
}
