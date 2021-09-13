using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeinAnim : MonoBehaviour
{
    float time = 0;
    float fadeTime; //페이드 인 효과 지속시간

    // Update is called once per frame
    void Update()
    {
        if(time < fadeTime)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, time/fadeTime); 
        }
        else
        {
            time = 0;
            this.gameObject.SetActive(false);
        }
        time += Time.deltaTime;
        
    }

    public void resetAnim()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        this.gameObject.SetActive(true);
        time = 0;
    }
}
