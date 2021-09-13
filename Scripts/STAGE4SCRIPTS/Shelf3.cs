using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelf3 : MonoBehaviour
{
    public GameObject book8;
    public GameObject book9;
    AudioSource audiosource;
    // Start is called before the first frame update
    void Start()
    {
        book8.SetActive(false);
        book9.SetActive(false);
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void OnMouseDown()
    {
        audiosource.Play();
        book8.SetActive(true);
        book9.SetActive(true);
        Stage4Gamemanager.isbookdropped3 = true;
    }
}
