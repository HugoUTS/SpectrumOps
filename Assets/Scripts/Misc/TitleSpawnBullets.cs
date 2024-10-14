using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSpawnBullets : MonoBehaviour
{
    public GameObject[] bullets;
    public float spawnTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime += Time.deltaTime;
        if(spawnTime >= 0.3f)
        {
            GameObject bullet = Instantiate(bullets[Random.Range(0,4)], new Vector3(gameObject.transform.position.x + Random.Range(-20, 20), gameObject.transform.position.y + Random.Range(-8, 8), gameObject.transform.position.z + Random.Range(-8, 8)), Quaternion.Euler(new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360))));
            bullet.GetComponent<Rigidbody>().AddRelativeTorque(transform.up * 40);
            Destroy(bullet, 4);
            spawnTime = 0;
        }
    }



}
