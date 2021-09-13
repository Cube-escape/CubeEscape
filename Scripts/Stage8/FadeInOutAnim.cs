using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOutAnim : MonoBehaviour
{
    public static IEnumerator FadeIn(Image fadeImage)
    {
        float fadeCount = 0; //ó�� ���İ� 0
        WaitForSeconds ws = new WaitForSeconds(0.01f);

        while (fadeCount <= 1.0f) //���� �ִ� 1.0���� �ݺ�
        {
            fadeCount += 0.01f;
            yield return ws; //0.1�ʸ��� ����
            fadeImage.color = new Color(1, 1, 1, fadeCount);
        }
    }

    public static IEnumerator FadeOut(Image fadeImage)
    {
        float fadeCount = 1; //ó�� ���İ� 1
        WaitForSeconds ws = new WaitForSeconds(0.01f);

        while (fadeCount <= 0f) //���� �ּڰ� 0���� �ݺ�
        {
            fadeCount -= 0.01f;
            yield return ws; //0.1�ʸ��� ����
            fadeImage.color = new Color(1, 1, 1, fadeCount);
        }
    }

    /* ������Ʈ�� ��ũ��Ʈ�� �ְ� ������ ��� �� �Լ��� Update���� ȣ���� ���
     * �̹����� update������ ó������ �����Ƿ� ���� �ڷ�ƾ���� �ٽ� �ۼ���
     
    public float fadeTime = 2f;  //Fade anim ��� �ð�
    private float time = 0f;

    public void PlayFadeIn(Image fadeImage)
    {
        if (time <= fadeTime)
        {
            fadeImage.color = new Color(1, 1, 1, time / fadeTime);
        }
        else
        {
            time = 0; //time �ʱ�ȭ 
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
