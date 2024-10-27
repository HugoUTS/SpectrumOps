using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootToMovePlatform : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    public float speed;
    private float current, target;

    public string tag;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        current = Mathf.MoveTowards(current, target, speed * Time.deltaTime);
        transform.position = Vector3.Lerp(new Vector3(pointA.transform.position.x, pointA.transform.position.y, pointA.transform.position.z), new Vector3(pointB.transform.position.x, pointB.transform.position.y, pointB.transform.position.z), current);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == tag)
        {
            if (target == 0)
            {
                target = 1;
            }
            else
            {
                target = 0;
            }
        }
    }
}
