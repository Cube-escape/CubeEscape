using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class InteractionControl9 : MonoBehaviour
{


    [SerializeField] Camera MainCam; //��� ī�޶�
    [SerializeField] Camera SubCam; //ü�� �� �� ���� ī�޶�
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
        //ó�� ������ �� ����ķ�� �Ѱ� ����ķ�� ������.
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

        //ü���� ����
        if (hitInfo.transform.name == "Chair1")
        {
            Debug.Log(Knight1R + " " + Knight2R + " " + PawnR);

            
            if (OnNOff)
            {
                interactionUI[0].GetComponent<Text>().text = "���ڿ� �ɱ�";
                if (Input.GetMouseButtonDown(0)) //ü���� ������?
                {
                    MainCam.GetComponent<AudioSource>().Play();
                    Debug.Log(Knight1R + " " + Knight2R + " " + PawnR);

                    if (GameObject.Find("Hand").transform.childCount == 1) //����ķ�� ���� ���� ��� �ִٸ� �װ��� ����ķ�� �տ� �ű��
                    {
                        GameObject.Find("Hand").transform.GetChild(0).transform.position = GameObject.Find("Hand2").transform.position;
                        GameObject.Find("Hand").transform.GetChild(0).transform.parent = GameObject.Find("Hand2").transform;

                    }


                    OnNOff = false; //ü������ Ȯ��Ǿ��ٴ� �ǹ�
                }
               
            }
            
            

        }
        

        //ü�� �� �ݱ�
        else if (hitInfo.transform.name == "Knight_Black1")
        {
            interactionUI[0].GetComponent<Text>().text = "�� �ݱ�";
            if (Input.GetMouseButtonDown(0) && GameObject.Find("Hand").transform.childCount == 0 && GameObject.Find("Hand2").transform.childCount == 0)
            {
                MainCam.GetComponent<AudioSource>().Play();
                pickChess(GameObject.Find("Knight_Black1"));

            }
        }
        else if (hitInfo.transform.name == "Knight_Black2")
        {
            interactionUI[0].GetComponent<Text>().text = "�� �ݱ�";
            if (Input.GetMouseButtonDown(0) && GameObject.Find("Hand").transform.childCount == 0 && GameObject.Find("Hand2").transform.childCount == 0)
            {
                MainCam.GetComponent<AudioSource>().Play();
                pickChess(GameObject.Find("Knight_Black2"));
            }
        }
        else if (hitInfo.transform.name == "Pawn_Black1")
        {
            interactionUI[0].GetComponent<Text>().text = "�� �ݱ�";
            if (Input.GetMouseButtonDown(0) && GameObject.Find("Hand").transform.childCount == 0 && GameObject.Find("Hand2").transform.childCount == 0)
            {
                MainCam.GetComponent<AudioSource>().Play();
                pickChess(GameObject.Find("Pawn_Black1"));
            }
        }


        //ü���� �ڸ� 
        else if (!OnNOff && (hitInfo.transform.name == "Knight_place1"))
        {

            interactionUI[0].GetComponent<Text>().text = "�� ����";
            if (Input.GetMouseButtonDown(0) && GameObject.Find("Hand2").transform.childCount == 0) {
                StartCoroutine("notice", "�츮 �� ���� �� �� ����..."); 
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

            interactionUI[0].GetComponent<Text>().text = "�� ����";
            if (Input.GetMouseButtonDown(0) && GameObject.Find("Hand2").transform.childCount == 0)
            {
                MainCam.GetComponent<AudioSource>().Play();
                StartCoroutine("notice", "���⿡ �� ü������ �ʿ���...");
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

            interactionUI[0].GetComponent<Text>().text = "�� ����";
            if (Input.GetMouseButtonDown(0) && GameObject.Find("Hand2").transform.childCount == 0) {
                StartCoroutine("notice", "���⿡ �� ü������ �ʿ���...");
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

        //������ ����
        else if (hitInfo.transform.name == "Teapot")
        {

            interactionUI[0].GetComponent<Text>().text = "Ƽ�� �ݱ�";
            if (Input.GetMouseButtonDown(0)&&GameObject.Find("Hand").transform.childCount == 0)
            {
                MainCam.GetComponent<AudioSource>().Play();
                pickThing(GameObject.Find("Teapot"));
            }


        }

        //���κ���
        else if (hitInfo.transform.name == "fireplace1" &&!fireplace)
        {
            interactionUI[0].GetComponent<Text>().text = "���� ����";
            if (Input.GetMouseButtonDown(0))
            {
                MainCam.GetComponent<AudioSource>().Play();
                if (GameObject.Find("Teapot").transform.parent != GameObject.Find("Hand").transform)
                {
                    StartCoroutine("notice", "�� �ȿ� ���� �ִ� �� ����... ���� ������. ���� �ʿ���!");
                }
                else if (GameObject.Find("Teapot").transform.parent == GameObject.Find("Hand").transform)
                {
                    GameObject.Find("Teapot").transform.parent = null;

                    Debug.Log("�ִϸ��̼� ���");
                    
                    StartCoroutine("Teapot");

                }
                else if (GameObject.Find("Teacup").transform.parent == GameObject.Find("Hand").transform || GameObject.Find("Teacup2").transform.parent == GameObject.Find("Hand").transform)
                {


                    StartCoroutine("notice", "���� ��� ���� �� ���� ����.");

                }
            }
        }
        //�� ����
        else if (hitInfo.transform.name == "Teacup" || hitInfo.transform.name == "Teacup2")
        {
            interactionUI[0].GetComponent<Text>().text = "�� �ݱ�";
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
            interactionUI[0].GetComponent<Text>().text = "���� ġ���";
            if (Input.GetMouseButtonDown(0)) {
                GameObject.Find("pillow1").GetComponent<Animation>().Play("pillow1"); 
                Gobj[6].SetActive(true);
            }
                
        }
        else if (hitInfo.transform.name == "pillow3")
        {
            interactionUI[0].GetComponent<Text>().text = "���� ġ���";
            if (Input.GetMouseButtonDown(0)) {
                GameObject.Find("pillow3").GetComponent<Animation>().Play("pillow3");
             
            }
                
        }
        else if (hitInfo.transform.name == "pillow4")
        {
            interactionUI[0].GetComponent<Text>().text = "���� ġ���";
            if (Input.GetMouseButtonDown(0)) {
                GameObject.Find("pillow4").GetComponent<Animation>().Play("pillow4");
            }
                
        }
        else if (hitInfo.transform.name == "pillow5")
        {
            interactionUI[0].GetComponent<Text>().text = "���� ġ���";
            if (Input.GetMouseButtonDown(0)) {
                GameObject.Find("pillow5").GetComponent<Animation>().Play("pillow5");
            }
                
        }
        else if (hitInfo.transform.name == "Plane")
        {
            interactionUI[0].GetComponent<Text>().text = "���� ����";
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
    
    //���� ����
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
    IEnumerator notice(string txt) //txt �� ���ڷ� ����.
    {
        noticeUI.SetActive(true);
        noticeUI.GetComponentInChildren<Text>().text = txt;
        yield return new WaitForSeconds(2f);
        noticeUI.SetActive(false);
    }

    //ü���� ���
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

    //ķ ��ȯ
    void transCam(bool OnOff) {

        if (OnOff)
        {

            MainCam.enabled = true;
            SubCam.enabled = false; //����ķ �Ѱ� ����ķ ���� 
            Ray ray = MainCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); //����ķ���� Ray��������
      

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
            SubCam.enabled = true; //����ķ ���� ����ķ �ѱ�
            Ray ray = SubCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); //����ķ���� Ray��������
            


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
        if (!OnNOff && Input.GetMouseButtonDown(1)) //ü������ Ȯ��� ���¿��� ������ ���콺Ű�� ������
        {
            if (GameObject.Find("Hand2").transform.childCount == 1) //����ķ�� �տ� ���𰡰� �ִٸ�
            {
                GameObject.Find("Hand2").transform.GetChild(0).transform.position = GameObject.Find("Hand").transform.position;
                GameObject.Find("Hand2").transform.GetChild(0).transform.parent = GameObject.Find("Hand").transform;
                //����ķ�� �տ��� �Ű��ֱ�
            }
            OnNOff = true; //ü������ ��ҵǾ����� ��Ÿ��
        }
    }
    IEnumerator SetChess() {
        if (Knight1R && Knight2R && PawnR) {
            Debug.Log("ü���� �ϼ�!");
            yield return new WaitForSeconds(1f);

            StartCoroutine("notice", "����...?");
            GameObject.Find("FadeInOut").GetComponent<Animation>().Play("FadeOut");
            yield return new WaitForSeconds(3.5f);
            SceneManager.LoadScene("Stage9-1");
        }
        


    }
    
}
