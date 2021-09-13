using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenBox : MonoBehaviour
{
    [SerializeField] InputField inputfield;
    private string answer;
    [SerializeField] AudioSource unlockEffect;

    // Update is called once per frame

   
    void Update()


    { 
        
        if(Input.GetKeyDown(KeyCode.Space))
        {

            inputfield.ActivateInputField();
            inputfield.Select();
        }
     
         if (Input.GetKeyDown(KeyCode.Return))
        {
            answer = inputfield.text;
            if (answer == "1205")
            {

                Stage3Gamemanager.isSecretBoxUnlocked = true;
                inputfield.gameObject.SetActive(false);
                GameObject.Find("Player").GetComponent<MovePlayer>().enabled = true;
                GameObject.Find("Main Camera").GetComponent<MoveCamera>().enabled = true;


                unlockEffect.Play();
            }
            else inputfield.text = "";


        }



        if (Input.GetMouseButton(1))
        {



            GameObject.Find("Player").GetComponent<MovePlayer>().enabled = true;
            GameObject.Find("Main Camera").GetComponent<MoveCamera>().enabled = true;

            inputfield.gameObject.SetActive(false);


        }

    }
}
