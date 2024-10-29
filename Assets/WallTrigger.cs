using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTrigger : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    public float speed;
    private float current, target = 1;

    // Update is called once per frame
    void Update()
    {
        current = Mathf.MoveTowards(current, target, speed * Time.deltaTime);
        transform.position = Vector3.Lerp(new Vector3(pointA.transform.position.x, pointA.transform.position.y, pointA.transform.position.z), new Vector3(pointB.transform.position.x, pointB.transform.position.y, pointB.transform.position.z), current);
    }
}
