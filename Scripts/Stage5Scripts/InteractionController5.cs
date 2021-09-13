using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class InteractionController5 : MonoBehaviour
{
    //[SerializeField]를 이용하면 inspector 창에서 옵젝을 끌어다가 초기화 시킬 수 있음. public 과 비슷한 역할.

    [SerializeField] Camera cam;

    RaycastHit hitInfo; // RaycastHit은 레이저에 맞은 대상의 정보를 기억하는 클래스.

    [SerializeField] int sizeofLazer = 100; //lazer의 크기.

    [SerializeField] GameObject[] obj;
    public GameObject[] interactionUI;
    public GameObject noticeUI;
    [SerializeField] GameObject image;
    [SerializeField] GameObject Subtitle;
    [SerializeField] Sprite[] WallPaintings;
    AudioSource audio;

    //게임 상태 관련 변수들
    bool OpenFenceState = false;
    SceneManagement sm = new SceneManagement();
    bool end = false;
    private bool isWatchingWall = false;

    [SerializeField] GameObject Panel;
    void Start()
    {
        noticeUI.SetActive(false);
        obj[1].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        
        CheckObject();
        if (end) {

            SceneManagement.completedStage = 5;
            sm.movetoNextStage();
        }
        if (Input.GetMouseButtonDown(1))
        {
            PickDownTurnOff();
            audio = GameObject.Find("Player").GetComponent<AudioSource>();
            audio.Play();
        }
        if (obj[21].activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {

                StartCoroutine("FadeOut");
            }
            else if (Input.GetKeyDown(KeyCode.N))
            {
                StartCoroutine("notice", "물에 빠지기는 무서워....");
                obj[21].SetActive(false);
            }
        }
    }

    void CheckObject()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));


        //벽화를 보는 동안에는 contact 비활성화
        if ((Physics.Raycast(ray, out hitInfo, sizeofLazer) && (hitInfo.transform.CompareTag("interaction") || hitInfo.transform.root.CompareTag("interaction"))) && !isWatchingWall) //어떤 콜라이더와 레이가 충돌했으면 true, 아니면 false. // hitinfo 는 ray에 맞은 객체의 정보를 저장하는 변수
        {
            //원래는 각각에 interaction 태그를 번거롭게 달아줘야했었는데 이제는 최상위 부모만 interaction 태그 달아줘도 인식됨.

            Contact();
            Debug.Log(hitInfo.transform.root.name);
            // Debug.Log(hitInfo.transform.name);// 레이저에 닿은 사물의 이름 출력.
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
        if (Stage5GameManager.GettingCoin && Stage5GameManager.GettingFlower) {
            obj[17].SetActive(false);
            obj[20].SetActive(true);
        }
            
        else if (hitInfo.transform.name == "BoatRiding" && !(Stage5GameManager.GettingCoin && Stage5GameManager.GettingFlower)) //플레이어가 탈 배 관련 이벤트 관리
        {
            interactionUI[0].GetComponent<Text>().text = "배 타기";


            if (GameObject.Find("Hand").transform.childCount == 0) //플레이어가 아무것도 들고 있지 않을 때
            {
                if (Input.GetMouseButtonDown(0)) //클릭을 하면
                {
                    Debug.Log("click click");
                    BoatState();
                }

            }
            else if (GameObject.Find("Hand").transform.childCount == 1)
            { //플레이어가 무언가를 가지고 있을 때
                if (GameObject.Find("Hand").transform.GetChild(0).name == "Coin") //코인을 들고 있으면
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        Stage5GameManager.GettingCoin = true;
                        PickDownTurnOff();
                        obj[2].SetActive(false);
                        BoatState(obj[2]);
                    }

                }

                else if (GameObject.Find("Hand").transform.GetChild(0).name == "plant1") //꽃을 들고 있으면
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        Stage5GameManager.GettingFlower = true;
                        PickDownTurnOff();
                        obj[3].SetActive(false);
                        BoatState(obj[3]);

                    }

                }
                else if (GameObject.Find("Hand").transform.GetChild(0).name == "plant2")
                {
                    if (Input.GetMouseButtonDown(0))
                        BoatState(obj[4]);

                }

                else if (GameObject.Find("Hand").transform.GetChild(0).name == "plant3")
                {
                    if (Input.GetMouseButtonDown(0))
                        BoatState(obj[5]);
                }
            }



        }
        else if (hitInfo.transform.name == "fence_gate1" || hitInfo.transform.name == "fence_gate2") //대문 관련 이벤트 관리
        {
            if (!OpenFenceState) interactionUI[0].GetComponent<Text>().text = "대문 열기";
            else interactionUI[0].GetComponent<Text>().text = "대문 닫기";


            if (Input.GetMouseButtonDown(0))
            {
                audio = GameObject.Find("Fence").GetComponent<AudioSource>();
                audio.Play();
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click 대문");
                OpenFence(); //문 여닫기

            }
        }
        else if (hitInfo.transform.name == "FirePlace") //화로 관련 이벤트 관리,root는 최상위 부모를 찾아줌.
        {
            Debug.Log("화로");
            if (GameObject.Find("Hand").transform.childCount == 1)
            {
                if (GameObject.Find("Hand").transform.GetChild(0).name == "OldHandTorch")
                {
                    interactionUI[0].GetComponent<Text>().text = "불 붙이기";
                    if (Input.GetMouseButtonDown(0))
                    {
                        obj[1].SetActive(true);
                        Stage5GameManager.isCandleBright = true;
                        audio = GameObject.Find("OldHandTorch").GetComponent<AudioSource>();
                        audio.Play();
                    }

                }//횃불을 들고 있을 때
                else
                {
                    interactionUI[0].GetComponent<Text>().text = "화로에 가져가기";
                    if (Input.GetMouseButtonDown(0)) StartCoroutine("notice", "이걸 가져가면 타 버릴 거야...");
                }//다른 걸 들고 있을 때

            }//손에 무언가를 들고 있을 때

            else if (GameObject.Find("Hand").transform.childCount == 0)
            {
                interactionUI[0].GetComponent<Text>().text = "화로 보기";
                if (Input.GetMouseButtonDown(0))
                {
                    interactionUI[0].GetComponent<Text>().text = "";
                    Debug.Log("click 화로");
                    StartCoroutine("notice", "불을 보니 마음이 편해지네...."); //코루틴함수이름다음에 ,(쉼표)찍고 인자전달 가능.
                }
            }//손에 아무것도 들고 있지 않을 때



        }
        else if (hitInfo.transform.name == "GameObj") //짐들 관련 이벤트 관리
        {


            interactionUI[0].GetComponent<Text>().text = "짐들 보기";



            if (Input.GetMouseButtonDown(0))
            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click 화로");
                StartCoroutine("notice", "짐이 왜 이렇게 많아..");
            }
        }
        else if (hitInfo.transform.name == "SecretDoor") //비밀의 방 관련 이벤트 관리
        {

            Debug.Log("벽에 부딪히는 레이저");
            interactionUI[0].GetComponent<Text>().text = "벽 살펴보기";



            if (Input.GetMouseButtonDown(0))
            {
                audio = GameObject.Find("SecretDoor").GetComponent<AudioSource>();
                audio.Play();
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click");
                GameObject.Find("RoomDoor").GetComponent<Animation>().Play("RoomDoor");
            }
        }
        else if (hitInfo.transform.name == "OldHandTorch") //횃불 관련 이벤트 관리
        {
            if (GameObject.Find("Hand").transform.childCount == 0) //손에 아무것도 없을 때만 뜨기
                interactionUI[0].GetComponent<Text>().text = "횃불 줍기";



            if (Input.GetMouseButtonDown(0))
            {
                audio = GameObject.Find("Player").GetComponent<AudioSource>();
                audio.Play();
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click 문");
                PickUp(obj[0]);
            }
        }


        else if (hitInfo.transform.name == "plant1" && GameObject.Find("Hand").transform.childCount == 0) //꽃말 보기 이벤트
        {
            interactionUI[0].GetComponent<Text>().text = "꽃말 보기";
            if (Input.GetMouseButtonDown(0))
            {
                audio = GameObject.Find("Player").GetComponent<AudioSource>();
                audio.Play();
                StartCoroutine("notice", "로단테(Rodanthe)\n\"항상 기억하라.\"");
                PickUp(obj[3]); //꽃 줍기
            }
        }
        else if (hitInfo.transform.name == "plant2" && GameObject.Find("Hand").transform.childCount == 0) // 꽃말 보기 이벤트
        {
            interactionUI[0].GetComponent<Text>().text = "꽃말 보기";
            if (Input.GetMouseButtonDown(0))
            {
                audio = GameObject.Find("Player").GetComponent<AudioSource>();
                audio.Play();
                StartCoroutine("notice", "검은 백합\n\"저주\"");
                PickUp(obj[4]);//꽃 줍기
            }

        }
        else if (hitInfo.transform.name == "plant3" && GameObject.Find("Hand").transform.childCount == 0) //꽃말 보기 이벤트
        {
            if (Input.GetMouseButtonDown(0))
            {
                audio = GameObject.Find("Player").GetComponent<AudioSource>();
                audio.Play();
                interactionUI[0].GetComponent<Text>().text = "꽃말 보기";
                StartCoroutine("notice", "파란 장미\n\"불가능\"");
                PickUp(obj[5]);//꽃 줍기
            }

        }
        else if (hitInfo.transform.name == "Coin")
        {
            interactionUI[0].GetComponent<Text>().text = "동전 줍기";
            if (Input.GetMouseButtonDown(0))
            {
                audio = GameObject.Find("Player").GetComponent<AudioSource>();
                audio.Play();
                PickUp(obj[2]);//동전 줍기
            }
        }
        else if (hitInfo.transform.name == "Lamp_in_Room1")  //비밀의 방 불 켜기
        {
           
            interactionUI[0].GetComponent<Text>().text = "불 켜기";
            if (obj[1].activeSelf == true && obj[0].transform.parent.name == "Hand")
            {
                Debug.Log("사실");

                if (Input.GetMouseButtonDown(0))
                {
                    audio = GameObject.Find("Player").GetComponent<AudioSource>();
                    audio.Play();
                    obj[7].SetActive(true);
                    obj[8].SetActive(true);

                }
            }
            else if (obj[0].transform.parent == null)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    audio = GameObject.Find("Player").GetComponent<AudioSource>();
                    audio.Play();
                    StartCoroutine("notice", "등불에 불을 붙여야 해...");
                }
            }
            else if (obj[0].transform.parent != null&&obj[1].activeSelf == false)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    audio = GameObject.Find("Player").GetComponent<AudioSource>();
                    audio.Play();
                    StartCoroutine("notice", "횃불에 불을 붙여야 해...");
                }
            }

        }
        else if (hitInfo.transform.name == "Lamp_in_Room2") //비밀의 방 불 켜기
        {
            

            interactionUI[0].GetComponent<Text>().text = "불 켜기";
            if (obj[1].activeSelf == true && obj[0].transform.parent.name == "Hand")
            {
                Debug.Log("사실");

                if (Input.GetMouseButtonDown(0))
                {
                    audio = GameObject.Find("Player").GetComponent<AudioSource>();
                    audio.Play();
                    obj[9].SetActive(true);
                    obj[10].SetActive(true);


                }
            }
            else if (obj[0].transform.parent == null)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    audio = GameObject.Find("Player").GetComponent<AudioSource>();
                    audio.Play();
                    StartCoroutine("notice", "등불에 불을 붙여야 해...");
                }
            }
            else if (obj[0].transform.parent != null && obj[1].activeSelf == false)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    audio = GameObject.Find("Player").GetComponent<AudioSource>();
                    audio.Play();
                    StartCoroutine("notice", "횃불에 불을 붙여야 해...");
                }
            }

        }
        else if (hitInfo.transform.name == "Lamp_in_Room3") //비밀의 방 불 켜기
        {
           
            interactionUI[0].GetComponent<Text>().text = "불 켜기";
            if (obj[1].activeSelf == true && obj[0].transform.parent.name == "Hand")
            {
                

                if (Input.GetMouseButtonDown(0))
                {
                    audio = GameObject.Find("Player").GetComponent<AudioSource>();
                    audio.Play();
                    obj[11].SetActive(true);
                    obj[12].SetActive(true);


                }
            }
            else if (obj[0].transform.parent == null)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    audio = GameObject.Find("Player").GetComponent<AudioSource>();
                    audio.Play();
                    StartCoroutine("notice", "등불에 불을 붙여야 해...");
                }
            }
            else if (obj[0].transform.parent != null && obj[1].activeSelf == false)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    audio = GameObject.Find("Player").GetComponent<AudioSource>();
                    audio.Play();
                    StartCoroutine("notice", "횃불에 불을 붙여야 해...");
                }
            }

        }
        else if (hitInfo.transform.name == "Lamp_in_Room4") //비밀의 방 불 켜기
        {
            interactionUI[0].GetComponent<Text>().text = "불 켜기";
            if (obj[1].activeSelf == true && obj[0].transform.parent.name == "Hand"   && Input.GetMouseButtonDown(0))
            {
                Debug.Log("사실");

                audio = GameObject.Find("Player").GetComponent<AudioSource>();
                audio.Play();
                obj[13].SetActive(true);
                obj[14].SetActive(true);
            }
            else if (obj[0].transform.parent == null&& Input.GetMouseButtonDown(0))
            {
                audio = GameObject.Find("Player").GetComponent<AudioSource>();
                audio.Play();
                StartCoroutine("notice", "등불에 불을 붙여야 해...");
            }
            else if (obj[0].transform.parent != null && obj[1].activeSelf == false && Input.GetMouseButtonDown(0))
            {
                audio = GameObject.Find("Player").GetComponent<AudioSource>();
                audio.Play();
                StartCoroutine("notice", "횃불에 불을 붙여야 해...");
            }

        }

        else if ((hitInfo.transform.name == "WallPainting1" || hitInfo.transform.name == "WallPainting2" || hitInfo.transform.name == "WallPainting3")) //벽화 중에 하나 레이 닿고 캔들이 켜지면
        {
            Debug.Log("벽화");
            
            
            if (obj[7].activeSelf == true && obj[9].activeSelf == true && obj[11].activeSelf == true && obj[13].activeSelf == true )
            {
                interactionUI[0].GetComponent<Text>().text = "벽화 보기";
                if (Input.GetMouseButtonDown(0))
                {
                    audio = GameObject.Find("Player").GetComponent<AudioSource>();
                    audio.Play();
                    Debug.Log("벽화 재생");
                    isWatchingWall = true; //벽화 보는 동안 contact() 비활성화
                    StartCoroutine("WallImage");
                }
            }

        }
        else if (hitInfo.transform == obj[6])
        {
            interactionUI[0].GetComponent<Text>().text = "물에 빠지기";
            if (Input.GetMouseButtonDown(0))
            {
                sm.movetoNextStage();
            }
        }

        if (hitInfo.transform.name == "book_closed"&&Stage5GameManager.RidingBoat)
        {
            interactionUI[0].GetComponent<Text>().text = "책 보기";
            if (Input.GetMouseButtonDown(0))
            {
                audio = GameObject.Find("Player").GetComponent<AudioSource>();
                audio.Play();
                obj[15].SetActive(true);
                obj[16].SetActive(false);
            }
        }
        else if (hitInfo.transform.name == "Scroll" && Stage5GameManager.RidingBoat)
        {
            interactionUI[0].GetComponent<Text>().text = "지도 보기";
            if (Input.GetMouseButtonDown(0)) obj[18].SetActive(true);
        }
        else if (hitInfo.transform.name == "UnderTheWater") {

            interactionUI[0].GetComponent<Text>().text = "물에 빠지기";
            if (Input.GetMouseButtonDown(0))
            {
                NextLevel();
            }
        }

    }

    IEnumerator notice(string txt) //txt 를 인자로 받음.
    {
        noticeUI.SetActive(true);
        noticeUI.GetComponentInChildren<Text>().text = txt;
        yield return new WaitForSeconds(2f);
        noticeUI.SetActive(false);
    }
    void OpenFence()
    { //대문 여닫는 함수
        if (!OpenFenceState) //문이 닫혔을 때
        {
            GameObject.Find("Fence").GetComponent<Animation>().Play("DoorOpen"); //문이 열리는 애니메이션 재생
            OpenFenceState = true; //문이 열린 걸로 상태 저장
        }
        else
        { //문이 열렸을 때
            GameObject.Find("Fence").GetComponent<Animation>().Play("DoorClose"); //문이 닫히는 애니메이션 재생
            OpenFenceState = false; //문이 닫힌 걸로 상태 저장
        }

    }

    void PickUp(GameObject name)
    { //물건 줍는 함수

        if (GameObject.Find("Hand").transform.childCount == 0)
        {
            name.transform.parent = GameObject.Find("Hand").transform; //아이템을 손에 상속시키기
            name.transform.position = GameObject.Find("Hand").transform.position; //아이템 위치를 손과 동일하게
            name.GetComponent<Rigidbody>().useGravity = false; //아이템에 중력 없앰
            name.GetComponent<Rigidbody>().isKinematic = true;
        }//만약 손에 아이템이 없다면


    }

    void PickDownTurnOff() //물건 떨어뜨리는 함수
    {
        for (int i = 0; i <= 5; i++)
        {
            if(i!=1)
                obj[i].transform.parent = null; //아이템을 단독으로 만들기(부모 없게)
            obj[i].GetComponent<Rigidbody>().useGravity = true; //아이템에 중력을 만들어 땅으로 떨어지게
            obj[i].GetComponent<Rigidbody>().isKinematic = false;
        }
        obj[1].SetActive(false);
        obj[15].SetActive(false);
        obj[16].SetActive(true);
        obj[18].SetActive(false);
        obj[19].SetActive(true);


    }



    //배 움직이기
    void BoatState(GameObject obj1)
    { //현재 보트를 탈 수 있는지 여부


        if (Stage5GameManager.GettingCoin) //코인을 얻었을 때
        {
            if (!Stage5GameManager.GettingFlower) //꽃은 얻지 못했을 때
            {
                if (Input.GetMouseButtonDown(0))
                { //클릭하면
                    StartCoroutine("notice", "뱃사공 : 배를 움직이는 방법이 기억이 나질 않는군...");
                    
                }

            }
            else if (Stage5GameManager.GettingFlower) //꽃을 얻었을 때
            {
                if (Input.GetMouseButtonDown(0))
                {
                    StartCoroutine("notice", "배를 이제 탈 수 있어");
                    
                    StartCoroutine("RidingBoat");
                }

            }
        }
        else //코인을 얻지 못했을 때
        {
            if (Stage5GameManager.GettingFlower) //꽃을 얻었을 때
            {
                if (Input.GetMouseButtonDown(0))
                { //클릭하면
                    StartCoroutine("notice", "뱃사공 : 배를 움직이는 방법이 기억나는구만...!\n하지만 뱃삯을 줘야지 배를 탈 수 있어.");
                    
                }

            }

        }


    }
    void BoatState()
    { //현재 보트를 탈 수 있는지 여부
        if (!Stage5GameManager.GettingCoin)
        {

            StartCoroutine("notice", "뱃사공 : 뱃삯을 줘야만 배를 탈 수 있네.");
        }


    }
    IEnumerator RidingBoat()
    {
        Stage5GameManager.RidingBoat = true;
        yield return new WaitForSeconds(1f);
        
        GameObject.Find("Player").GetComponent<Animation>().Play("RidingBoat");  //배에 올라타는 애니메이션

        yield return new WaitForSeconds(2.5f);

        GameObject.Find("BoatRiding").transform.parent = GameObject.Find("Player").transform; //플레이어를 배에 상속시키기
        GameObject.Find("BoatRiding").transform.localPosition = new Vector3(0, -1, 4); //플레이어 위치를 배의 위치로

        GameObject.Find("BoatRiding").transform.localRotation = Quaternion.Euler(0f, 0f, 0f); //플레이어와 배의 각도 조절
        GameObject.Find("Player").transform.localRotation = Quaternion.Euler(0f, 180f, 0f);

        yield return new WaitForSeconds(3f);
        interactionUI[2].SetActive(true);
        yield return new WaitForSeconds(3f);
        interactionUI[2].SetActive(false);

    }
    IEnumerator WallImage()
    {
        obj[22].SetActive(true); //파티클 나오게 만들기
        yield return new WaitForSeconds(1.5f); // 지연
        StartCoroutine("notice", "뭐지..?!"); 
        yield return new WaitForSeconds(3f);
        
        //원래 브금 끄고 새 브금 켜기 페이드인시작
        GameObject.Find("Hand").GetComponent<AudioSource>().Stop();
        GameObject.Find("Main Camera").GetComponent<AudioSource>().Stop();
        interactionUI[0].SetActive(false);
        interactionUI[1].SetActive(false);
        GameObject.Find("FadeInOut").GetComponent<Animation>().Play("FadeOuy");
        yield return new WaitForSeconds(0.5f);
        GameObject.Find("FadeInOut").GetComponent<Animation>().Play("FadeIn");
        
        GameObject.Find("FadeInOut").GetComponent<Animation>().Play("FadeOuy");

        obj[23].GetComponent<AudioSource>().Play();
        for (int i = 1; i < 9; i++)
        {
            
            
            
            image.GetComponent<Image>().sprite = WallPaintings[i];
            Subtitle.SetActive(true);
            if (i == 1) GameObject.Find("Subtitles").GetComponentInChildren<Text>().text = "아주 오래전, 이 세상은 행복과 사랑으로 가득했다.";
            else if (i == 2) GameObject.Find("Subtitles").GetComponentInChildren<Text>().text = "그러던 어느 날, 제우스는 인간 세상에 재앙을 내려보내고자 하였고 판도라를 인간 세상에 내려보냈다.\n";
            else if (i == 3) GameObject.Find("Subtitles").GetComponentInChildren<Text>().text = "인간 세상에 내려간 판도라는 행복과 불행이 봉인되어 있는 상자를 보게 되었다.";
            else if (i == 4) GameObject.Find("Subtitles").GetComponentInChildren<Text>().text = "호기심이 많던 판도라는 결국 열어서는 안 될 상자를 열어버렸고 결국 세상에는 나와선 안 될 해악들이 나오고 말았다.\n죽음, 병, 질투와 증오와 같은 해악들이 세상에 퍼지자 인간들은 서로를 증오하고 미워하며 해치고 죽였다.";
            else if (i == 5) GameObject.Find("Subtitles").GetComponentInChildren<Text>().text = "서로를 해치고 미워하며 인간들의 죄는 점점 무거워졌고 결국 다시 이생을 살아가며 전생의 삶을 속죄하며 살아가야했다.";
            else if (i == 6) GameObject.Find("Subtitles").GetComponentInChildren<Text>().text = "전생의 기억을 가지고 이생을 살아가던 인간들은 계속해서 고통받았고 이를 안타깝게 여긴 레테는 인간들에게 축복을 내리고자 하였다.";
            else if (i == 7) GameObject.Find("Subtitles").GetComponentInChildren<Text>().text = "그 축복은 바로 '망각'이었다. 인간들은 죽은 후 레테의 강에서 강물을 마시고 전생의 기억을 레테의 강에 버리고 새롭게 이생을 살 수 있게 되었다. ";
            else if (i == 8) GameObject.Find("Subtitles").GetComponentInChildren<Text>().text = "그것이 바로 레테의 축복, '망각'이다.";


            yield return new WaitForSeconds(7f);
            GameObject.Find("FadeInOut").GetComponent<Animation>().Play("FadeInOut");
            yield return new WaitForSeconds(1.5f);
        }
        
        obj[22].SetActive(false);
        Subtitle.SetActive(false);
        Subtitle.GetComponent<AudioSource>().Stop();
        obj[2].SetActive(true);
        
        GameObject.Find("Hand").GetComponent<AudioSource>().Play();
        GameObject.Find("Main Camera").GetComponent<AudioSource>().Play();

        obj[23].GetComponent<AudioSource>().Stop();

        yield return new WaitForSeconds(2.5f);
        
        StartCoroutine("notice", "그렇다면 이곳이 레테의 '기억 망각의 강'...?");
        obj[2].GetComponent<AudioSource>().Play();
        CoinDrop();
        interactionUI[0].SetActive(true);
        interactionUI[1].SetActive(true);
        isWatchingWall = false; //다시 contact() 활성화 
    }
    void CoinDrop() {
        obj[2].SetActive(true);
    }
    void NextLevel() {
        obj[21].SetActive(true);
        
    }
    IEnumerator FadeOut() {
        yield return new WaitForSeconds(1.5f);
        Panel.SetActive(true);
        yield return new WaitForSeconds(3f);
        end = true;

    }
}