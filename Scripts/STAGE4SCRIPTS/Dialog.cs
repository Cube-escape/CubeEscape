using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    [SerializeField] GameObject noticeUI;
    public GameObject p;
    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;
    bool[] array = new bool[5];
    void OnMouseDown()
    {
        p1.SetActive(false);
        p2.SetActive(false);
        p3.SetActive(false);
        p4.SetActive(false);
        p.SetActive(true);

    }


    void Start()
    {
        p.SetActive(false);
    
        
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1)|| noticeUI.activeSelf) p.SetActive(false);
       
    }

}
