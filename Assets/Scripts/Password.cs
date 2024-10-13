using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Password : MonoBehaviour
{
    public GameObject[] lights;

    public int hitCount = 0;
    public int correctCount = 0;

    public Material[] lightColors;
    public string[] password;
    public string[] guesses;

    public Animator doorAnimator;
    public bool[] isGuessed;
    public bool checkPassword = false;

    public float resetTimer = 1;

    // Update is called once per frame
    void Update()
    {
        if(resetTimer > 0)
        {
            resetTimer -= Time.deltaTime;
        }
        else
        {
            ResetPassword();
        }

        if (hitCount >= 5)
        {
            checkPassword = true;
        }


        if (checkPassword == true)
        {
            CheckPassword();
            checkPassword = false;
        }

        if (correctCount == 5)
        {
            OpenDoor();
        }
    }
    private void CheckPassword()
    {
        Debug.Log("Checking password");
        for (int i = 0; i < guesses.Length; i++)
        {
            if(guesses[i] != password[i])
            {
                doorAnimator.SetTrigger("Wrong");
                ResetPassword();
            }
            else
            {
                correctCount += 1;
            }
        }
    }

    private void ResetPassword()
    {
        for (int i = 0; i < guesses.Length; i++)
        {
            lights[i].GetComponent<MeshRenderer>().material = lightColors[0];
            guesses[i] = "";
            isGuessed[i] = false;
        }
        hitCount = 0;
        correctCount = 0;
    }

    private void OpenDoor()
    {
        doorAnimator.SetTrigger("Correct");
        Destroy(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        string collisionTag = collision.gameObject.tag;
        Debug.Log(collisionTag);
        resetTimer = 1;
        hitCount += 1;
        for (int i = 0; i < guesses.Length; i++)
        {
            if (guesses[i] == "")
            {
                isGuessed[i] = true;
                switch (collisionTag)
                {
                    case "ProjectileRed":
                        {
                            lights[i].GetComponent<MeshRenderer>().material = lightColors[1];
                            guesses[i] = "R";
                        }
                        break;

                    case "ProjectileYellow":
                        {
                            lights[i].GetComponent<MeshRenderer>().material = lightColors[2];
                            guesses[i] = "Y";
                        }
                        break;

                    case "ProjectileGreen":
                        {
                            lights[i].GetComponent<MeshRenderer>().material = lightColors[3];
                            guesses[i] = "G";
                        }
                        break;

                    case "ProjectileBlue":
                        {
                            lights[i].GetComponent<MeshRenderer>().material = lightColors[4];
                            guesses[i] = "B";
                        }
                        break;
                }
                return;
            }
        }
        Destroy(collision.gameObject);
    }
}
