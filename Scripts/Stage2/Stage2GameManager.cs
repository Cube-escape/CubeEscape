using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage2GameManager : MonoBehaviour
{
    /*
     * [state 1]
     * 이름표를 떼고, 붙이는 동작만 가능.
     * 열쇠 보이지 않음.
     * 전선함 열기 불가능.
     * 전선함 버튼 누르기 불가능.
     * 불 켜고, 끄기 불가능.
     * 
     * [state 2]
     * 이름표 떼고, 붙이기 불가능.
     * 열쇠 나타남. 이동 가능.
     * 전선함 열기 가능.
     * 전선함 버튼 누르기 가능.
     * 불 켜고, 끄기 불가능.
     * 
     * [state 3]
     * 이름표 떼고, 붙이기 불가능.
     * 열쇠 사라짐.
     * 전선함 열린 상태.
     * 전선함 버튼 누르기 불가능.
     * 불 켜고, 끄기 가능.
     * death 그림만 변함.
     * 
     * [state 4]
     * 이름표 떼고, 붙이기 불가능.
     * 열쇠 사라짐.
     * 전선함 열린 상태.
     * 전선함 버튼 누르기 불가능.
     * 불 켜고, 끄기 가능.
     * 모든 그림 변함.
     * 
     */

    [SerializeField]
    private GameObject[] namePlate;

    [SerializeField]
    private GameObject key;

    [SerializeField]
    private GameObject pointLight;

    [SerializeField]
    private AudioSource audioSourceBGM;

    [SerializeField]
    private AudioSource audioSourceEffect;

    [SerializeField]
    private AudioClip[] clip;

    [SerializeField]
    private GameObject fadeInPanel;

    // 단계 표시
    private int state;

    private bool b1 = true;
    private bool b2 = true;

    public int GetState()
    {
        return state;
    }

    public void IncreaseState()
    {
        state++;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Stage2Intro");
        state = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // State1 -> State2
        if(state == 1 &&
            namePlate[0].transform.childCount == 1 &&
            namePlate[1].transform.childCount == 1 &&
            namePlate[2].transform.childCount == 1 &&
            namePlate[3].transform.childCount == 1 &&
            namePlate[4].transform.childCount == 1)
        {
            if (namePlate[0].transform.GetChild(0).name == "name_tag_crack" &&
                namePlate[1].transform.GetChild(0).name == "name_tag_gaze" &&
                namePlate[2].transform.GetChild(0).name == "name_tag_illusion" &&
                namePlate[3].transform.GetChild(0).name == "name_tag_peace" &&
                namePlate[4].transform.GetChild(0).name == "name_tag_death")
            {
                key.SetActive(true);
                state++;
                Debug.Log("go to state2");
            }
        }

        else if(state == 4 && b1)
        {
            pointLight.GetComponent<Light>().enabled = false;
            audioSourceBGM.clip = clip[0];
            audioSourceBGM.Play();
            audioSourceEffect.clip = clip[1];
            audioSourceEffect.Play();
            b1 = false;
        }

        else if(state == 5 && b2)
        {
            audioSourceEffect.clip = clip[2];
            audioSourceEffect.Play();
            b2 = false;
        }
    }

    IEnumerator Stage2Intro()
    {
        fadeInPanel.SetActive(true);
        yield return new WaitForSeconds(6f);
        fadeInPanel.SetActive(false);
    }
}