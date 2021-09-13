using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutAnim : MonoBehaviour
{
    float time = 0;
    public float fadeTime; //페이드 아웃 효과 지속시간

    // Update is called once per frame
    void Update()
    {
        if (time < fadeTime)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, fadeTime - time/fadeTime);
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
        GetComponent<SpriteRenderer>().color = Color.white;
        this.gameObject.SetActive(true);
    }
}
