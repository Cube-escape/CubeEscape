using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOutAnim : MonoBehaviour
{
    public static IEnumerator FadeIn(Image fadeImage)
    {
        float fadeCount = 0; //처음 알파값 0
        WaitForSeconds ws = new WaitForSeconds(0.01f);

        while (fadeCount <= 1.0f) //알파 최댓값 1.0까지 반복
        {
            fadeCount += 0.01f;
            yield return ws; //0.1초마다 실행
            fadeImage.color = new Color(1, 1, 1, fadeCount);
        }
    }

    public static IEnumerator FadeOut(Image fadeImage)
    {
        float fadeCount = 1; //처음 알파값 1
        WaitForSeconds ws = new WaitForSeconds(0.01f);

        while (fadeCount <= 0f) //알파 최솟값 0까지 반복
        {
            fadeCount -= 0.01f;
            yield return ws; //0.1초마다 실행
            fadeImage.color = new Color(1, 1, 1, fadeCount);
        }
    }

    /* 오브젝트에 스크립트를 넣고 제어할 경우 이 함수를 Update에서 호출해 사용
     * 이번에는 update문에서 처리하지 않으므로 위의 코루틴으로 다시 작성함
     
    public float fadeTime = 2f;  //Fade anim 재생 시간
    private float time = 0f;

    public void PlayFadeIn(Image fadeImage)
    {
        if (time <= fadeTime)
        {
            fadeImage.color = new Color(1, 1, 1, time / fadeTime);
        }
        else
        {
            time = 0; //time 초기화 
        }
        time += Time.deltaTime;
    }

    public void PlayFadeOut(Image fadeImage)
    {
        if (time < fadeTime)
        {
            fadeImage.color = new Color(1, 1, 1, fadeTime - time / fadeTime);
        }
        else
        {
            time = 0;
        }
        time += Time.deltaTime;
    }
    */
}
