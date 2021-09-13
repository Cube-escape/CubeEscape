using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionController1 : MonoBehaviour 
{
    //[SerializeField]를 이용하면 inspector 창에서 옵젝을 끌어다가 초기화 시킬 수 있음. public 과 비슷한 역할.

    RaycastHit hitInfo; // RaycastHit은 레이저에 맞은 대상의 정보를 기억하는 클래스.

    private Stage1Gamemanager gm1;
    private SceneManagement sm1;

    [SerializeField] int sizeofLazer = 40; //lazer의 크기.

    public GameObject[] interactionUI;
    public GameObject noticeUI;
    public GameObject keypadUI;
    public GameObject codeLockUI;
    public GameObject paperUI;
    public GameObject fadeOutPanel; //스테이지 클리어 후 fade out

    public GameObject player1; 
    public GameObject player2;
    public Camera cam2; //player2의 카메라
    public Transform arm; //player2의 팔

    public GameObject key;

    public static bool isUsingKeyPad = false;
    public static bool isUsingCodeLock = false;
    public static bool isReadingPaper = false;

    private bool stageEnd = false; //스테이지 클리어 시 페이드 아웃 이후 true
    private bool openDoor = false; //문 열때 인터랙션 UI 끄기 위한 플래그
    private int recallFlag = 0;

    private void Start()
    {
        gm1 = new Stage1Gamemanager();
        sm1 = new SceneManagement();
    }

    // Update is called once per frame
    void Update()
    {
        CheckObject();

        if (arm.transform.childCount == 1 && Input.GetMouseButtonDown(1)) //열쇠를 든 채로 우클릭 시
        {
            arm.transform.GetComponentInChildren<Rigidbody>().useGravity = true; //중력 적용 - 땅에 떨어지도록
            arm.transform.GetComponentInChildren<Rigidbody>().isKinematic = false;
            arm.GetChild(0).parent = null;

            Stage1Gamemanager.doesPlayerhavekey = false;
        }

        if (stageEnd) //다음 스테이지로 전환
        {
            SceneManagement.completedStage = 1;
            sm1.movetoNextStage();
        }
    }

    void CheckObject()
    {
        int x = Screen.width / 2;
        int y = Screen.height / 2;
        Ray ray = cam2.ScreenPointToRay(new Vector3(x, y));

        //(Ray 원점, Ray 방향, 충돌 감지할 RaycastHit, Ray 거리(길이))
        //isUsingKeyPad과 isUsingCodeLock이 false일 때 ray가 interaction 태그를 달고 있는 오브젝트에 충돌하면
        if (Physics.Raycast(ray, out hitInfo, sizeofLazer) && hitInfo.transform.CompareTag("interaction") && !isUsingKeyPad && !isUsingCodeLock && !isReadingPaper && !openDoor) 
        {
            Contact();
            //Debug.Log(hitInfo.transform.name);
        }

        else
        {
            notContact();
        }
    }

    void Contact()
    {
        showEvent(); // 레이저에 맞은 객체의 종류에 따라 할 수 있는 행위를 담은 UI 를 보여줌.
    }

    void notContact()
    {
        if (!isUsingKeyPad && !isUsingCodeLock && !isReadingPaper && !openDoor)
        {
            for (int i = 1; i < interactionUI.Length; i++)
            {
                interactionUI[i].SetActive(false); //crosshair를 제외한 모든 interaction UI를 비활성화 시킨다.
            }
            interactionUI[0].SetActive(true); //crosshair 활성화
        }
        else 
        {
            for (int i = 0; i < interactionUI.Length; i++)
            {
                interactionUI[i].SetActive(false); //모든 interaction UI를 비활성화 시킨다.
            }
        }
    }

    void showEvent()
    {
        if (hitInfo.transform.name == "CubePoster") // ray에 맞은 대상의 이름이 "CubePoster" (게임 오브젝트 이름) 라면
        {
            interactionUI[1].SetActive(true);//PosterUI를 띄운다.

            //그 상태에서 마우스 왼쪽버튼을 클릭하면
            if (Input.GetMouseButtonDown(0)) //0이 마우스 왼쪽. 1이 마우스 오른쪽
            {
                interactionUI[1].SetActive(false); //Event를 나타내는 ui는 끈다.
                if (Random.Range(0, 2) == 0)
                    StartCoroutine("Poster_Saying1");
                if (Random.Range(0, 2) == 1)
                    StartCoroutine("Poster_Saying2");
            }
        }

        else if (hitInfo.transform.name == "KeyPad") //ray가 keypad와 충돌한 경우 + 문제 1을 해결하기 전인 경우
        {
            interactionUI[2].SetActive(true); //Keypad UI를 띄운다

            if (Input.GetMouseButtonDown(0)) //마우스 왼쪽 클릭시
            {
                isUsingKeyPad = true; //crosshair 끄기

                player2.GetComponent<MovePlayer>().enabled = false; //화면 움직임 막기
                cam2.GetComponent<MoveCamera>().enabled = false; //카메라 움직임 막기
                Cursor.lockState = CursorLockMode.None; //커서락 해제

                keypadUI.SetActive(true); //키패드 UI 켜기
            }

        }

        //이후 열쇠를 들고 있는 상태와 아닌 상태로 구분
        else if (hitInfo.transform.name == "Door") //ray가 Door와 충돌한 경우
        {
            interactionUI[3].SetActive(true); //Door UI를 띄운다 
            interactionUI[5].SetActive(false); //종이 뭉치 UI 끄기
            interactionUI[6].SetActive(false); //자물쇠 UI 끄기
            interactionUI[7].SetActive(false); //상자 열기 UI 끄기

            if (Input.GetMouseButtonDown(0)) //0이 마우스 왼쪽. 1이 마우스 오른쪽
            {
                interactionUI[3].SetActive(false); //Door UI를 끈다

                if (Stage1Gamemanager.doesPlayerhavekey) //열쇠를 들고 있는 경우
                {
                    openDoor = true;
                    fadeOutPanel.SetActive(true); //fade out panel 켜기
                    StartCoroutine("StageEndFadeOut");
                }
                else StartCoroutine("noKey");
            }
        }

        else if (hitInfo.transform.name == "Monitor(off)")
        {
            interactionUI[4].SetActive(true); //Monitor UI를 띄운다 

            if (Input.GetMouseButtonDown(0)) //0이 마우스 왼쪽. 1이 마우스 오른쪽
            {
                interactionUI[4].SetActive(false); //Monitor UI를 끈다
                if (recallFlag == 0)
                    StartCoroutine("recall_dialogue1");
                if (recallFlag == 1)
                    StartCoroutine("recall_dialogue2");
            }
        }

        else if (hitInfo.transform.name == "Paper")
        {
            if (Stage1Gamemanager.does2ndSolved == -1) //문제를 풀기 전에만 작동
            {
                interactionUI[5].SetActive(true); //종이 뭉치 펼치기 띄우기
                interactionUI[6].SetActive(false); //자물쇠 UI 끄기
                interactionUI[3].SetActive(false); //문열기 UI 끄기

                if (Input.GetMouseButtonDown(0)) //마우스 왼쪽 클릭시
                {
                    isReadingPaper = true; //crosshair를 포함한 interactionUI 끄기

                    player2.GetComponent<MovePlayer>().enabled = false; //화면 움직임 막기
                    cam2.GetComponent<MoveCamera>().enabled = false; //카메라 움직임 막기
                    Cursor.lockState = CursorLockMode.None; //커서락 해제

                    paperUI.SetActive(true); //쪽지 UI 켜기
                }
            }

            //우클릭 시 끄기 구현 
        }

        else if (hitInfo.transform.name == "Container")
        {
            if ((Stage1Gamemanager.does1stSolved == 1) && (Stage1Gamemanager.does2ndSolved == -1)) //1번 문제 해결 후 2번 문제 해결 전
            {
                interactionUI[6].SetActive(true); //자물쇠 해제하기 띄우기
                interactionUI[5].SetActive(false); //종이 뭉치 UI 끄기
                interactionUI[3].SetActive(false); //문열기 UI 끄기

                if (Input.GetMouseButtonDown(0)) //마우스 왼쪽 클릭시
                {
                    isUsingCodeLock = true; //crosshair를 포함한 interactionUI 끄기

                    player2.GetComponent<MovePlayer>().enabled = false; //화면 움직임 막기
                    cam2.GetComponent<MoveCamera>().enabled = false; //카메라 움직임 막기
                    Cursor.lockState = CursorLockMode.None; //커서락 해제

                    codeLockUI.SetActive(true); //자물쇠 UI 켜기
                }

            }
            else if (Stage1Gamemanager.does2ndSolved == 0) //2번 문제 해결 후
            {
                interactionUI[7].SetActive(true); //상자 열기 띄우기
                interactionUI[3].SetActive(false); //문열기 UI 끄기

                if (Input.GetMouseButtonDown(0)) //마우스 왼쪽 클릭시
                {
                    interactionUI[7].SetActive(false); //상자 열기 끄기

                    //열쇠 획득 - arm에 들게 함
                    if (arm.transform.childCount == 0)
                    {
                        key.GetComponent<Rigidbody>().useGravity = false; // gravity를 끈다.
                        key.GetComponent<Rigidbody>().isKinematic = true; // kinematic을 켜면 스크립트에 의해서만 움직인다. 물건을 손에 집었을 때 공기 저항에 의해 빙글빙글 돌지 않도록 하기 위해 필요하다. 
                        key.transform.position = arm.transform.position; // 팔로 지정해둔 위치로 이동시킨다.
                        key.transform.parent = arm.transform; // 팔의 child로 넣어준다.

                        key.GetComponent<Transform>().localRotation = Quaternion.Euler(90f, 90f, 0f); // 앞면이 보이도록 회전 각도 조정
                        key.GetComponent<Transform>().localScale = new Vector3(20f, 20f, 20f);

                        Stage1Gamemanager.doesPlayerhavekey = true;
                    }
                }
            }
        }

        else if (hitInfo.transform.name == "Key" && !Stage1Gamemanager.doesPlayerhavekey) //열쇠를 바닥에 떨어뜨린 후 다시 줍는 경우 
        {
            interactionUI[8].SetActive(true); //열쇠 줍기 띄우기

            if (Input.GetMouseButtonDown(0)) //마우스 왼쪽 클릭시
            {
                interactionUI[8].SetActive(false); //열쇠 줍기 끄기

                //열쇠 획득 - arm에 들게 함
                if (arm.transform.childCount == 0)
                {
                    key.GetComponent<Rigidbody>().useGravity = false; // gravity를 끈다.
                    key.GetComponent<Rigidbody>().isKinematic = true; // kinematic을 켜면 스크립트에 의해서만 움직인다. 물건을 손에 집었을 때 공기 저항에 의해 빙글빙글 돌지 않도록 하기 위해 필요하다. 
                    key.transform.position = arm.transform.position; // 팔로 지정해둔 위치로 이동시킨다.
                    key.transform.parent = arm.transform; // 팔의 child로 넣어준다.

                    key.GetComponent<Transform>().localRotation = Quaternion.Euler(90f, 90f, 0f); // 앞면이 보이도록 회전 각도 조정
                    key.GetComponent<Transform>().localScale = new Vector3(20f, 20f, 20f);

                    Stage1Gamemanager.doesPlayerhavekey = true;
                }
            }
        }
    }

    IEnumerator Poster_Saying1()
    {
        noticeUI.SetActive(true);
        noticeUI.GetComponentInChildren<Text>().text = "어쩌다 내가 이런 곳에..";

        yield return new WaitForSeconds(2f);
        noticeUI.SetActive(false);
    }

    IEnumerator Poster_Saying2()
    {
        noticeUI.SetActive(true);
        noticeUI.GetComponentInChildren<Text>().text = "큐브는 3x3 공간인건가?";

        yield return new WaitForSeconds(2f);
        noticeUI.SetActive(false);
    }

    IEnumerator noKey()
    {
        noticeUI.SetActive(true);
        noticeUI.GetComponentInChildren<Text>().text = "열쇠가 필요해...";
        
        yield return new WaitForSeconds(2f);
        noticeUI.SetActive(false);
    }

    IEnumerator recall_dialogue1()
    {
        noticeUI.SetActive(true);
        noticeUI.GetComponentInChildren<Text>().text = "관리인이 사물을 다방면으로 주시하라고 했던 것 같아.";

        yield return new WaitForSeconds(2f);
        noticeUI.SetActive(false);

        recallFlag = 1;
    }

    IEnumerator recall_dialogue2()
    {
        noticeUI.SetActive(true);
        noticeUI.GetComponentInChildren<Text>().text = "큰 것이 먼저 오는 것이 순리라고도 했던가?";

        yield return new WaitForSeconds(2f);
        noticeUI.SetActive(false);

        recallFlag = 0;
    }

    IEnumerator StageEndFadeOut()
    {
        yield return new WaitForSeconds(3f);
        stageEnd = true;
    }
}



