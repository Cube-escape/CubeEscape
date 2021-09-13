using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage8Gamemanager : MonoBehaviour
{
    public static bool watchedFirst = false;  //첫번째 기억을 열람했는가
    public static bool watchedSecond = false; //두번째 기억을 열람했는가
    public static bool watchedThird = false;  //세번째 기억을 열람했는가
    public static bool e1 = false; //기억 볼 때 효과음 재생용 변수
    public static bool e2 = false; //기억 다 본 후 효과음 재생용 변수

    private bool doesIntroEnd = false;
    private int startFlag = 0;

    public ParticleSystem ps;

    public GameObject interactionUI;
    public GameObject stageIntroUI;
    public GameObject fadeInOutPanel;

    public GameObject player;
    public GameObject stageIntroCamera;
    public GameObject falseDoor; //기억을 다 본 후 사라질 문들

    public AudioSource asBGM; //배경음악 제어
    public AudioClip stage8bgm; //메인 배경음악   

    public AudioSource asEffect;  //효과음 제어
    public AudioClip watchMemory; //기억을 볼 때 효과음
    public AudioClip watchedEveryMemory; //기억을 다 봤을 때 효과음

    void Start()
    {
        ps.Play(); //파티클 시스템 재생

        asBGM.loop = true;
        asBGM.playOnAwake = true;
        asBGM.clip = stage8bgm;
        asBGM.Play();

        asEffect.loop = false;
        asEffect.playOnAwake = true;

        interactionUI.SetActive(false);
        fadeInOutPanel.SetActive(true);
        player.SetActive(false);

        stageIntroCamera.SetActive(true);
        stageIntroUI.SetActive(true);

        player.GetComponent<MovePlayer>().enabled = false;
    }

    void Update()
    {
        if (startFlag == 0)
        {
            StartCoroutine("Stage8Intro");
            startFlag = 1;
        }

        if (doesIntroEnd == true)
        {
            player.GetComponent<MovePlayer>().enabled = true;
            fadeInOutPanel.SetActive(false); //페이드 인, 아웃용 패널 off
            interactionUI.SetActive(true); //인터렉션 UI 활성화
            doesIntroEnd = false; //플래그 초기화
        }

        if ((InteractionController8.isWatchingMemory1 || InteractionController8.isWatchingMemory2 || InteractionController8.isWatchingMemory3) && e1) //기억을 열람하는 중이면
        {
            asEffect.PlayOneShot(watchMemory); //기억 보는 효과음 재생 
            e1 = false; //플래그 초기화
        }

        if (watchedFirst && watchedSecond && watchedThird) //모든 기억을 다 봤다면
        {
            if(e2 == true)
            {
                asEffect.PlayOneShot(watchedEveryMemory); //기억 다 본 효과음 재생
                e2 = false;
            }

            falseDoor.SetActive(false);  //문 하나 남기고 나머지 사라짐
        }
    }

    IEnumerator Stage8Intro() //11초
    {
        yield return new WaitForSeconds(7f); //5초동안 페이드 인 - 스테이지 인트로 출력 - 페이드 아웃 - 2초동안 카메라 변경, 스테이지 소개 UI 끄기
        stageIntroUI.SetActive(false);
        stageIntroCamera.SetActive(false);
        player.SetActive(true);

        yield return new WaitForSeconds(4f); //페이드 인
        doesIntroEnd = true;
    }


}
