using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class Stage1Gamemanager : MonoBehaviour
{
    public static bool doesPlayerhavekey = false;
    public static int does1stSolved = -1; //첫번째 문제(큐브 문제) 해결 여부 - CodePanel과 연결 / -1이면 1번 문제 해결 x 0이면 해결후 변화 실행 1이면 변화 실행 후
    public static int does2ndSolved = -1; //두번째 문제(큐브 숫자) 해결 여부 - CodeLock과 연결
    public static bool doesDialog1End = false; //dialog manager와 연결
    public static bool doesDialog2End = false; //dialog manager와 연결

    private bool doesGlitchEnd = false;
    private bool doesIntroEnd1 = false;
    private bool doesIntroEnd2 = false;
    private bool doesDialog2Start1 = false;
    private bool doesDialog2Start2 = false;
    private bool doesDialog2End2 = false;
    private bool doesDialog2End3 = false;

    private int glitchFlag = 0;
    private int laughFlag = 0;
    private int paperDropFlag = 0;
    private int secondBgmFlag = 0;
    private int gameControlFlag = 0;
    private int unlockedFlag = 0;

    public GameObject movingWall;

    public GameObject blinkPanel;
    public GameObject interactionUI;
    public GameObject stageIntroUI; //스테이지 소개 텍스트
    public GameObject fadeInOutPanel; //스크립트 1 끝난 후 장면 전환
    public GameObject fadeInOutPanel2; //스테이지 소개 텍스트 출력 후 장면 전환
    public GameObject fadeInOutPanel3; //스크립트 2 끝난 후 장면 전환
    public GameObject gameControlUI; //조작법 UI
    public GameObject introCursorUI; //스테이지 인트로 동안 커서락 none

    public GameObject player1; //스테이지 초반 플레이어
    public GameObject player2; //스크립트1 출력 후 이용할 플레이어
    public GameObject dialogTrigger;
    public GameObject dialogBtn; //대화창 UI
    public GameObject dialog1Camera; //스테이지 초반 카메라
    public GameObject stage1IntroCamera; //스테이지 소개용 카메라
    public GameObject dialog2Camera; //두번째 대화 카메라
    public GameObject monitorOff; 
    public GameObject monitorOn;
    public GameObject paper;

    public GameObject cube1;
    public GameObject cube2;
    public GameObject cube6;
    public GameObject cube8;

    public GameObject speaker;
    public GameObject poster1;
    public GameObject poster2;
    public GameObject keypad;

    public AudioSource asBGM;
    public AudioSource asBGM2; 
    public AudioSource asEffect;
    public AudioClip firstBgm;  //~큐브 문제 bgm
    public AudioClip secondBgm; //벽 수축 bgm
    public AudioClip glitch;    //지지직 소리
    public AudioClip paperDrop; //종이뭉치 떨어지는 소리
    public AudioClip laughing;  //관리인c 웃음소리
    public AudioClip unlocked;  //자물쇠 해제 효과음

    private float rotateTime = 7f; //카메라 회전 시간

    private void Start()
    {
        interactionUI.SetActive(false);
        player2.SetActive(false);
        dialogBtn.SetActive(false);
        fadeInOutPanel.SetActive(false);
        fadeInOutPanel2.SetActive(false);
        stageIntroUI.SetActive(false);
        
        introCursorUI.SetActive(true);
        blinkPanel.SetActive(true);
        StartCoroutine("BlinkPanelOff"); //시작 8.5초 후에 blinkPanel 끄고 첫번째 스크립트 자동 출력

        asBGM.loop = true;
        asBGM.playOnAwake = true;
        asBGM.clip = firstBgm;
        asBGM.Play();

        asEffect.loop = false;
    }

    private void Update()
    {

        /*  if ( 플레이어가 키를 가지고있다면)

               doesPlayerhavekey = true;
           }

           */

        var system = FindObjectOfType<DialogManager>();
        if (system.sentenceNum == 1) //첫 대사 출력 후 카메라 두리번 두리번
        {
            dialogBtn.SetActive(false); //대화 패널 off

            //카메라 두리번 두리번
            if (rotateTime >= 5.5f && rotateTime <= 7f) //오른쪽으로 1.5초동안 회전
            {
                dialog1Camera.transform.RotateAround(player1.transform.position, Vector3.up, 20f * Time.deltaTime);
                rotateTime -= Time.deltaTime;
            }
            else if (rotateTime >= 5f && rotateTime < 5.5f) //0.5초동안 그 자리 그대로 유지
            {
                rotateTime -= Time.deltaTime;
            }
            else if (rotateTime >= 2f && rotateTime < 5f) //왼쪽으로 3초동안 회전
            {
                dialog1Camera.transform.RotateAround(player1.transform.position, Vector3.up, -20f * Time.deltaTime);
                rotateTime -= Time.deltaTime;
            }
            else if (rotateTime >= 1.5f && rotateTime < 2f) //0.5초동안 그 자리 그대로 유지
            {
                rotateTime -= Time.deltaTime;
            }
            else if (rotateTime >= 0 && rotateTime < 1.5f) //오른쪽으로 1.5초동안 회전
            {
                dialog1Camera.transform.RotateAround(player1.transform.position, Vector3.up, 20f * Time.deltaTime);
                rotateTime -= Time.deltaTime;
            }
            else
            {
                //두리번거린 후 대사 출력
                dialogBtn.SetActive(true);
            }
        }
        else if (system.sentenceNum == 3) //두번째 대사 출력 후 지지직 소리 + 모니터로 시선 이동
        {
            dialogBtn.SetActive(false);
            if (glitchFlag == 0)
            {
                asEffect.PlayOneShot(glitch);
                glitchFlag = 1;
            }
            StartCoroutine("PlayGlitch"); //지지직 효과음 출력 이후 카메라 이동
            if (doesGlitchEnd == true)
            {
                dialogBtn.SetActive(true); //이후 script 1-(3) 출력
            }
        }
        else if (system.sentenceNum == 31)  //스크립트 1 끝나고 이루어지는 변화 구현 - 스테이지 소개 텍스트 + 소개 UI 출력
        {
            if (doesDialog1End == true)
            {   
                if(laughFlag == 0)
                {
                    asEffect.PlayOneShot(laughing); //웃음소리
                    laughFlag = 1;
                }
                dialogBtn.SetActive(false);
                StartCoroutine("StageIntro"); //페이드 아웃 - 모니터 끄기/카메라 변경 - 페이드 인 - 스테이지 소개
            }
            
            if(doesIntroEnd1 == true)
            {
                doesDialog1End = false;
                StartCoroutine("StageIntro2"); //다시 페이드 아웃 - 플레이어 2로 변경 - 페이드 인
            }

            if (doesIntroEnd2 == true)
            {
                doesIntroEnd1 = false;
                fadeInOutPanel.SetActive(false);
                fadeInOutPanel2.SetActive(false);
                introCursorUI.SetActive(false);

                if (gameControlFlag == 0)
                {
                    gameControlUI.SetActive(true);

                    player2.GetComponent<MovePlayer>().enabled = false; //화면 움직임 막기
                    dialog2Camera.GetComponent<MoveCamera>().enabled = false; //카메라 움직임 막기
                    Cursor.lockState = CursorLockMode.None; //커서락 해제
                }
                
                if (Input.GetMouseButtonDown(1)) //우클릭시 창 닫기
                {
                    gameControlUI.SetActive(false);
                    gameControlFlag = 1;

                    interactionUI.SetActive(true);

                    player2.GetComponent<MovePlayer>().enabled = true; //화면 움직임 활성화
                    dialog2Camera.GetComponent<MoveCamera>().enabled = true; //카메라 움직임 활성화
                    Cursor.lockState = CursorLockMode.Locked; //커서락 잠금
                }
            }

            if (does1stSolved == 0) //첫번째 문제가 해결되었으면
            {
                doesIntroEnd2 = false;

                paper.SetActive(true); //종이뭉치 떨구기
                if(paperDropFlag == 0)
                {
                    asEffect.PlayOneShot(paperDrop);
                    paperDropFlag = 1;
                }
                
                StartCoroutine("Dialog2Start");//커서락 해제 및 인터렉션, 플레이어, 카메라 스크립트 해제 - 2초 그대로 - 시선 상자로 이동 
            }

            if (doesDialog2Start1 == true)
            {
                does1stSolved = 1; //플래그 변경

                GameObject.Find("Stage1Manager").GetComponent<InteractionController1>().enabled = false; //인터렉션 스크립트 해제
                interactionUI.SetActive(false);

                if (glitchFlag == 1)
                {
                    asEffect.PlayOneShot(glitch);
                    glitchFlag = 2;
                }

                StartCoroutine("Dialog2Start2"); //4초 대기(glitch) - 모니터 켜기
            }

            if (doesDialog2Start2 == true)
            {
                doesDialog2Start1 = false;
                GameObject.Find("Stage1Manager").GetComponent<InteractionController1>().enabled = false; //인터렉션 스크립트 해제
                interactionUI.SetActive(false);

                //시선 모니터로 이동
                player2.transform.position = Vector3.Lerp(player2.transform.position, new Vector3(20f, 68f, 0), 0.1f);
                player2.transform.localEulerAngles = new Vector3(0, 90f, 0);

                dialogBtn.SetActive(true); //이후 script 2 출력
            }
        }
        else if(system.sentenceNum == 48) //script 2 끝나면
        {
            if (doesDialog2End == true)
            {
                doesDialog2Start2 = false; //꼭 필요한 것은 아님
                dialogBtn.SetActive(false);

                if (laughFlag == 1)
                {
                    asEffect.PlayOneShot(laughing); //웃음소리
                    laughFlag = 2;
                }

                StartCoroutine("Dialog2End"); //페이드 인 + 플레이어 위치 이동 + 큐브, 모니터, 스피커, 키패드 없애기 + 플레이어 움직임 활성화
            }
            
            if (doesDialog2End2 == true) //4초 후 브금 변경
            {
                doesDialog2End = false;

                
            }

            if (doesDialog2End3 == true) //2초 후 플레이어 활성화
            {
                if (secondBgmFlag == 0)
                {
                    asBGM2.PlayOneShot(secondBgm); //긴박한 브금으로 변경
                    secondBgmFlag = 1;
                }

                doesDialog2End2 = false;
                fadeInOutPanel3.SetActive(false);
                //벽 움직이기
                movingWall.transform.position = Vector3.MoveTowards(movingWall.transform.position, new Vector3(-50f, 50f, 0), Time.deltaTime * 1.5f); 

                //플레이어나 상자가 벽과 충돌하면 게임 오버 if()
            }

            if (does2ndSolved == 0) //두번째 문제가 해결되었으면
            {
                doesDialog2End3 = false;

                player2.GetComponent<MovePlayer>().enabled = true;
                dialog2Camera.GetComponent<MoveCamera>().enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
                
                if (unlockedFlag == 0)
                {
                    asEffect.PlayOneShot(unlocked); //자물쇠 풀리는 효과음
                    unlockedFlag = 1;
                }

            }
        }
    }

    IEnumerator BlinkPanelOff()
    {
        yield return new WaitForSeconds(8.5f);
        blinkPanel.SetActive(false);
        dialogTrigger.SetActive(true);
        dialogTrigger.GetComponent<DialogTrigger>().Trigger(); //자동으로 첫 문장 시작
        dialogBtn.SetActive(true);
        dialogTrigger.SetActive(false);
    }


    IEnumerator PlayGlitch() //4초
    {
        yield return new WaitForSeconds(4f);

        //카메라 모니터로 이동
        dialog1Camera.transform.position = Vector3.Lerp(dialog1Camera.transform.position, new Vector3(20, 73, 0), 0.1f);
        //켜진 모니터로 전환(monitor(off)를 false로)
        monitorOff.SetActive(false);
        doesGlitchEnd = true;
    }

    IEnumerator StageIntro() //10초
    {
        fadeInOutPanel.SetActive(true); 

        yield return new WaitForSeconds(3f); //페이드 아웃

        stageIntroUI.SetActive(true); //스테이지 소개 텍스트 출력
        
        //모니터 변경
        monitorOn.SetActive(false);   
        monitorOff.SetActive(true);
        
        //카메라 변경
        player1.SetActive(false);
        stage1IntroCamera.SetActive(true);
        
        yield return new WaitForSeconds(4f); //페이드 인
        
        fadeInOutPanel.SetActive(false);
        
        yield return new WaitForSeconds(3f);   //스테이지 소개 화면 3초 더 출력
        
        doesIntroEnd1 = true;
    }

    IEnumerator StageIntro2() //6초
    {
        fadeInOutPanel2.SetActive(true); //스테이지 소개 후 다시 페이드 아웃
        yield return new WaitForSeconds(2.5f);
        
        stageIntroUI.SetActive(false);
        stage1IntroCamera.SetActive(false);
        player2.SetActive(true);
        yield return new WaitForSeconds(3.5f); //페이드 인
        
        doesIntroEnd2 = true;
    }

    IEnumerator Dialog2Start()  //5초
    {
        //(movePlayer, moveCamera 스크립트 비활성화) 및 커서락 해제
        player2.GetComponent<MovePlayer>().enabled = false; //화면 움직임 막기
        dialog2Camera.GetComponent<MoveCamera>().enabled = false; //카메라 움직임 막기
        Cursor.lockState = CursorLockMode.None; //커서락 해제
        GameObject.Find("Stage1Manager").GetComponent<InteractionController1>().enabled = false; //인터렉션 스크립트 해제
        interactionUI.SetActive(false); //인터렉션 UI 해제
        yield return new WaitForSeconds(2f); //2초 그대로

        //시선 상자로 이동
        player2.transform.position = Vector3.Lerp(player2.transform.position, new Vector3(-10f, 10f, 0), 0.1f);
        player2.transform.localEulerAngles = new Vector3(10, -90, 0);

        yield return new WaitForSeconds(3f);//3초 그대로

        doesDialog2Start1 = true;
    }

    IEnumerator Dialog2Start2() //4초
    {
        yield return new WaitForSeconds(4f);//4초 그대로

        //켜진 모니터로 전환
        monitorOn.SetActive(true);
        monitorOff.SetActive(false);

        doesDialog2Start2 = true;
    }

    IEnumerator Dialog2End() //8초
    {
        fadeInOutPanel3.SetActive(true); 
        yield return new WaitForSeconds(4f); //페이드 아웃 - 오브젝트 끄고 플레이어 원위치로 이동

        //큐브, 모니터, 스피커, 키패드 비활성화
        //GameObject.Find("Cube1").SetActive(false);
        cube1.SetActive(false);
        cube2.SetActive(false);
        cube6.SetActive(false);
        cube8.SetActive(false);
        monitorOn.SetActive(false);
        speaker.SetActive(false);
        keypad.SetActive(false);

        //포스터 교체
        poster1.SetActive(false);
        poster2.SetActive(true);

        player2.transform.position = new Vector3(0f, 30f, 0); //플레이어 원위치로 이동

        //다시 커서락, moveplayer, movecamera 활성화
        player2.GetComponent<MovePlayer>().enabled = true;
        dialog2Camera.GetComponent<MoveCamera>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;

        asBGM.Stop(); //브금 멈추기

        doesDialog2End2 = true; //새 브금 재생

        yield return new WaitForSeconds(2f); //페이드 인, 벽 움직이기

        //interactionUI 및 스크립트 활성화
        interactionUI.SetActive(true);
        GameObject.Find("Stage1Manager").GetComponent<InteractionController1>().enabled = true;

        doesDialog2End3 = true; //벽 움직이기, 페이드 아웃 패널 끄기
    }

}
