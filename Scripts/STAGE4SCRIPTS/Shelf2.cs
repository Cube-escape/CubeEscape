using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelf2 : MonoBehaviour
{
    public GameObject book4;
    public GameObject book5;
    public GameObject book6;
    public GameObject book7;
    AudioSource audiosource;
    // Start is called before the first frame update
    void Start()
    {
        book4.SetActive(false);
        book5.SetActive(false);
        book6.SetActive(false);
        book7.SetActive(false);
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void OnMouseDown()
    {
        audiosource.Play();
        book4.SetActive(true);
        book5.SetActive(true);
        book6.SetActive(true);
        book7.SetActive(true);
        Stage4Gamemanager.isbookdropped2 = true;
    }
}
