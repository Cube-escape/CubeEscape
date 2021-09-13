using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction9_1 : MonoBehaviour
{
    [SerializeField] Camera MainCam; //평소 카메라

    [SerializeField] GameObject Panel;

    SceneManagement sm9 = new SceneManagement();
    RaycastHit hitInfo;
    
    [SerializeField] int sizeofLazer = 10;

    public GameObject[] interactionUI;
    public GameObject noticeUI;

    int checknumber = 1;

    bool end = false;
    bool GameStart = false;
    bool GamePlay = false;
    bool[] click = new bool[8];
    bool par = false;
    bool rule = true;
    private void Start()
    {
        for (int i =0; i < 8; i++) {
            click[i] = false;
          
        }
        
    }
    private void Update()
    {

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); //메인캠에서 Ray나오도록
      

        if (Physics.Raycast(ray, out hitInfo, sizeofLazer) && (hitInfo.transform.CompareTag("interaction") || (hitInfo.transform.root.CompareTag("interaction"))))
        {
            Contact();
            
        }

        else
        {

            for (int i = 0; i < interactionUI.Length; i++)
                interactionUI[0].GetComponent<Text>().text = "";
        }
        if (Input.GetMouseButtonDown(1)&& interactionUI[3].activeSelf==true) {
            interactionUI[3].SetActive(false); //게임룰 2
            interactionUI[4].SetActive(true);
        }
        else if (Input.GetMouseButtonDown(1) && interactionUI[4].activeSelf == true)
        {
            
            interactionUI[2].SetActive(false); //게임룰 2

            if (rule)
                StartCoroutine("CheckPanel2");
            else
                par = false;
            
            
            

        }
        if (end) {
            SceneManagement.completedStage = 9;
            sm9.movetoNextStage();
        }



    }


    void Contact()
    {

        showEvent();
    }
    void nonContact()
    {

        for (int i = 0; i < interactionUI.Length; i++)
            interactionUI[0].GetComponent<Text>().text = "";
    }
    void showEvent()
    {
        Vector3 pos = GameObject.Find("Player").transform.position;
        Vector3 pos2 = GameObject.Find("Cube1").transform.position;

        //체스판 보기
        if (hitInfo.transform.name == "block")
        {
            if (!par&&rule)
                interactionUI[0].GetComponent<Text>().text = "게임 참여하기";
            else if(!par&&!rule)
                interactionUI[0].GetComponent<Text>().text = "게임 룰 다시 보기";

            if (Input.GetMouseButtonDown(0) && (!noticeUI.activeSelf && !interactionUI[2].activeSelf)&&!par)
            {
                if (rule)
                    GameObject.Find("Player").transform.position = new Vector3(-4.0418f, 0.468f, 0.308f);
              
                interactionUI[3].SetActive(true); //게임룰 2
                interactionUI[4].SetActive(false);
                
                
                 StartCoroutine("CheckPanel");

             
            }
        }
        if (GameStart)
        {
            if (hitInfo.transform.name == "Cube1_1" && !GamePlay)
            {
                interactionUI[0].GetComponent<Text>().text = "이곳으로 이동하기";
                if (Input.GetMouseButtonDown(0))
                {
                    GameObject.Find("Player").GetComponent<AudioSource>().Play();
                    click[0] = true;
                    interactionUI[19].transform.position = Vector3.MoveTowards(pos2, new Vector3((float)(pos2.x) - 0.594f, pos2.y, (float)(pos2.z) + 0.594f), 1f);
                    GameObject.Find("Player").transform.position = Vector3.MoveTowards(pos, new Vector3((float)(pos.x) - 0.594f, pos.y, (float)(pos.z) + 0.594f), 1f);

                    check();
                }
            }
            else if (hitInfo.transform.name == "Cube1_2" && !GamePlay)
            {
                interactionUI[0].GetComponent<Text>().text = "이곳으로 이동하기";
                if (Input.GetMouseButtonDown(0))
                {
                    GameObject.Find("Player").GetComponent<AudioSource>().Play();
                    click[1] = true;
                    interactionUI[19].transform.position = Vector3.MoveTowards(pos2, new Vector3((float)(pos2.x), pos2.y, (float)(pos2.z) + 0.594f), 1f);
                    GameObject.Find("Player").transform.position = Vector3.MoveTowards(pos, new Vector3((float)(pos.x), pos.y, (float)(pos.z) + 0.594f), 1f);

                    check();
                }
            }
            else if (hitInfo.transform.name == "Cube1_3" && !GamePlay)//1차 정답 , 3차 정답
            {
                interactionUI[0].GetComponent<Text>().text = "이곳으로 이동하기";
                if (Input.GetMouseButtonDown(0))
                {
                    GameObject.Find("Player").GetComponent<AudioSource>().Play();
                    click[2] = true;

                    interactionUI[19].transform.position = Vector3.MoveTowards(pos2, new Vector3((float)(pos2.x) + 0.594f, pos2.y, (float)(pos2.z) + 0.594f), 1f);
                    GameObject.Find("Player").transform.position = Vector3.MoveTowards(pos, new Vector3((float)(pos.x) + 0.594f, pos.y, (float)(pos.z) + 0.594f), 1f);

                    check();
                }
            }
            else if (hitInfo.transform.name == "Cube1_4" && !GamePlay)
            {
                interactionUI[0].GetComponent<Text>().text = "이곳으로 이동하기";
                if (Input.GetMouseButtonDown(0))
                {
                    GameObject.Find("Player").GetComponent<AudioSource>().Play();
                    click[3] = true;

                    interactionUI[19].transform.position = Vector3.MoveTowards(pos2, new Vector3((float)(pos2.x) + 0.594f, pos2.y, (float)(pos2.z)), 1f);

                    GameObject.Find("Player").transform.position = Vector3.MoveTowards(pos, new Vector3((float)(pos.x) + 0.594f, pos.y, (float)(pos.z)), 1f);

                    check();
                }
            }
            else if (hitInfo.transform.name == "Cube1_5" && !GamePlay)//3차 정답
            {
                interactionUI[0].GetComponent<Text>().text = "이곳으로 이동하기";
                if (Input.GetMouseButtonDown(0))
                {
                    GameObject.Find("Player").GetComponent<AudioSource>().Play();
                    click[4] = true;

                    interactionUI[19].transform.position = Vector3.MoveTowards(pos2, new Vector3((float)(pos2.x) + 0.594f, pos2.y, (float)(pos2.z) - 0.594f), 1f);

                    GameObject.Find("Player").transform.position = Vector3.MoveTowards(pos, new Vector3((float)(pos.x) + 0.594f, pos.y, (float)(pos.z) - 0.594f), 1f);

                    check();
                }
            }
            else if (hitInfo.transform.name == "Cube1_6" && !GamePlay)
            {
                interactionUI[0].GetComponent<Text>().text = "이곳으로 이동하기";
                if (Input.GetMouseButtonDown(0))
                {
                    GameObject.Find("Player").GetComponent<AudioSource>().Play();
                    click[5] = true;

                    interactionUI[19].transform.position = Vector3.MoveTowards(pos2, new Vector3((float)(pos2.x), pos2.y, (float)(pos2.z) - 0.594f), 1f);

                    GameObject.Find("Player").transform.position = Vector3.MoveTowards(pos, new Vector3((float)(pos.x), pos.y, (float)(pos.z) - 0.594f), 1f);

                    check();
                }
            }
            else if (hitInfo.transform.name == "Cube1_7" && !GamePlay)//2차 정답
            {
                interactionUI[0].GetComponent<Text>().text = "이곳으로 이동하기";
                if (Input.GetMouseButtonDown(0))
                {
                    GameObject.Find("Player").GetComponent<AudioSource>().Play();
                    click[6] = true;

                    interactionUI[19].transform.position = Vector3.MoveTowards(pos2, new Vector3((float)(pos2.x) - 0.594f, pos2.y, (float)(pos2.z) - 0.594f), 1f);

                    GameObject.Find("Player").transform.position = Vector3.MoveTowards(pos, new Vector3((float)(pos.x) - 0.594f, pos.y, (float)(pos.z) - 0.594f), 1f);

                    check();
                }
            }
            else if (hitInfo.transform.name == "Cube1_8" && !GamePlay)
            {
                interactionUI[0].GetComponent<Text>().text = "이곳으로 이동하기";
                if (Input.GetMouseButtonDown(0))
                {
                    GameObject.Find("Player").GetComponent<AudioSource>().Play();
                    click[7] = true;

                    interactionUI[19].transform.position = Vector3.MoveTowards(pos2, new Vector3((float)(pos2.x) - 0.594f, pos2.y, (float)(pos2.z)), 1f);

                    GameObject.Find("Player").transform.position = Vector3.MoveTowards(pos, new Vector3((float)(pos.x) - 0.594f, pos.y, (float)(pos.z)), 1f);

                    check();
                }
            }

        }

    }
    IEnumerator CheckPanel()
    {
        par = true;
       yield return new WaitForSeconds(.5f);
        interactionUI[2].SetActive(true); // 게임 룰 1

 }
     IEnumerator CheckPanel2()
     {
        yield return new WaitForSeconds(1.5f);
            interactionUI[1].SetActive(true);
            interactionUI[1].GetComponent<AudioSource>().Play();

            yield return new WaitForSeconds(1f);
            interactionUI[1].SetActive(false); //체크 끄기
            yield return new WaitForSeconds(.5f);

            interactionUI[2].SetActive(false);
            yield return new WaitForSeconds(1.5f);
            StartCoroutine("notice", "뭐야 시작부터 Check로 시작하는 거야?");
            yield return new WaitForSeconds(2f);
            StartCoroutine("notice", "내 말도 더 부족하고....");
            yield return new WaitForSeconds(2f);
            StartCoroutine("notice", "너무 불공정한 게임이잖아...!");
            yield return new WaitForSeconds(2f);
            GameStart = true;
        par = false;
        rule = false;




        }
        IEnumerator notice(string txt) //txt 를 인자로 받음.
        {
            noticeUI.SetActive(true);
            noticeUI.GetComponentInChildren<Text>().text = txt;
            yield return new WaitForSeconds(2f);
            noticeUI.SetActive(false);
        }
        void check()
        {
            if (checknumber == 1)
                StartCoroutine("FirstCheck");
            else if (checknumber == 2)
                StartCoroutine("SecondCheck");
            else if (checknumber == 3)
                StartCoroutine("ThirdCheck");
        }
        IEnumerator FirstCheck()
        {
            GamePlay = true;
            interactionUI[7].SetActive(true);
            yield return new WaitForSeconds(0.5f);
            if (click[2])
            {
                Debug.Log("선택");

                checknumber++;
                GameObject.Find("White_Horse").GetComponent<AudioSource>().Play();
                interactionUI[16].GetComponent<Animation>().Play("Knight_1_1");

                yield return new WaitForSeconds(4.3f);
                interactionUI[1].SetActive(true);
                interactionUI[1].GetComponent<AudioSource>().Play();
                yield return new WaitForSeconds(1f);
                interactionUI[1].SetActive(false);
            }
            else if (click[0] || click[6] || click[7])
            { //8행 1열 말 움직이기
                GameObject.Find("White_Horse").GetComponent<AudioSource>().Play();
                //Rook_1 애니메이션
                interactionUI[13].GetComponent<Animation>().Play("Rook_1_2");
                yield return new WaitForSeconds(5f);
                //체크메이트!
                sm9.gameover(9);




            }
            else if (click[3])
            { //5행 2열 움직이기

                if (click[3])
                {
                    GameObject.Find("White_Horse").GetComponent<AudioSource>().Play();
                    //Knight_1
                    interactionUI[16].GetComponent<Animation>().Play("Knight_1_2");
                }
                yield return new WaitForSeconds(5f);
                sm9.gameover(9);
            }
            else if (click[4])
            { //5행 6열
                GameObject.Find("White_Horse").GetComponent<AudioSource>().Play();
                //Pawn_3
                interactionUI[14].GetComponent<Animation>().Play("Pawn_3_2");
                yield return new WaitForSeconds(5f);
                sm9.gameover(9);

            }
            else if (click[5] || click[1])
            {
                GameObject.Find("White_Horse").GetComponent<AudioSource>().Play();
                //Rook_2
                interactionUI[15].GetComponent<Animation>().Play("Rook_2_1");
                yield return new WaitForSeconds(5f);
                sm9.gameover(9);
                //5행 7열
            }

            for (int i = 0; i < 8; i++)
                click[i] = false;
            yield return new WaitForSeconds(1f);
            //여기에 새로운 상대편 말 움직이기
            Debug.Log("움직이기");

            GamePlay = false;
        }
        IEnumerator SecondCheck()
        {
            GamePlay = true;
            yield return new WaitForSeconds(0.5f);
            if (click[4])
            {
                Debug.Log("선택");
                checknumber++;
                GameObject.Find("White_Horse").GetComponent<AudioSource>().Play();
                interactionUI[14].GetComponent<Animation>().Play("Pawn_3_1");
                yield return new WaitForSeconds(4.3f);
                interactionUI[1].SetActive(true);
                interactionUI[1].GetComponent<AudioSource>().Play();
                yield return new WaitForSeconds(1f);
                interactionUI[1].SetActive(false);
            }
            else if (click[0] || click[7] || click[6])
            {
                GameObject.Find("White_Horse").GetComponent<AudioSource>().Play();
                interactionUI[15].GetComponent<Animation>().Play("Rook_2_1");
                //5행2열
                yield return new WaitForSeconds(5f);
                sm9.gameover(9);
            }
            else if (click[1])
            { //6행 1열
                GameObject.Find("White_Horse").GetComponent<AudioSource>().Play();
                //Pawn1
                interactionUI[17].GetComponent<Animation>().Play("Pawn_1_1");
                yield return new WaitForSeconds(5f);
                sm9.gameover(9);
            }
            else if (click[3])
            {//5행1열
                GameObject.Find("White_Horse").GetComponent<AudioSource>().Play();
                //Pawn 2
                interactionUI[21].GetComponent<Animation>().Play("Pawn_2_1");
                yield return new WaitForSeconds(5f);
                sm9.gameover(9);
            }
            else if (click[2])
            {
                GameObject.Find("White_Horse").GetComponent<AudioSource>().Play();
                interactionUI[20].GetComponent<Animation>().Play("Bishop_2_1");
                yield return new WaitForSeconds(5f);
                sm9.gameover(9);
                //4행 2열
            }
            else if (click[5])
            {
                GameObject.Find("White_Horse").GetComponent<AudioSource>().Play();
                //Kight_2
                interactionUI[22].GetComponent<Animation>().Play("Knight_2_1");
                yield return new WaitForSeconds(5f);
                sm9.gameover(9);
                //4행 3열
            }
            for (int i = 0; i < 8; i++)
                click[i] = false;
            yield return new WaitForSeconds(1f);
            //여기에 새로운 상대편 말 움직이기
            Debug.Log("움직이기");
            GamePlay = false;
        }
        IEnumerator ThirdCheck()
        {
            GamePlay = true;
            yield return new WaitForSeconds(0.5f);
            if (click[3] || click[4] || click[6])
            {
                GameObject.Find("White_Horse").GetComponent<AudioSource>().Play();
                interactionUI[23].GetComponent<Animation>().Play("Queen_2");
                yield return new WaitForSeconds(4f);

                GameObject.Find("White_Horse").GetComponent<AudioSource>().Play();
                GameObject.Find("Pawn_Black").GetComponent<Animation>().Play("Pawn_Black");
                yield return new WaitForSeconds(3.5f);
                GameObject.Find("Pawn_Black").SetActive(false);
                interactionUI[1].GetComponent<AudioSource>().Play();
                interactionUI[1].SetActive(true);
                interactionUI[1].GetComponentInChildren<Text>().text = "승급";
                yield return new WaitForSeconds(1f);
                interactionUI[1].SetActive(false);
                interactionUI[24].SetActive(true);
                yield return new WaitForSeconds(2f);
                //체크 메이트
                interactionUI[1].SetActive(true);
                interactionUI[1].GetComponentInChildren<Text>().text = "CHECKMATE";
                yield return new WaitForSeconds(2f);
                interactionUI[1].SetActive(false);

                interactionUI[25].GetComponent<Animation>().Play("FadeOut");
                yield return new WaitForSeconds(5f);

            }
            else if (click[0])
            {
                GameObject.Find("White_Horse").GetComponent<AudioSource>().Play();
                interactionUI[20].GetComponent<Animation>().Play("Bishop_2_1");
                yield return new WaitForSeconds(5f);
                sm9.gameover(9);
                //8행 1열
            }
            else if (click[1])
            {
                GameObject.Find("White_Horse").GetComponent<AudioSource>().Play();
                interactionUI[21].GetComponent<Animation>().Play("Pawn_2_1");
                yield return new WaitForSeconds(5f);
                sm9.gameover(9);
                //8행 1열
            }
            else if (click[7])
            {
                GameObject.Find("White_Horse").GetComponent<AudioSource>().Play();
                interactionUI[22].GetComponent<Animation>().Play("Knight_2_1");
                yield return new WaitForSeconds(5f);
                sm9.gameover(9);
                //8행 1열
            }
            else if (click[2])
            {
                GameObject.Find("White_Horse").GetComponent<AudioSource>().Play();
                //Knight1 
                interactionUI[16].GetComponent<Animation>().Play("Knight_1_3");
                yield return new WaitForSeconds(5f);
                sm9.gameover(9);
            }
            else if (click[5])
            {
                GameObject.Find("White_Horse").GetComponent<AudioSource>().Play();
                //Queen
                interactionUI[23].GetComponent<Animation>().Play("Queen_1");
                yield return new WaitForSeconds(5f);
                sm9.gameover(9);
            }
            for (int i = 0; i < 8; i++)
                click[i] = false;
            yield return new WaitForSeconds(1f);
            //여기에서는 내것이 움직여서 checkmate 시키기
            Debug.Log("움직이기");
            GamePlay = false;
        }

        IEnumerator FadeOut()
        {
            yield return new WaitForSeconds(1.5f);
            Panel.SetActive(true);
            yield return new WaitForSeconds(3f);
            end = true;
        }


    }
    
