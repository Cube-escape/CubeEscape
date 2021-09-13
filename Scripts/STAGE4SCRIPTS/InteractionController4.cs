using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionController4 : MonoBehaviour //여러 사람이 하나의 interactioncontrller를 사용하면 충돌이 잦을거같아서 스테이지별로 1,2,3,4 구분해서 사용하기.
{
    //[SerializeField]를 이용하면 inspector 창에서 옵젝을 끌어다가 초기화 시킬 수 있음. public 과 비슷한 역할.

    [SerializeField] Camera cam;

    RaycastHit hitInfo; // RaycastHit은 레이저에 맞은 대상의 정보를 기억하는 클래스.

    [SerializeField] int sizeofLazer = 10; //lazer의 크기.
    [SerializeField] GameObject arm;
    [SerializeField] GameObject Panel;

    public GameObject[] interactionUI;

    public GameObject noticeUI;
    public GameObject Whale;

    private Stage4Gamemanager gameManager;
    AudioSource audiosource;
    AudioSource audiosource2;
    AudioSource audiosource3;

    SceneManagement sm4 = new SceneManagement();
    bool end = false;

    private void Start()
    {
        noticeUI.SetActive(false);
        audiosource = GetComponent<AudioSource>();
        audiosource2 = Whale.GetComponent<AudioSource>();
        Whale.SetActive(false);
        audiosource3 = GameObject.Find("Door").GetComponent<AudioSource>();
    
    }

    // Update is called once per frame
    void Update()
    {


        CheckObject();
        if (end) {

            SceneManagement.completedStage = 4;
            sm4.movetoNextStage();
        }
    }

    void CheckObject()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));




        if (Physics.Raycast(ray, out hitInfo, sizeofLazer) && hitInfo.transform.CompareTag("interaction")) //어떤 콜라이더와 레이가 충돌했으면 true, 아니면 false. // hitinfo 는 ray에 맞은 객체의 정보를 저장하는 변수


        {

            Contact();
            Debug.Log(hitInfo.transform.name);// 레이저에 닿은 사물의 이름 출력.
        }

        else
        {

            notContact();
        }
    }

    void Contact()
    {
        showEvent();

    }


    void notContact()
    {

        for (int i = 0; i < interactionUI.Length; i++)
        {
            interactionUI[0].GetComponent<Text>().text = "";
        }


    }

    void showEvent()
    {
        if (hitInfo.transform.name == "Lower Poly Bookcase" || hitInfo.transform.name == "Book Set Texture" || hitInfo.transform.name == "Book Set Texture.2")
        {
            interactionUI[0].GetComponent<Text>().text = "책장 움직이기";



            if (Input.GetMouseButtonDown(0))
            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click book");
            }
        }
        if ((hitInfo.transform.name == "vase_A_S3" || hitInfo.transform.name == "vase_A_S2" || hitInfo.transform.name == "vase_A_S5" || hitInfo.transform.name == "vase_A_S4" || hitInfo.transform.name == "vase_A_S1"))
        {
            interactionUI[0].GetComponent<Text>().text = "진실의 피노키오에게 줄 꽃 꽂기";
            
                
                




            
        }
        

        else if (hitInfo.transform.name == "Book1" || hitInfo.transform.name == "Book2" || hitInfo.transform.name == "Book3" || hitInfo.transform.name == "Boo41" || hitInfo.transform.name == "Book5" || hitInfo.transform.name == "Book6" || hitInfo.transform.name == "Book7" || hitInfo.transform.name == "Book1" || hitInfo.transform.name == "Book8" || hitInfo.transform.name == "Book9")
        {
            if (!Stage4Gamemanager.isbooktouch) interactionUI[0].GetComponent<Text>().text = "책 자세히보기";


            if (Input.GetMouseButton(0))

            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click book");

            }

        }

        else if (hitInfo.transform.name == "HorrorDoll (6)" || hitInfo.transform.name == "HorrorDoll (2)" || hitInfo.transform.name == "HorrorDoll (3)" || hitInfo.transform.name == "HorrorDoll (4)" || hitInfo.transform.name == "HorrorDoll (5)")
        {
            interactionUI[0].GetComponent<Text>().text = "피노키오 인형의 말 듣기";
            //꽃을 들고있는 상태면 꽃을 전달하시겠습니까? UI띄우고 꽃을 들고있지 않은 상태면 인형의 말을 듣기.


            if (Input.GetMouseButton(0))
            {

                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click Pinocchio");

            }
        }

        else if (hitInfo.transform.name == "DoorLeft")
        {
            interactionUI[0].GetComponent<Text>().text = "캐비넷 열기";

            if (Input.GetMouseButton(0))
            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click cabinet");
            }
        }




        else if (hitInfo.transform.name == "projector")
        {
            interactionUI[0].GetComponent<Text>().text = "빔프로젝터 작동시키기.";

            if (Input.GetMouseButton(0))
            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click beam project");
            }
        }

        else if (hitInfo.transform.name == "picture")
        {
            interactionUI[0].GetComponent<Text>().text = "그림 만지기";

            if (Input.GetMouseButton(0))
            {
                AudioSource laugheffect = hitInfo.transform.GetComponent<AudioSource>();
                StartCoroutine("laughEffect", laugheffect);
                StartCoroutine("feelScarry");
                Debug.Log("click picture");
            }
        }

        else if (hitInfo.transform.name == "Book1" || hitInfo.transform.name == "Book2" || hitInfo.transform.name == "Book3" || hitInfo.transform.name == "Book1" || hitInfo.transform.name == "Book1" || hitInfo.transform.name == "Book4" || hitInfo.transform.name == "Book5" || hitInfo.transform.name == "Book1" || hitInfo.transform.name == "Book7" || hitInfo.transform.name == "Book8" || hitInfo.transform.name == "Book9")
        {
            interactionUI[0].GetComponent<Text>().text = "책 자세히보기";

            if (Input.GetMouseButton(0))
            {

                Debug.Log("click book");
            }
        }




        else if (hitInfo.transform.name == "flower01")
        {
            interactionUI[0].GetComponent<Text>().text = "꽃 줍기";

            if (Input.GetMouseButton(0))
            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click flower");
            }
        }

        else if (hitInfo.transform.name == "Drawer1" || hitInfo.transform.name == "Drawer2" || hitInfo.transform.name == "Drawer3" || hitInfo.transform.name == "Drawer4" || hitInfo.transform.name == "Drawer_Big1" || hitInfo.transform.name == "Drawer_Big2" || hitInfo.transform.name == "Drawer_Big3" || hitInfo.transform.name == "Drawer_Med2 1" || hitInfo.transform.name == "Drawer_Med2" || hitInfo.transform.name == "Drawer_Med1")
        {
            interactionUI[0].GetComponent<Text>().text = "서랍 열기";

            if (Input.GetMouseButton(0))
            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click drawer");
                //서랍열기
            }
        }



        else if (hitInfo.transform.name == "WhalePad")
        {
            if (!Stage4Gamemanager.isWhalepadUnlocked)
            {
                interactionUI[0].GetComponent<Text>().text = "고래비밀번호입력기입력";
            }

            if (Input.GetMouseButton(0))
            {
                Stage4Gamemanager.isWhalepadUnlocked = true;
                interactionUI[0].GetComponent<Text>().text = "";
                Whale.SetActive(true);
                audiosource2.Play();

                Debug.Log("click WhalePad");
                //스크린 내리기.
            }
        }



        else if (hitInfo.transform.name == "Keyboard") //
        {
            if (!Stage4Gamemanager.issafeboxunlocked) interactionUI[0].GetComponent<Text>().text = "키패드 입력하기";


            if (Input.GetMouseButton(0))
            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click Keyboard");

            }
        }

        else if (hitInfo.transform.name == "Key") //
        {
            interactionUI[0].GetComponent<Text>().text = "열쇠 줍기";

            if (Input.GetMouseButton(0))
            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click Key");

            }
        }



        else if (hitInfo.transform.name == "Wall_Entrance")
        {
            interactionUI[0].GetComponent<Text>().text = "문 열기";

            if (Input.GetMouseButton(0))
            {

                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click Door");

                if (Stage4Gamemanager.isliarQuizSolved)
                {
                    StartCoroutine("FadeOut");
                    
                }
                else
                {
                    audiosource3.Play();
                    StartCoroutine("noOpen");
                }

                //피노키오 인형문제를 해결한 상태면 다음스테이지로, 그렇지 못했으면 '문이 열리지 않아' 출력.
            }

        }


        else if (hitInfo.transform.name == "PINOCCHIO") //
        {
            interactionUI[0].GetComponent<Text>().text = "인형에게 말걸기";

            if (Input.GetMouseButtonDown(0))
            {
                audiosource.Play();
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click horrordoll");

                int r = Random.Range(0, 4);

                if (r == 0)
                    StartCoroutine("Doll_saying1");

                else if (r == 1)
                    StartCoroutine("Doll_saying2");

                else if (r == 2)
                    StartCoroutine("Doll_saying3");

                else if (r == 3)
                    StartCoroutine("Doll_saying4");

            }
        }

        else if (hitInfo.transform.name == "WhalePad")
        {
            if (!Stage4Gamemanager.isWhalepadUnlocked)
            {
                interactionUI[0].GetComponent<Text>().text = "고래비밀번호입력기입력";
            }

            if (Input.GetMouseButton(0))
            {
                Stage4Gamemanager.isWhalepadUnlocked = true;
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click screen");
                //스크린 내리기.
            }
        }



    }
    IEnumerator FadeOut() {
        yield return new WaitForSeconds(1.5f);
        Panel.SetActive(true);
        yield return new WaitForSeconds(3f);
        end = true;
        
    }
    IEnumerator laughEffect(AudioSource laugh)
    {
        laugh.playOnAwake = true;

        yield return new WaitForSeconds(2f);

        laugh.playOnAwake = false;

    }
    IEnumerator noOpen()
    {

        noticeUI.SetActive(true);
        noticeUI.GetComponentInChildren<Text>().text = "문이 열리지 않아..";
        yield return new WaitForSeconds(2f);
        noticeUI.SetActive(false);

    }
    


    IEnumerator feelScarry()
    {

        noticeUI.SetActive(true);
        noticeUI.GetComponentInChildren<Text>().text = "피노키오인형인가..?섬뜩해..";
        yield return new WaitForSeconds(2f);
        noticeUI.SetActive(false);

    }

    IEnumerator Doll_saying1()
    {

        noticeUI.SetActive(true);
        noticeUI.GetComponentInChildren<Text>().text = "누가 제페토할아버지를 죽였을까 킥킥. 배은망덕하지.";
        yield return new WaitForSeconds(2f);
        noticeUI.SetActive(false);

    }

    IEnumerator Doll_saying2()
    {

        noticeUI.SetActive(true);
        noticeUI.GetComponentInChildren<Text>().text = "오직 진실한자만이 꽃을 얻을수 있는법.";
        yield return new WaitForSeconds(2f);
        noticeUI.SetActive(false);

    }

    IEnumerator Doll_saying3()
    {

        noticeUI.SetActive(true);
        noticeUI.GetComponentInChildren<Text>().text = "피노키오 인형들은 거짓말을 아주 잘하지.";
        yield return new WaitForSeconds(2f);
        noticeUI.SetActive(false);

    }

    IEnumerator Doll_saying4()
    {

        noticeUI.SetActive(true);
        noticeUI.GetComponentInChildren<Text>().text = "피노키오의 새 주인이 된 사람들은 모두 죽었어.";
        yield return new WaitForSeconds(2f);
        noticeUI.SetActive(false);

    }





}

