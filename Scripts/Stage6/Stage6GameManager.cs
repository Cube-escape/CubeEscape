using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage6GameManager : MonoBehaviour
{
    /*
     * <state0>
     * ´«¾Ë + ½Ç
     * 
     * <state1>
     * state0 °á°ú¹° + ±êÅÐ 3°³
     * 
     * <state2>
     * scaryman Á¦°Å, Ãâ±¸ »ý±è
     */

    [SerializeField]
    private EndingAnimation endingAnim;

    [SerializeField]
    private AudioSource audioSourceEffect;

    [SerializeField]
    private AudioClip clip;

    [SerializeField]
    private AudioSource audioSourceBGM;

    [SerializeField]
    private GameObject light;

    [SerializeField]
    private GameObject fadeInPanel;

    private int state = 0;
    private bool b1 = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("FadeIn6");
    }

    // Update is called once per frame
    void Update()
    {
        if(state == 2 && b1)
        {
            light.SetActive(true);
            audioSourceEffect.clip = clip;
            audioSourceEffect.Play();
            endingAnim.StartAnimation();
            b1 = false;
        }
    }

    public void IncreaseState()
    {
        state++;
    }

    public int GetState()
    {
        return state;
    }

    public void IncreaseBGMPitch()
    {
        audioSourceBGM.pitch += 0.1f;
    }

    IEnumerator FadeIn6()
    {
        fadeInPanel.SetActive(true);
        yield return new WaitForSeconds(6f);
        fadeInPanel.SetActive(false);
    }
}
