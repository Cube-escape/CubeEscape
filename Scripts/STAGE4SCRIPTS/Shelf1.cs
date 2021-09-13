using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelf1 : MonoBehaviour
{
    public GameObject book1;
    public GameObject book2;
    public GameObject book3;
    AudioSource audiosource;
    // Start is called before the first frame update
    void Start()
    {
        book1.SetActive(false);
        book2.SetActive(false);
        book3.SetActive(false);
        audiosource = GetComponent<AudioSource>();
    }
    private void OnMouseDown()
    {
        audiosource.Play();
        book1.SetActive(true);
        book2.SetActive(true);
        book3.SetActive(true);
        Stage4Gamemanager.isbookdropped1 = true;
    }

    // Update is called once per frame
   
}
