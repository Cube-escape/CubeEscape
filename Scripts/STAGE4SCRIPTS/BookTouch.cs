using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookTouch : MonoBehaviour
{

    public GameObject book; //

    public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
        book.SetActive(false);
   
    }

    // Update is called once per frame
    void OnMouseDown()
    {
        panel.SetActive(true);
        book.SetActive(true);
        Stage4Gamemanager.isbooktouch = true;
    
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) {
            panel.SetActive(false);
            book.SetActive(false);
            Stage4Gamemanager.isbooktouch = false;
        }    
    }
}
