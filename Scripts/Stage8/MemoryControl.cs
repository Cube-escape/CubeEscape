using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryControl : MonoBehaviour
{
    public GameObject player;
    public GameObject cam;

    public GameObject firstMemory;  //첫번째 기억 이미지 
    public GameObject secondMemory; //두번째 기억 이미지
    public GameObject thirdMemory;  //세번째 기억 이미지
    public GameObject noticeUI; //플레이어 독백 패널

    public bool fadeOutFinished = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) //우클릭시 기억 끄기
        {
            if (InteractionController8.isWatchingMemory1) //첫번째 기억을 본 경우
            {
                CloseMemory(firstMemory);
            }
            else if (InteractionController8.isWatchingMemory2) //두번째 기억을 본 경우
            {
                CloseMemory(secondMemory);
            }
            else if (InteractionController8.isWatchingMemory3) //세번째 기억을 본 경우
            {
                CloseMemory(thirdMemory);
            }
        }

        if (fadeOutFinished)
        {
            player.GetComponent<MovePlayer>().enabled = true; //플레이어 움직임 활성화
            cam.GetComponent<MoveCamera>().enabled = true; //카메라 움직임 활성화
            Cursor.lockState = CursorLockMode.Locked; //커서 락 활성화

            if (InteractionController8.isWatchingMemory1)
            {
                firstMemory.SetActive(false); //기억 UI 끄기
                Stage8Gamemanager.watchedFirst = true; //플래그 전환
                InteractionController8.isWatchingMemory1 = false; //crosshair 다시 띄우기
                InteractionController8.dialog1 = true; //기억 본 후 독백 출력
            }
            else if (InteractionController8.isWatchingMemory2)
            {
                secondMemory.SetActive(false); //기억 UI 끄기
                Stage8Gamemanager.watchedSecond = true; //플래그 전환
                InteractionController8.isWatchingMemory2 = false; //crosshair 다시 띄우기
                InteractionController8.dialog2 = true; //기억 본 후 독백 출력

            }
            else if (InteractionController8.isWatchingMemory3)
            {
                thirdMemory.SetActive(false); //기억 UI 끄기
                Stage8Gamemanager.watchedThird = true; //플래그 전환
                InteractionController8.isWatchingMemory3 = false; //crosshair 다시 띄우기
                InteractionController8.dialog3 = true; //기억 본 후 독백 출력
            }

            fadeOutFinished = false;
        }
    }

    void CloseMemory(GameObject fadeImage)
    {
        StartCoroutine("FadeOut", fadeImage.GetComponent<Image>()); //페이드 아웃
    }

    IEnumerator FadeOut(Image fadeImage)
    {
        float fadeCount = 1; //처음 알파값 1
        WaitForSeconds ws = new WaitForSeconds(0.05f);

        while (fadeCount >= 0f) //알파 최솟값 0까지 반복
        {
            fadeCount -= 0.05f;
            yield return ws; //0.05초마다 실행
            fadeImage.color = new Color(1, 1, 1, fadeCount);
        }

        if(fadeCount <= 0)
        {
            fadeOutFinished = true; //플레이어, 카메라 움직임, 커서락 활성화 및 이미지 UI 끄기, 크로스헤어 띄우고 플래그 전환 
        }
    }
    
}
