using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactioncontroller3 : MonoBehaviour
{


    [SerializeField] Camera cam;

    RaycastHit hitInfo;

    [SerializeField] int sizeofLazer = 10;

    [SerializeField] GameObject[] interactionUI;

    [SerializeField] GameObject noticeUI;

    [SerializeField] GameObject fireCheckUI; //태우시겠습니까?

    [SerializeField] private Transform arm;

    [SerializeField] GameObject diary1;

    [SerializeField] GameObject diary2;

    [SerializeField] GameObject SecretBox;
 
    [SerializeField] Stage3Gamemanager gm3;

    [SerializeField] GameObject Player;
    [SerializeField] GameObject News;
    [SerializeField] InputField inputfield;





    // Update is called once per frame
    void Update()
    {
        

        CheckObject();
        Debug.Log(arm.transform.childCount);

        if (arm.transform.childCount == 1 && Input.GetMouseButtonDown(1))
        {
            arm.transform.GetComponentInChildren<Rigidbody>().useGravity = true;
            arm.transform.GetComponentInChildren<Rigidbody>().isKinematic = false;
            arm.GetChild(0).parent = null;
        }

       
    }

    void CheckObject()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));



        Debug.DrawRay(ray.origin, ray.direction * sizeofLazer, Color.red);


        if (Physics.Raycast(ray, out hitInfo, sizeofLazer)&&hitInfo.transform.CompareTag("interaction")) //어떤 콜라이더와 레이가 충돌했으면 true, 아니면 false. // hitinfo 는 ray에 맞은 객체의 정보를 저장하는 변수


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
        
       /* if (hitInfo.transform.name == "girl" && arm.transform.childCount == 0 &&!gm3.isSecretBoxUnlocked)
        {
            interactionUI[0].GetComponent<Text>().text = "소녀에게 말걸기";

            if (Input.GetMouseButtonDown(0))
            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click girl");

                int r = Random.Range(0, 2);
                if (r==1)
                StartCoroutine("sayingMerryChristmas");
                else
                StartCoroutine("sayingHello");
               
              


            }
        }
       */

        if (hitInfo.transform.name == "girl" && arm.transform.childCount == 0 )
        {
            interactionUI[0].GetComponent<Text>().text = "소녀에게 말걸기";

            if (Input.GetMouseButtonDown(0))
            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click girl");

                    StartCoroutine("fireAll"); //소녀 흑화 ver.
               




            }
        }




       else if (hitInfo.transform.name == "girl" && arm.transform.childCount == 1)
        {
            interactionUI[0].GetComponent<Text>().text = "소녀에게 건네기";

            if (Input.GetMouseButtonDown(0))
            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("");

                //소녀에게 건넨 물건의 종류에 따라서 UI다르게 띄우기.

                if (arm.transform.GetChild(0).name == "clock")
                    StartCoroutine("sayingAboutClock");

                else if (arm.transform.GetChild(0).name == "sock")
                    StartCoroutine("sayingAboutSock");

                else if (arm.transform.GetChild(0).name == "가족액자")
                    StartCoroutine("sayingAboutFamilypicture");

                else
                    StartCoroutine("noCare");
            }
        }




        else if (hitInfo.transform.name == "diary1")
        {
            interactionUI[0].GetComponent<Text>().text = "일기장 자세히보기";

            if (Input.GetMouseButtonDown(0))
            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("");

                diary1.SetActive(true);
            }


        }
        else if (hitInfo.transform.name == "diary2")
        {
            interactionUI[0].GetComponent<Text>().text = "일기장 자세히보기";

            if (Input.GetMouseButtonDown(0))
            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("");

                diary2.SetActive(true);
            }


        }

       


        else if (hitInfo.transform.name == "Teddybear" && arm.transform.childCount == 0&& Stage3Gamemanager.isNewsviewed)
        {
            interactionUI[0].GetComponent<Text>().text = "곰인형 들기";

            if (Input.GetMouseButtonDown(0))
            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click Teddybear");

                hitInfo.transform.GetComponent<Rigidbody>().useGravity = false; // gravity를 끈다.
                hitInfo.transform.GetComponent<Rigidbody>().isKinematic = true; // kinematic을 켜면 스크립트에 의해서만 움직인다. 물건을 손에 집었을 때 공기 저항에 의해 빙글빙글 돌지 않도록 하기 위해 필요하다. 
                hitInfo.transform.position = arm.position; // 팔로 지정해둔 위치로 이동시킨다.
                hitInfo.transform.parent = GameObject.Find("Arm").transform; // 팔의 child로 넣어준다.
              
            }
        }

        else if (hitInfo.transform.name == "TTbox" && arm.transform.childCount == 0 && Stage3Gamemanager.isNewsviewed)
        {
            interactionUI[0].GetComponent<Text>().text = "TT선물상자 들기";

            if (Input.GetMouseButtonDown(0))
            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click TTbox");

                hitInfo.transform.GetComponent<Rigidbody>().useGravity = false; // gravity를 끈다.
                hitInfo.transform.GetComponent<Rigidbody>().isKinematic = true; // kinematic을 켜면 스크립트에 의해서만 움직인다. 물건을 손에 집었을 때 공기 저항에 의해 빙글빙글 돌지 않도록 하기 위해 필요하다. 
                hitInfo.transform.position = arm.position; // 팔로 지정해둔 위치로 이동시킨다.
                hitInfo.transform.parent = GameObject.Find("Arm").transform; // 팔의 child로 넣어준다.
               
            }
        }

        else if (hitInfo.transform.name == "clock" && arm.transform.childCount == 0 &&Stage3Gamemanager.isNewsviewed)
        {
            interactionUI[0].GetComponent<Text>().text = "시계 떼어내기";

            if (Input.GetMouseButtonDown(0))
            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click clock");

                hitInfo.transform.GetComponent<Rigidbody>().useGravity = false; // gravity를 끈다.
                hitInfo.transform.GetComponent<Rigidbody>().isKinematic = true; // kinematic을 켜면 스크립트에 의해서만 움직인다. 물건을 손에 집었을 때 공기 저항에 의해 빙글빙글 돌지 않도록 하기 위해 필요하다. 
                hitInfo.transform.position = arm.position; // 팔로 지정해둔 위치로 이동시킨다.
                hitInfo.transform.parent = GameObject.Find("Arm").transform; // 팔의 child로 넣어준다.

            }
        }


        else if (hitInfo.transform.name == "giftbox" && arm.transform.childCount == 0 && Stage3Gamemanager.isNewsviewed)
        {
            interactionUI[0].GetComponent<Text>().text = "선물상자 들기";

            if (Input.GetMouseButtonDown(0))
            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click giftbox");

                hitInfo.transform.GetComponent<Rigidbody>().useGravity = false; // gravity를 끈다.
                hitInfo.transform.GetComponent<Rigidbody>().isKinematic = true; // kinematic을 켜면 스크립트에 의해서만 움직인다. 물건을 손에 집었을 때 공기 저항에 의해 빙글빙글 돌지 않도록 하기 위해 필요하다. 
                hitInfo.transform.position = arm.position; // 팔로 지정해둔 위치로 이동시킨다.
                hitInfo.transform.parent = GameObject.Find("Arm").transform; // 팔의 child로 넣어준다.
               
            }
        }

        else if (hitInfo.transform.name == "Candle" && arm.transform.childCount == 0 && Stage3Gamemanager.isNewsviewed)
        {
            interactionUI[0].GetComponent<Text>().text = "양초 들기";

            if (Input.GetMouseButtonDown(0))
            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click candle");


                hitInfo.transform.GetComponent<Rigidbody>().useGravity = false; // gravity를 끈다.
                hitInfo.transform.GetComponent<Rigidbody>().isKinematic = true; // kinematic을 켜면 스크립트에 의해서만 움직인다. 물건을 손에 집었을 때 공기 저항에 의해 빙글빙글 돌지 않도록 하기 위해 필요하다. 
                hitInfo.transform.position = arm.position; // 팔로 지정해둔 위치로 이동시킨다.
                hitInfo.transform.parent = GameObject.Find("Arm").transform; // 팔의 child로 넣어준다.
              
            }
        }




        else if (hitInfo.transform.name == "가족액자" && arm.transform.childCount == 0 && Stage3Gamemanager.isNewsviewed)
        {
            interactionUI[0].GetComponent<Text>().text = "가족액자  떼어내기";

            if (Input.GetMouseButtonDown(0))
            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click family picture");

                hitInfo.transform.GetComponent<Rigidbody>().useGravity = false; // gravity를 끈다.
                hitInfo.transform.GetComponent<Rigidbody>().isKinematic = true; // kinematic을 켜면 스크립트에 의해서만 움직인다. 물건을 손에 집었을 때 공기 저항에 의해 빙글빙글 돌지 않도록 하기 위해 필요하다. 
                hitInfo.transform.position = arm.position; // 팔로 지정해둔 위치로 이동시킨다.
                hitInfo.transform.parent = GameObject.Find("Arm").transform; // 팔의 child로 넣어준다.
                hitInfo.transform.GetComponent<Transform>().localRotation = Quaternion.Euler(0f, -29f, 0f); // 앞면이 보이도록 회전 각도를 전부 0으로 맞춰준다.
               




            }
        }

        else if (hitInfo.transform.name == "sock" && arm.transform.childCount == 0 && Stage3Gamemanager.isNewsviewed)
        {
            interactionUI[0].GetComponent<Text>().text = "산타양말 떼어내기";

            if (Input.GetMouseButtonDown(0))
            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click sock");

                hitInfo.transform.GetComponent<Rigidbody>().useGravity = false; // gravity를 끈다.
                hitInfo.transform.GetComponent<Rigidbody>().isKinematic = true; // kinematic을 켜면 스크립트에 의해서만 움직인다. 물건을 손에 집었을 때 공기 저항에 의해 빙글빙글 돌지 않도록 하기 위해 필요하다. 
                hitInfo.transform.position = arm.position; // 팔로 지정해둔 위치로 이동시킨다.
                hitInfo.transform.parent = GameObject.Find("Arm").transform; // 팔의 child로 넣어준다.
               
                


            }
        }


        else if (hitInfo.transform.name == "SecretBox" && arm.transform.childCount == 0 && Stage3Gamemanager.isNewsviewed)
        {
            interactionUI[0].GetComponent<Text>().text = "비밀상자 내용물 보기";

            if (Input.GetMouseButtonDown(0))
            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click secret box");
                News.SetActive(true);




            }
        }
        else if (hitInfo.transform.name == "SecretBox" && arm.transform.childCount == 0 && Stage3Gamemanager.isSecretBoxUnlocked)
        {
            interactionUI[0].GetComponent<Text>().text = "비밀상자 내용물 보기";

            if (Input.GetMouseButtonDown(0))
            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click secret box");
                Stage3Gamemanager.isNewsviewed = true;



            }
        }




     
        else if (hitInfo.transform.name == "SecretBox" && arm.transform.childCount == 0 && !Stage3Gamemanager.isSecretBoxUnlocked)
        {
            interactionUI[0].GetComponent<Text>().text = "비밀상자 잠금 해제하기.";

            if (Input.GetMouseButtonDown(0))
            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click secret box");

                inputfield.gameObject.SetActive(true);


                GameObject.Find("Player").GetComponent<MovePlayer>().enabled = false;
                GameObject.Find("Main Camera").GetComponent<MoveCamera>().enabled = false;



            }
        }



        else if (hitInfo.transform.name == "Gingerbread" && arm.transform.childCount == 0)
        {
            interactionUI[0].GetComponent<Text>().text = "쿠키먹기";

            if (Input.GetMouseButtonDown(0))
            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("eat cookie");
                hitInfo.transform.gameObject.SetActive(false);

                StartCoroutine("eat_cookie");



            }
        }



        else if (hitInfo.transform.name == "Santa_Hat" && arm.transform.childCount == 0 && Stage3Gamemanager.isNewsviewed)
        {
            interactionUI[0].GetComponent<Text>().text = "산타모자 집기";

            if (Input.GetMouseButtonDown(0))
            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click santa_hat");

                hitInfo.transform.GetComponent<Rigidbody>().useGravity = false; // gravity를 끈다.
                hitInfo.transform.GetComponent<Rigidbody>().isKinematic = true; // kinematic을 켜면 스크립트에 의해서만 움직인다. 물건을 손에 집었을 때 공기 저항에 의해 빙글빙글 돌지 않도록 하기 위해 필요하다. 
                hitInfo.transform.position = arm.position; // 팔로 지정해둔 위치로 이동시킨다.
                hitInfo.transform.parent = GameObject.Find("Arm").transform; // 팔의 child로 넣어준다.
           

            }
        }


        else if (hitInfo.transform.name == "Candy_Cane" && arm.transform.childCount == 0 && Stage3Gamemanager.isNewsviewed)
        {
            interactionUI[0].GetComponent<Text>().text = "사탕지팡이 들기";

            if (Input.GetMouseButtonDown(0))
            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click candy_cane");

                hitInfo.transform.GetComponent<Rigidbody>().useGravity = false; // gravity를 끈다.
                hitInfo.transform.GetComponent<Rigidbody>().isKinematic = true; // kinematic을 켜면 스크립트에 의해서만 움직인다. 물건을 손에 집었을 때 공기 저항에 의해 빙글빙글 돌지 않도록 하기 위해 필요하다. 
                hitInfo.transform.position = arm.position; // 팔로 지정해둔 위치로 이동시킨다.
                hitInfo.transform.parent = GameObject.Find("Arm").transform; // 팔의 child로 넣어준다.
               


            }
        }





        else if (hitInfo.transform.name == "fireplace" && arm.transform.childCount == 0 && !Stage3Gamemanager.isNewsviewed)
        {
            interactionUI[0].GetComponent<Text>().text = "벽난로 관찰하기";

            if (Input.GetMouseButtonDown(0))
            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("explain_original_ fireplace");
                
                StartCoroutine("explain_fireplace");
            }
        }

        else if (hitInfo.transform.name == "fireplace" && arm.transform.childCount == 0&& Stage3Gamemanager.isNewsviewed)
        {
            interactionUI[0].GetComponent<Text>().text = "벽난로 관찰하기";

            if (Input.GetMouseButtonDown(0))
            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("explain_changed_ fireplace");

                StartCoroutine("explain_changed_fireplace");
            }
        }

        else if (hitInfo.transform.name == "fireplace" && arm.transform.childCount == 1 && Stage3Gamemanager.isNewsviewed)
        {
            interactionUI[0].GetComponent<Text>().text = "벽난로에 태우기";

            if (Input.GetMouseButtonDown(0))
            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click fireplace");

                Cursor.lockState = CursorLockMode.None;
                fireCheckUI.SetActive(true);
                Player.GetComponent<MovePlayer>().enabled = false; //카메라움직이기 비활성화.
                cam.GetComponent<MoveCamera>().enabled = false; //플레이어 움직이기 비활성화.  

            }
        }

    }



    IEnumerator explain_changed_fireplace()
    {
        noticeUI.SetActive(true);
        noticeUI.GetComponentInChildren<Text>().text = "불이 활활 타오르는 벽난로이다. 무언가를 태울수 있을것 같다.";
        yield return new WaitForSeconds(2f);
        noticeUI.SetActive(false);
    }

    IEnumerator explain_fireplace()
    {
        noticeUI.SetActive(true);
        noticeUI.GetComponentInChildren<Text>().text = "따뜻해 보이는 벽난로이다. 불이 잔잔하게 타오른다.";
        yield return new WaitForSeconds(2f);
        noticeUI.SetActive(false);
    }

    IEnumerator eat_cookie()
    {
        noticeUI.SetActive(true);
        noticeUI.GetComponentInChildren<Text>().text = "옴냠냠 맛있어";
        yield return new WaitForSeconds(2f);
        noticeUI.SetActive(false);
    }


    IEnumerator sayingAboutClock()
    {
        noticeUI.SetActive(true);
        noticeUI.GetComponentInChildren<Text>().text = "그걸 보면 기분이 이상해. 시간이 흐르지 않아. 왜 그럴까? 보고 싶지 않아! 생각하고 싶지 않아!";
        yield return new WaitForSeconds(2f);
        noticeUI.SetActive(false);
    }


    IEnumerator sayingAboutSock()
    {
        noticeUI.SetActive(true);
        
        noticeUI.GetComponentInChildren<Text>().text = "크리스마스 아침에 달아 놨어! 예쁘지? 엄마랑 같이! 근데 부모님은 어디 계시지? 엄마! 엄마, 어디 있어요…? 엄마! ... 잠깐 외출하셨나봐.";
       
        yield return new WaitForSeconds(2f);
        noticeUI.SetActive(false);
       
    }

    IEnumerator sayingAboutFamilypicture()
    {
        noticeUI.SetActive(true);
        noticeUI.GetComponentInChildren<Text>().text = "내가 크리스마스 다음날 그린거야. 행복해보이지 않아? 엄마...아빠... 모두들... ";
        yield return new WaitForSeconds(2f);
        noticeUI.SetActive(false);

    }

    IEnumerator noCare()
    {
        noticeUI.SetActive(true);
        noticeUI.GetComponentInChildren<Text>().text = "...";
        yield return new WaitForSeconds(2f);
        noticeUI.SetActive(false);
    }

    IEnumerator sayingHello()
    {

        noticeUI.SetActive(true);
        noticeUI.GetComponentInChildren<Text>().text = "안녕! 오랜만의 사람이네? 나랑 재밌게 놀자!";
        yield return new WaitForSeconds(2f);
        noticeUI.SetActive(false);

    }

    IEnumerator sayingMerryChristmas()
    {

        noticeUI.SetActive(true);
        noticeUI.GetComponentInChildren<Text>().text = "오늘은 일년에 한번뿐인 특별한 크리스마스!";
        yield return new WaitForSeconds(2f);
        noticeUI.SetActive(false);

    }

    IEnumerator fireAll()
    {

        noticeUI.SetActive(true);
        noticeUI.GetComponentInChildren<Text>().text = "거짓된 것들은 모두 불태워버려야해.";
        yield return new WaitForSeconds(2f);
        noticeUI.SetActive(false);

    }



}








