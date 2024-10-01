using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTextBoxManager : MonoBehaviour
{
    public GameObject textBox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Tutorial")
        {
            textBox.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Tutorial")
        {
            textBox.SetActive(false);
        }
    }
}
