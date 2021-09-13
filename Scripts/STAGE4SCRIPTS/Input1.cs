using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Input1 : MonoBehaviour
{
    // Start is called before the first frame update
    public InputField InputText;
    public GameObject light;
    public Text text;
    public string answer;
    public GameObject whale;
    AudioSource audiosource;
   

    // Start is called before the first frame update
    void Awake()
    {
       light.SetActive(false);
        whale.SetActive(false);
        audiosource =whale.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            InputText.ActivateInputField();
            InputText.Select();
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            answer = text.text;
            if (answer == "PINOCCHIO")
            {
                
              
                light.SetActive(true);
                whale.SetActive(true);
                gameObject.SetActive(false);
                audiosource.Play();
                

            }
            else text.text = "";



        }
    }
  
}
