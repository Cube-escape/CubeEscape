using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class InteractionController11 : MonoBehaviour
{
    private SceneManagement sm11;

    RaycastHit hitInfo;
    [SerializeField] int sizeofLazer = 40; //lazer의 크기

    public GameObject[] interactionUI; //크로스헤어, 상호작용 안내 텍스트
    public GameObject noticeUI; //플레이어 독백 패널
    public GameObject fadeOutPanel; //미로 탈출 후 fade out

    public Camera cam; //플레이어 자식 카메라(메인 카메라)
    public Transform arm; //player2의 팔
    public GameObject key;

    private bool stageEnd = false; //미로 탈출 후 문 눌렀을 때 페이드 아웃 이후 true
    private bool openDoor = false; //문 열때 인터랙션 UI 끄기 위한 플래그
    private bool doesPlayerHaveKey = false;

    void Start()
    {
        sm11 = new SceneManagement();
    }

    void Update()
    {
        CheckObject();

        if (arm.transform.childCount == 1 && Input.GetMouseButtonDown(1)) //열쇠를 든 채로 우클릭 시
        {
            arm.transform.GetComponentInChildren<Rigidbody>().useGravity = true; //중력 적용 - 땅에 떨어지도록
            arm.transform.GetComponentInChildren<Rigidbody>().isKinematic = false;
            arm.GetChild(0).parent = null;

            doesPlayerHaveKey = false;
        }

        if (stageEnd) //다음 스테이지로 전환
        {
            SceneManagement.completedStage = 11;
            sm11.movetoNextStage(); 
        }
    }

    void CheckObject()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        if (Physics.Raycast(ray, out hitInfo, sizeofLazer) && hitInfo.transform.CompareTag("interaction") && !openDoor)
        {
            Contact();
        }

        else
        {
            notContact();
        }
    }

    void Contact()
    {
        showEvent(); // 레이저에 맞은 객체의 종류에 따라 할 수 있는 행위를 담은 UI 를 보여줌
    }

    void notContact()
    {
        if (!openDoor) 
        {
            for (int i = 0; i < interactionUI.Length; i++)
            {
                interactionUI[i].SetActive(true); //모든 interaction UI 활성화 (crosshair, 설명 텍스트)
            }
            interactionUI[1].GetComponent<Text>().text = ""; //인터렉션 설명 텍스트 초기화
        }
        else //문을 열 때
        {
            for (int i = 0; i < interactionUI.Length; i++)
            {
                interactionUI[i].SetActive(false); //crosshair를 포함한 모든 interaction UI를 비활성화 시킨다.
            }
        }
    }

    void showEvent()
    {
        if (hitInfo.transform.name == "Door(2)") //ray가 Door와 충돌한 경우
        {
            interactionUI[1].GetComponent<Text>().text = "문 열기";

            if (Input.GetMouseButtonDown(0)) //0이 마우스 왼쪽. 1이 마우스 오른쪽
            {
                if (doesPlayerHaveKey) //열쇠를 들고 있는 경우
                {
                    interactionUI[1].GetComponent<Text>().text = "";//이벤트 나타내는 UI 내용 지우기.
                    openDoor = true;
                    Stage11Gamemanager.isDoorOpen = true;
                    fadeOutPanel.SetActive(true); //fade out panel 켜기
                    StartCoroutine("StageEndFadeOut");
                }
                else StartCoroutine("notice", "열쇠가 필요해..."); //문이 열리지 않아 독백 띄우기
            }
        }
        else if (hitInfo.transform.name == "Chest") //보물상자
        {
            interactionUI[1].GetComponent<Text>().text = "상자 열기";

            if (Input.GetMouseButtonDown(0)) //0이 마우스 왼쪽. 1이 마우스 오른쪽
            {
                interactionUI[1].GetComponent<Text>().text = "";
                Stage11Gamemanager.isBoxOpen = true;

                //열쇠 획득 - arm에 들게 함
                if (arm.transform.childCount == 0)
                {
                    key.GetComponent<Rigidbody>().useGravity = false; // gravity를 끈다.
                    key.GetComponent<Rigidbody>().isKinematic = true; // kinematic을 켜면 스크립트에 의해서만 움직인다. 물건을 손에 집었을 때 공기 저항에 의해 빙글빙글 돌지 않도록 하기 위해 필요하다. 
                    key.transform.position = arm.transform.position; // 팔로 지정해둔 위치로 이동시킨다.
                    key.transform.parent = arm.transform; // 팔의 child로 넣어준다.

                    key.GetComponent<Transform>().localRotation = Quaternion.Euler(90f, 0f, 0f); // 앞면이 보이도록 회전 각도 조정
                    key.GetComponent<Transform>().localScale = new Vector3(2f, 2f, 7f);

                    doesPlayerHaveKey = true;
                }
            }
        }

        else if (hitInfo.transform.name == "Key" && !doesPlayerHaveKey) //열쇠를 바닥에 떨어뜨린 후 다시 줍는 경우 
        {
            interactionUI[1].GetComponent<Text>().text = "열쇠 줍기";

            if (Input.GetMouseButtonDown(0)) //마우스 왼쪽 클릭시
            {
                interactionUI[1].GetComponent<Text>().text = ""; //열쇠 줍기 끄기

                //열쇠 획득 - arm에 들게 함
                if (arm.transform.childCount == 0)
                {
                    key.GetComponent<Rigidbody>().useGravity = false; // gravity를 끈다.
                    key.GetComponent<Rigidbody>().isKinematic = true; // kinematic을 켜면 스크립트에 의해서만 움직인다. 물건을 손에 집었을 때 공기 저항에 의해 빙글빙글 돌지 않도록 하기 위해 필요하다. 
                    key.transform.position = arm.transform.position; // 팔로 지정해둔 위치로 이동시킨다.
                    key.transform.parent = arm.transform; // 팔의 child로 넣어준다.

                    key.GetComponent<Transform>().localRotation = Quaternion.Euler(90f, 0f, 0f); // 앞면이 보이도록 회전 각도 조정
                    key.GetComponent<Transform>().localScale = new Vector3(2f, 2f, 7f);

                    doesPlayerHaveKey = true;
                }
            }
        }
    }

    IEnumerator notice(string txt) //플레이어 독백(하단 출력)
    {
        noticeUI.SetActive(true);
        noticeUI.GetComponentInChildren<Text>().text = txt;

        yield return new WaitForSeconds(3f);
        noticeUI.SetActive(false);
    }

    IEnumerator StageEndFadeOut() //스테이지 전환 시 페이드 아웃
    {
        yield return new WaitForSeconds(3f);
        stageEnd = true;
    }
}
