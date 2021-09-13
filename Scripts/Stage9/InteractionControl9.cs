using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class InteractionControl9 : MonoBehaviour
{


    [SerializeField] Camera MainCam; //평소 카메라
    [SerializeField] Camera SubCam; //체스 둘 때 서브 카메라
    [SerializeField] GameObject[] Gobj;

    bool OnNOff = true;
    bool PawnR = false;
    bool Knight1R = false;
    bool Knight2R = false;
    bool Menu = false;
    bool fireplace = false;
    RaycastHit hitInfo;

    [SerializeField] int sizeofLazer = 10;

    public GameObject[] interactionUI;
    public GameObject noticeUI;

    private void Start()
    {
        //처음 시작할 땐 메인캠은 켜고 서브캠은 꺼놓기.
        MainCam.enabled = true;
        SubCam.enabled = false;
        bool PawnR = false;
        bool Knight1R = false;
        bool Knight2R = false;
    }
    private void Update()
    {
        CheckObject();
        
        Drop();
        if (Input.GetMouseButtonDown(1))
        {
            Gobj[10].SetActive(false);



        }
       
        



    }
    void CheckObject() {

        transCam(OnNOff);

        
    }
    
    void Contact() {
        showEvent();
    }
    void nonContact() {

        for (int i = 0; i < interactionUI.Length; i++)
            interactionUI[0].GetComponent<Text>().text = "";
    }
    void showEvent() {

        //체스판 보기
        if (hitInfo.transform.name == "Chair1")
        {
            Debug.Log(Knight1R + " " + Knight2R + " " + PawnR);

            
            if (OnNOff)
            {
                interactionUI[0].GetComponent<Text>().text = "의자에 앉기";
                if (Input.GetMouseButtonDown(0)) //체스판 누르면?
                {
                    MainCam.GetComponent<AudioSource>().Play();
                    Debug.Log(Knight1R + " " + Knight2R + " " + PawnR);

                    if (GameObject.Find("Hand").transform.childCount == 1) //메인캠의 손이 무언가 들고 있다면 그것을 서브캠의 손에 옮기기
                    {
                        GameObject.Find("Hand").transform.GetChild(0).transform.position = GameObject.Find("Hand2").transform.position;
                        GameObject.Find("Hand").transform.GetChild(0).transform.parent = GameObject.Find("Hand2").transform;

                    }


                    OnNOff = false; //체스판이 확대되었다는 의미
                }
               
            }
            
            

        }
        

        //체스 말 줍기
        else if (hitInfo.transform.name == "Knight_Black1")
        {
            interactionUI[0].GetComponent<Text>().text = "말 줍기";
            if (Input.GetMouseButtonDown(0) && GameObject.Find("Hand").transform.childCount == 0 && GameObject.Find("Hand2").transform.childCount == 0)
            {
                MainCam.GetComponent<AudioSource>().Play();
                pickChess(GameObject.Find("Knight_Black1"));

            }
        }
        else if (hitInfo.transform.name == "Knight_Black2")
        {
            interactionUI[0].GetComponent<Text>().text = "말 줍기";
            if (Input.GetMouseButtonDown(0) && GameObject.Find("Hand").transform.childCount == 0 && GameObject.Find("Hand2").transform.childCount == 0)
            {
                MainCam.GetComponent<AudioSource>().Play();
                pickChess(GameObject.Find("Knight_Black2"));
            }
        }
        else if (hitInfo.transform.name == "Pawn_Black1")
        {
            interactionUI[0].GetComponent<Text>().text = "말 줍기";
            if (Input.GetMouseButtonDown(0) && GameObject.Find("Hand").transform.childCount == 0 && GameObject.Find("Hand2").transform.childCount == 0)
            {
                MainCam.GetComponent<AudioSource>().Play();
                pickChess(GameObject.Find("Pawn_Black1"));
            }
        }


        //체스판 자리 
        else if (!OnNOff && (hitInfo.transform.name == "Knight_place1"))
        {

            interactionUI[0].GetComponent<Text>().text = "말 놓기";
            if (Input.GetMouseButtonDown(0) && GameObject.Find("Hand2").transform.childCount == 0) {
                StartCoroutine("notice", "우리 팀 말이 몇 개 없어..."); 
                MainCam.GetComponent<AudioSource>().Play();
            }
                
            else if (Input.GetMouseButtonDown(0) && GameObject.Find("Hand2").transform.childCount == 1)
            {
                MainCam.GetComponent<AudioSource>().Play();
                if (GameObject.Find("Hand2").transform.GetChild(0).name == "Knight_Black1")
                    Knight1R = true;
                GameObject.Find("Hand2").transform.GetChild(0).transform.position = new Vector3(3.712f, -13.73f, -1.41f);
                GameObject.Find("Hand2").transform.GetChild(0).transform.parent = null;
                Gobj[0].SetActive(false);
                if (PawnR && Knight1R && Knight2R)
                {
                    StartCoroutine("SetChess");
                }
            }
        }
        else if (!OnNOff && (hitInfo.transform.name == "Pawn_place1"))
        {

            interactionUI[0].GetComponent<Text>().text = "말 놓기";
            if (Input.GetMouseButtonDown(0) && GameObject.Find("Hand2").transform.childCount == 0)
            {
                MainCam.GetComponent<AudioSource>().Play();
                StartCoroutine("notice", "여기에 둘 체스말이 필요해...");
            }

            else if (Input.GetMouseButtonDown(0) && GameObject.Find("Hand2").transform.childCount == 1)
            {
                MainCam.GetComponent<AudioSource>().Play();
                if (GameObject.Find("Hand2").transform.GetChild(0).name == "Pawn_Black1")
                    PawnR = true;
                GameObject.Find("Hand2").transform.GetChild(0).transform.position = new Vector3(2.987f, -13.73f, -1.09f);
                GameObject.Find("Hand2").transform.GetChild(0).transform.parent = null;
                Gobj[1].SetActive(false);
                if (PawnR && Knight1R && Knight2R)
                {
                    StartCoroutine("SetChess");
                }
            }
        }
        else if (!OnNOff && hitInfo.transform.name == "Knight_place2")
        {

            interactionUI[0].GetComponent<Text>().text = "말 놓기";
            if (Input.GetMouseButtonDown(0) && GameObject.Find("Hand2").transform.childCount == 0) {
                StartCoroutine("notice", "여기에 둘 체스말이 필요해...");
                MainCam.GetComponent<AudioSource>().Play();
            }
                
            else if (Input.GetMouseButtonDown(0) && GameObject.Find("Hand2").transform.childCount == 1)
            {
                MainCam.GetComponent<AudioSource>().Play();
                if (GameObject.Find("Hand2").transform.GetChild(0).name == "Knight_Black2")
                    Knight2R = true;
                GameObject.Find("Hand2").transform.GetChild(0).transform.position = new Vector3(2.25f, -13.73f, -1.535f);
                GameObject.Find("Hand2").transform.GetChild(0).transform.parent = null;
                Gobj[2].SetActive(false);
                if (PawnR && Knight1R && Knight2R)
                {
                    StartCoroutine("SetChess");
                }
            }
        }

        //주전자 보기
        else if (hitInfo.transform.name == "Teapot")
        {

            interactionUI[0].GetComponent<Text>().text = "티팟 줍기";
            if (Input.GetMouseButtonDown(0)&&GameObject.Find("Hand").transform.childCount == 0)
            {
                MainCam.GetComponent<AudioSource>().Play();
                pickThing(GameObject.Find("Teapot"));
            }


        }

        //난로보기
        else if (hitInfo.transform.name == "fireplace1" &&!fireplace)
        {
            interactionUI[0].GetComponent<Text>().text = "난로 보기";
            if (Input.GetMouseButtonDown(0))
            {
                MainCam.GetComponent<AudioSource>().Play();
                if (GameObject.Find("Teapot").transform.parent != GameObject.Find("Hand").transform)
                {
                    StartCoroutine("notice", "저 안에 무언가 있는 거 같아... 불을 꺼보자. 물이 필요해!");
                }
                else if (GameObject.Find("Teapot").transform.parent == GameObject.Find("Hand").transform)
                {
                    GameObject.Find("Teapot").transform.parent = null;

                    Debug.Log("애니메이션 재생");
                    
                    StartCoroutine("Teapot");

                }
                else if (GameObject.Find("Teacup").transform.parent == GameObject.Find("Hand").transform || GameObject.Find("Teacup2").transform.parent == GameObject.Find("Hand").transform)
                {


                    StartCoroutine("notice", "물이 없어서 불을 끌 수가 없어.");

                }
            }
        }
        //컵 보기
        else if (hitInfo.transform.name == "Teacup" || hitInfo.transform.name == "Teacup2")
        {
            interactionUI[0].GetComponent<Text>().text = "잔 줍기";
            if (Input.GetMouseButtonDown(0) && GameObject.Find("Hand").transform.childCount == 0)
            {
                MainCam.GetComponent<AudioSource>().Play();
                if (hitInfo.transform.name == "Teacup")
                    pickThing(GameObject.Find("Teacup"));
                else if (hitInfo.transform.name == "Teacup2")
                    pickThing(GameObject.Find("Teacup2"));
            }
        }
        else if (hitInfo.transform.name == "pillow1")
        {
            interactionUI[0].GetComponent<Text>().text = "베개 치우기";
            if (Input.GetMouseButtonDown(0)) {
                GameObject.Find("pillow1").GetComponent<Animation>().Play("pillow1"); 
                Gobj[6].SetActive(true);
            }
                
        }
        else if (hitInfo.transform.name == "pillow3")
        {
            interactionUI[0].GetComponent<Text>().text = "베개 치우기";
            if (Input.GetMouseButtonDown(0)) {
                GameObject.Find("pillow3").GetComponent<Animation>().Play("pillow3");
             
            }
                
        }
        else if (hitInfo.transform.name == "pillow4")
        {
            interactionUI[0].GetComponent<Text>().text = "베개 치우기";
            if (Input.GetMouseButtonDown(0)) {
                GameObject.Find("pillow4").GetComponent<Animation>().Play("pillow4");
            }
                
        }
        else if (hitInfo.transform.name == "pillow5")
        {
            interactionUI[0].GetComponent<Text>().text = "베개 치우기";
            if (Input.GetMouseButtonDown(0)) {
                GameObject.Find("pillow5").GetComponent<Animation>().Play("pillow5");
            }
                
        }
        else if (hitInfo.transform.name == "Plane")
        {
            interactionUI[0].GetComponent<Text>().text = "편지 보기";
            if (Input.GetMouseButtonDown(0) )
            {

                GameObject.Find("Plane").GetComponent<AudioSource>().Play();
               Gobj[10].SetActive(true);



            }
        }
        
    }

    IEnumerator Teapot() {
        fireplace = true;
        GameObject.Find("Teapot").GetComponent<Animation>().Play("WaterDrop");
        yield return new WaitForSeconds(2f);
        GameObject.Find("Teapot").GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(8.5f);
        Gobj[5].SetActive(true);
        GameObject.Find("Fire").SetActive(false);
        GameObject.Find("Teapot").SetActive(false);
    }
    
    //물건 놓기
    void Drop()
    {
        if (Input.GetMouseButtonDown(1)) {
            if (GameObject.Find("Hand").transform.childCount == 1&&MainCam.enabled==true)
            {
                GameObject.Find("Hand").transform.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;
                GameObject.Find("Hand").transform.GetChild(0).GetComponent<Rigidbody>().useGravity = true;
                GameObject.Find("Hand").transform.GetChild(0).parent = null;


            }
        }
        
    }
    //noticeUI
    IEnumerator notice(string txt) //txt 를 인자로 받음.
    {
        noticeUI.SetActive(true);
        noticeUI.GetComponentInChildren<Text>().text = txt;
        yield return new WaitForSeconds(2f);
        noticeUI.SetActive(false);
    }

    //체스말 들기
    void pickChess(GameObject obj) {

        if (obj.name == "Knight_Black1")
            Knight1R = false;
        else if (obj.name == "Knight_Black2")
            Knight2R = false;
        else if (obj.name == "Pawn_Black1")
            PawnR = false;

        
        obj.GetComponent<Rigidbody>().useGravity = false;
        obj.GetComponent<Rigidbody>().isKinematic = true;
        if (OnNOff)
        {
            obj.transform.parent = GameObject.Find("Hand").transform;
            obj.transform.position = GameObject.Find("Hand").transform.position;

        }
        else
        {


            if (obj.transform.position == new Vector3(3.712f, -13.73f, -1.41f))
                Gobj[0].SetActive(true);
            else if (obj.transform.position == new Vector3(2.987f, -13.73f, -1.09f))
                Gobj[1].SetActive(true);
            else if (obj.transform.position == new Vector3(2.25f, -13.73f, -1.535f))
                Gobj[2].SetActive(true);
            obj.transform.parent = GameObject.Find("Hand2").transform;
            obj.transform.position = GameObject.Find("Hand2").transform.position;

        }
    }

    void pickThing(GameObject obj)
    {


        obj.GetComponent<Rigidbody>().useGravity = false;
        obj.GetComponent<Rigidbody>().isKinematic = true;
        obj.transform.parent = GameObject.Find("Hand").transform;
        obj.transform.position = GameObject.Find("Hand").transform.position;
    }

    //캠 전환
    void transCam(bool OnOff) {

        if (OnOff)
        {

            MainCam.enabled = true;
            SubCam.enabled = false; //메인캠 켜고 서브캠 끄기 
            Ray ray = MainCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); //메인캠에서 Ray나오도록
      

            if (Physics.Raycast(ray, out hitInfo, sizeofLazer) && (hitInfo.transform.CompareTag("interaction") || (hitInfo.transform.root.CompareTag("interaction"))))
            {

                Contact();
                Debug.Log(hitInfo.transform.root.name);
            }
            else
            {

                nonContact();
            }
        }

        else {
            MainCam.enabled = false;
            SubCam.enabled = true; //메인캠 끄고 서브캠 켜기
            Ray ray = SubCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); //서브캠에서 Ray나오도록
            


            if (Physics.Raycast(ray, out hitInfo, sizeofLazer) && (hitInfo.transform.CompareTag("interaction") || (hitInfo.transform.root.CompareTag("interaction"))))
            {

                Contact();
                Debug.Log(hitInfo.transform.root.name);
            }
            else
            {

                nonContact();
            }
        }
        if (!OnNOff && Input.GetMouseButtonDown(1)) //체스판이 확대된 상태에서 오른쪽 마우스키를 누르면
        {
            if (GameObject.Find("Hand2").transform.childCount == 1) //서브캠의 손에 무언가가 있다면
            {
                GameObject.Find("Hand2").transform.GetChild(0).transform.position = GameObject.Find("Hand").transform.position;
                GameObject.Find("Hand2").transform.GetChild(0).transform.parent = GameObject.Find("Hand").transform;
                //메인캠의 손에게 옮겨주기
            }
            OnNOff = true; //체스판이 축소되었음을 나타냄
        }
    }
    IEnumerator SetChess() {
        if (Knight1R && Knight2R && PawnR) {
            Debug.Log("체스판 완성!");
            yield return new WaitForSeconds(1f);

            StartCoroutine("notice", "뭐지...?");
            GameObject.Find("FadeInOut").GetComponent<Animation>().Play("FadeOut");
            yield return new WaitForSeconds(3.5f);
            SceneManager.LoadScene("Stage9-1");
        }
        


    }
    
}
