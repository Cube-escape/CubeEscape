using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkText : MonoBehaviour
{
    private float timer = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < 0)
        {
            if (GetComponent<Text>().enabled == true)
                GetComponent<Text>().enabled = false;
            else
                GetComponent<Text>().enabled = true;

            timer = 1f;
        }
        timer -= Time.deltaTime;
    }
}
