using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameObjectChangeTest : MonoBehaviour
{
    public GameObject paint1;
    public GameObject paint2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        paint1.SetActive(true);
        paint2.SetActive(false);
    }
}
