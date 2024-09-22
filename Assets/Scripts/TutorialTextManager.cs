using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialTextManager : MonoBehaviour
{
    public GameObject nextTrigger;
    public TMP_Text tutorialText;
    [Multiline] public string textToDisplay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            tutorialText.text = textToDisplay;
        }
    }

    private void OnDestroy()
    {
        if(nextTrigger != null)
        {
            nextTrigger.SetActive(true);
        }
    }
}
