using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLaser : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    public float duration;
    private float current, target;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wait());
    }

    // Update is called once per frame
    void Update()
    {
        current = Mathf.MoveTowards(current, target, 0.02f * Time.deltaTime);
        transform.position = Vector3.Lerp(new Vector3(pointA.transform.position.x, pointA.transform.position.y, pointA.transform.position.z), new Vector3(pointB.transform.position.x, pointB.transform.position.y, pointB.transform.position.z), current);
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);

        if (target == 0)
        {
            target = 1;
        }
    }
}
