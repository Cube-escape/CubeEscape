using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPadTouch1 : MonoBehaviour
{
    public GameObject keypad;
    public GameObject text;
    AudioSource audiosource;
    // Start is called before the first frame update
    void Start()
    {
        keypad.SetActive(false);
        audiosource = GetComponent<AudioSource>();
        
    }

    void OnMouseDown()
    {
       
        keypad.SetActive(true);
        text.SetActive(true);
        audiosource.Play();
        Stage4Gamemanager.issafeboxunlocked = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) {
            keypad.SetActive(false);
            text.SetActive(false);
            audiosource.Play();
            Stage4Gamemanager.issafeboxunlocked = false;
        }
    }
}
