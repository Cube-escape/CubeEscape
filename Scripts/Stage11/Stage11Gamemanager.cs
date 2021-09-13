using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage11Gamemanager : MonoBehaviour
{
    public GameObject interactionUI;
    public GameObject stageIntroUI;
    public GameObject fadeInOutPanel;

    public GameObject player;
    public GameObject stageIntroCamera;

    public AudioSource asBGM; //배경음악 제어
    public AudioClip stage8bgm; //메인 배경음악

    public AudioSource asEffect;  //효과음 제어
    public AudioClip boxOpen; //상자 열림 효과음
    public AudioClip doorOpen; //문 열림 효과음

    public static bool isBoxOpen = false;
    public static bool isDoorOpen = false;
    public bool a = false;
    private bool startFlag = true;
    private bool doesIntroEnd = false;

    void Start()
    {
        interactionUI.SetActive(false);
        fadeInOutPanel.SetActive(true);
        player.SetActive(false);

        stageIntroCamera.SetActive(true);
        stageIntroUI.SetActive(true);

        asBGM.loop = true;
        asBGM.playOnAwake = true;
        asBGM.clip = stage8bgm;
        asBGM.Play();

        player.GetComponent<MovePlayer>().enabled = false;
    }

    void Update()
    {
        if (startFlag == true)
        {
            StartCoroutine("Stage11Intro");
            startFlag = false;
        }

        if (doesIntroEnd == true)
        {
            player.GetComponent<MovePlayer>().enabled = true;
            fadeInOutPanel.SetActive(false); //페이드 인, 아웃용 패널 off
            interactionUI.SetActive(true); //인터렉션 UI 활성화
            doesIntroEnd = false; //플래그 초기화
        }

        if (isBoxOpen)
        {
            asEffect.PlayOneShot(boxOpen); //상자 열리는 효과음 재생
            isBoxOpen = false;
            a = true;
        }

        if (isDoorOpen)
        {
            asEffect.PlayOneShot(doorOpen); //문 열리는 효과음 재생
            isDoorOpen = false;
        }
    }

    IEnumerator Stage11Intro() //11초
    {
        yield return new WaitForSeconds(7f); //5초동안 페이드 인 - 스테이지 인트로 출력 - 페이드 아웃 - 2초동안 카메라 변경, 스테이지 소개 UI 끄기
        stageIntroUI.SetActive(false);
        stageIntroCamera.SetActive(false);
        player.SetActive(true);

        yield return new WaitForSeconds(4f); //페이드 인
        doesIntroEnd = true;
    }
}
