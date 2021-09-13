using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class InteractionController8 : MonoBehaviour
{
    private SceneManagement sm8;
    private bool e2Flag = true; //기억 다 본 후 효과음 재생 관련 플래그
    private bool stageEnd = false; //기억 다 본 후 페이드 아웃 끝나면 true
    private bool stageEnd2 = false; //기억 다 본 후 문 눌렀을때 인터랙션 UI 끄기

    RaycastHit hitInfo;
    [SerializeField] int sizeofLazer = 40; //lazer의 크기

    public static bool isWatchingMemory1 = false;
    public static bool isWatchingMemory2 = false;
    public static bool isWatchingMemory3 = false;

    public static bool dialog1 = false; //첫번째 기억 본 후 독백
    public static bool dialog2 = false; //두번째 기억 본 후 독백
    public static bool dialog3 = false; //세번째 기억 본 후 독백

    public GameObject[] interactionUI; //크로스헤어, 상호작용 안내 텍스트
    public GameObject noticeUI; //플레이어 독백 패널
    public Camera cam; //플레이어 자식 카메라(메인 카메라)
    public GameObject player;
    public GameObject fadeOutPanel; //스테이지 끝난 후 페이드 아웃

    public GameObject firstMemory;  //첫번째 기억 이미지 
    public GameObject secondMemory; //두번째 기억 이미지
    public GameObject thirdMemory;  //세번째 기억 이미지

    public Text explainTxt; //명언, 원초아 리비도 초자아 설명용 상단 출력 텍스트

    void Start()
    {
        sm8 = new SceneManagement();
        explainTxt.text = "";
    }

    void Update()
    {
        CheckObject();

        if (Stage8Gamemanager.watchedFirst && Stage8Gamemanager.watchedSecond && Stage8Gamemanager.watchedThird && e2Flag)
        {
            Stage8Gamemanager.e2 = true;
            e2Flag = false;
        }

        if (dialog1)
        {
            StartCoroutine("notice", "어릴 적부터 아버지께 학대를 당한 건가...?"); //기억 본 후 플레이어 독백
            dialog1 = false;
        }
        else if (dialog2)
        {
            StartCoroutine("notice", "친구들에게도 괴롭힘을 당했나..."); //기억 본 후 플레이어 독백
            dialog2 = false;
        }
        else if (dialog3)
        {
            StartCoroutine("notice", "그런 아버지마저도 잃어버린 건가..."); //기억 본 후 플레이어 독백
            dialog3 = false;
        }

        if (stageEnd)
        {
            SceneManagement.completedStage = 8;
            sm8.movetoNextStage();
        }
    }

    void CheckObject()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        //Debug.DrawRay(ray.origin, ray.direction * sizeofLazer, Color.red);

        if ((Physics.Raycast(ray, out hitInfo, sizeofLazer) && (hitInfo.transform.CompareTag("interaction") || hitInfo.transform.CompareTag("interaction"))) && !isWatchingMemory1 && !isWatchingMemory2 && !isWatchingMemory3 && !stageEnd2)
        {
            //최상위 부모만 interaction 태그 달아도 인식되도록.
            Contact();
            //Debug.Log(hitInfo.transform.root.name);
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
        if (!isWatchingMemory1 && !isWatchingMemory2 && !isWatchingMemory3 && !stageEnd2) //기억을 열람하는 중이 아니라면 
        {
            for (int i = 0; i < interactionUI.Length; i++)
            {
                interactionUI[i].SetActive(true); //모든 interaction UI 활성화 (crosshair, 설명 텍스트)
            }
            interactionUI[1].GetComponent<Text>().text = ""; //인터렉션 설명 텍스트 초기화
        }
        else //기억을 열람하는 중이면
        {
            for (int i = 0; i < interactionUI.Length; i++)
            {
                interactionUI[i].SetActive(false); //모든 interaction UI 비활성화 (crosshair, 설명 텍스트)
            }
        }
    }

    void showEvent()
    {
        if (hitInfo.transform.root.name == "Bat") // ray에 맞은 대상의 이름이 "Bat" (게임 오브젝트 이름) 라면
        {
            interactionUI[1].GetComponent<Text>().text = "몽둥이 관련 기억 확인하기";

            //그 상태에서 마우스 왼쪽버튼을 클릭하면
            if (Input.GetMouseButtonDown(0)) //0이 마우스 왼쪽. 1이 마우스 오른쪽
            {
                isWatchingMemory1 = true; //크로스헤어 및 설명 텍스트 비활성화
                Stage8Gamemanager.e1 = true; //효과음 재생 플래그 

                firstMemory.SetActive(true);

                player.GetComponent<MovePlayer>().enabled = false; //화면 움직임 막기
                player.GetComponentInChildren<MoveCamera>().enabled = false; //카메라 움직임 막기
                Cursor.lockState = CursorLockMode.None; //커서락 해제

                StartCoroutine("FadeIn", firstMemory.GetComponent<Image>()); //첫번째 기억 열람 - 이미지 띄우기(페이드 인)
            }
        }

        else if (hitInfo.transform.root.name == "Locker")
        {
            interactionUI[1].GetComponent<Text>().text = "사물함 관련 기억 확인하기";

            //그 상태에서 마우스 왼쪽버튼을 클릭하면
            if (Input.GetMouseButtonDown(0))
            {
                isWatchingMemory2 = true; //크로스헤어 및 설명 텍스트 비활성화
                Stage8Gamemanager.e1 = true; //효과음 재생 플래그 

                secondMemory.SetActive(true);

                player.GetComponent<MovePlayer>().enabled = false; //화면 움직임 막기
                player.GetComponentInChildren<MoveCamera>().enabled = false; //카메라 움직임 막기
                Cursor.lockState = CursorLockMode.None; //커서락 해제

                StartCoroutine("FadeIn", secondMemory.GetComponent<Image>()); //두번째 기억 열람 - 이미지 띄우기(페이드 인)
            }
        }

        else if (hitInfo.transform.root.name == "Frame")
        {
            interactionUI[1].GetComponent<Text>().text = "액자 관련 기억 확인하기";

            //그 상태에서 마우스 왼쪽버튼을 클릭하면
            if (Input.GetMouseButtonDown(0))
            {
                isWatchingMemory3 = true; //크로스헤어 및 설명 텍스트 비활성화
                Stage8Gamemanager.e1 = true; //효과음 재생 플래그 

                thirdMemory.SetActive(true);

                player.GetComponent<MovePlayer>().enabled = false; //화면 움직임 막기
                player.GetComponentInChildren<MoveCamera>().enabled = false; //카메라 움직임 막기
                Cursor.lockState = CursorLockMode.None; //커서락 해제

                StartCoroutine("FadeIn", thirdMemory.GetComponent<Image>()); //세번째 기억 열람 - 이미지 띄우기(페이드 인)
            }
        }

        else if (hitInfo.transform.root.name == "Mask")
        {
            interactionUI[1].GetComponent<Text>().text = "원초아";

            //그 상태에서 마우스 왼쪽버튼을 클릭하면
            if (Input.GetMouseButtonDown(0))
            {
                interactionUI[1].GetComponent<Text>().text = "";

                //코루틴 함수이름다음에 , 찍고 인자전달 가능.
                StartCoroutine("explain", "원초아: 원초적인 자아의 일부분으로 마음이 가는 대로 움직이고\n쾌락 중심적인 성향을 가진 자아 요소"); //원초아 설명 텍스트 띄우기
            }
        }

        else if (hitInfo.transform.root.name == "Libido")
        {
            interactionUI[1].GetComponent<Text>().text = "리비도";

            //그 상태에서 마우스 왼쪽버튼을 클릭하면
            if (Input.GetMouseButtonDown(0))
            {
                interactionUI[1].GetComponent<Text>().text = "";
                StartCoroutine("explain", "리비도: 사람이 내재적으로 갖고 있는 성욕 또는 성적 충동"); //리비도 설명 텍스트 띄우기
            }
        }

        else if (hitInfo.transform.root.name == "Scale")
        {
            interactionUI[1].GetComponent<Text>().text = "초자아";

            //그 상태에서 마우스 왼쪽버튼을 클릭하면
            if (Input.GetMouseButtonDown(0))
            {
                interactionUI[1].GetComponent<Text>().text = "";
                StartCoroutine("explain", "초자아: 도덕적인 것을 좇고 이상향을 추구하는 슈퍼 에고"); //초자아 설명 텍스트 띄우기
            }
        }

        else if (hitInfo.transform.root.name == "Brain")
        {
            interactionUI[1].GetComponent<Text>().text = "뇌";

            //그 상태에서 마우스 왼쪽버튼을 클릭하면
            if (Input.GetMouseButtonDown(0))
            {
                interactionUI[1].GetComponent<Text>().text = "";
                StartCoroutine("explain", "\"우리의 의식은 항상 어떤 무엇을 향해 관계를 맺고 있기 때문에\n대상 역시 의식을 매개로 하지 않고서는 대상으로 다룰 수 없다.\"\n- 에드문트 후설 -");//명언 1 띄우기
            }
        }

        else if (hitInfo.transform.root.name == "Heart")
        {
            interactionUI[1].GetComponent<Text>().text = "심장";

            //그 상태에서 마우스 왼쪽버튼을 클릭하면
            if (Input.GetMouseButtonDown(0))
            {
                interactionUI[1].GetComponent<Text>().text = "";
                StartCoroutine("explain", "\"무의식을 의식화하지 않는다면 무의식이 삶의 방향을 결정하게 된다.\n우리는 그런 것을 두고, 바로 '운명'이라고 부른다.\"- 칼 융 -");//명언 2 띄우기
            }
        }

        else if (hitInfo.transform.root.name == "TrueDoor" || hitInfo.transform.root.name == "FalseDoor") //root는 최상위 부모 반환.
        {
            interactionUI[1].GetComponent<Text>().text = "문 열기";

            //그 상태에서 마우스 왼쪽버튼을 클릭하면
            if (Input.GetMouseButtonDown(0))
            {
                interactionUI[1].GetComponent<Text>().text = "";//이벤트 나타내는 UI 내용 지우기.

                if (Stage8Gamemanager.watchedFirst && Stage8Gamemanager.watchedSecond && Stage8Gamemanager.watchedThird) //모든 기억을 다 열람한 경우
                {
                    stageEnd2 = true;
                    fadeOutPanel.SetActive(true);
                    StartCoroutine("StageEndFadeOut");
                }
                else StartCoroutine("notice", "문이 열리지 않아..."); //문이 열리지 않아 독백 띄우기
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

    IEnumerator explain(string txt) //설명 및 명언(상단 출력)
    {
        explainTxt.text = txt;

        yield return new WaitForSeconds(3f);
        explainTxt.text = "";

    }

    IEnumerator FadeIn(Image fadeImage)
    {
        float fadeCount = 0; //처음 알파값 0
        WaitForSeconds ws = new WaitForSeconds(0.05f);

        while (fadeCount <= 1.0f) //알파 최댓값 1.0까지 반복
        {
            fadeCount += 0.05f;
            yield return ws; //0.05초마다 실행
            fadeImage.color = new Color(1, 1, 1, fadeCount);
        }
    }

    IEnumerator StageEndFadeOut()
    {
        yield return new WaitForSeconds(3f);
        stageEnd = true;
    }
}
