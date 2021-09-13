using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionController4 : MonoBehaviour //���� ����� �ϳ��� interactioncontrller�� ����ϸ� �浹�� �����Ű��Ƽ� ������������ 1,2,3,4 �����ؼ� ����ϱ�.
{
    //[SerializeField]�� �̿��ϸ� inspector â���� ������ ����ٰ� �ʱ�ȭ ��ų �� ����. public �� ����� ����.

    [SerializeField] Camera cam;

    RaycastHit hitInfo; // RaycastHit�� �������� ���� ����� ������ ����ϴ� Ŭ����.

    [SerializeField] int sizeofLazer = 10; //lazer�� ũ��.
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




        if (Physics.Raycast(ray, out hitInfo, sizeofLazer) && hitInfo.transform.CompareTag("interaction")) //� �ݶ��̴��� ���̰� �浹������ true, �ƴϸ� false. // hitinfo �� ray�� ���� ��ü�� ������ �����ϴ� ����


        {

            Contact();
            Debug.Log(hitInfo.transform.name);// �������� ���� �繰�� �̸� ���.
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
            interactionUI[0].GetComponent<Text>().text = "å�� �����̱�";



            if (Input.GetMouseButtonDown(0))
            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click book");
            }
        }
        if ((hitInfo.transform.name == "vase_A_S3" || hitInfo.transform.name == "vase_A_S2" || hitInfo.transform.name == "vase_A_S5" || hitInfo.transform.name == "vase_A_S4" || hitInfo.transform.name == "vase_A_S1"))
        {
            interactionUI[0].GetComponent<Text>().text = "������ �ǳ�Ű������ �� �� �ȱ�";
            
                
                




            
        }
        

        else if (hitInfo.transform.name == "Book1" || hitInfo.transform.name == "Book2" || hitInfo.transform.name == "Book3" || hitInfo.transform.name == "Boo41" || hitInfo.transform.name == "Book5" || hitInfo.transform.name == "Book6" || hitInfo.transform.name == "Book7" || hitInfo.transform.name == "Book1" || hitInfo.transform.name == "Book8" || hitInfo.transform.name == "Book9")
        {
            if (!Stage4Gamemanager.isbooktouch) interactionUI[0].GetComponent<Text>().text = "å �ڼ�������";


            if (Input.GetMouseButton(0))

            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click book");

            }

        }

        else if (hitInfo.transform.name == "HorrorDoll (6)" || hitInfo.transform.name == "HorrorDoll (2)" || hitInfo.transform.name == "HorrorDoll (3)" || hitInfo.transform.name == "HorrorDoll (4)" || hitInfo.transform.name == "HorrorDoll (5)")
        {
            interactionUI[0].GetComponent<Text>().text = "�ǳ�Ű�� ������ �� ���";
            //���� ����ִ� ���¸� ���� �����Ͻðڽ��ϱ�? UI���� ���� ������� ���� ���¸� ������ ���� ���.


            if (Input.GetMouseButton(0))
            {

                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click Pinocchio");

            }
        }

        else if (hitInfo.transform.name == "DoorLeft")
        {
            interactionUI[0].GetComponent<Text>().text = "ĳ��� ����";

            if (Input.GetMouseButton(0))
            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click cabinet");
            }
        }




        else if (hitInfo.transform.name == "projector")
        {
            interactionUI[0].GetComponent<Text>().text = "���������� �۵���Ű��.";

            if (Input.GetMouseButton(0))
            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click beam project");
            }
        }

        else if (hitInfo.transform.name == "picture")
        {
            interactionUI[0].GetComponent<Text>().text = "�׸� ������";

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
            interactionUI[0].GetComponent<Text>().text = "å �ڼ�������";

            if (Input.GetMouseButton(0))
            {

                Debug.Log("click book");
            }
        }




        else if (hitInfo.transform.name == "flower01")
        {
            interactionUI[0].GetComponent<Text>().text = "�� �ݱ�";

            if (Input.GetMouseButton(0))
            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click flower");
            }
        }

        else if (hitInfo.transform.name == "Drawer1" || hitInfo.transform.name == "Drawer2" || hitInfo.transform.name == "Drawer3" || hitInfo.transform.name == "Drawer4" || hitInfo.transform.name == "Drawer_Big1" || hitInfo.transform.name == "Drawer_Big2" || hitInfo.transform.name == "Drawer_Big3" || hitInfo.transform.name == "Drawer_Med2 1" || hitInfo.transform.name == "Drawer_Med2" || hitInfo.transform.name == "Drawer_Med1")
        {
            interactionUI[0].GetComponent<Text>().text = "���� ����";

            if (Input.GetMouseButton(0))
            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click drawer");
                //��������
            }
        }



        else if (hitInfo.transform.name == "WhalePad")
        {
            if (!Stage4Gamemanager.isWhalepadUnlocked)
            {
                interactionUI[0].GetComponent<Text>().text = "����й�ȣ�Է±��Է�";
            }

            if (Input.GetMouseButton(0))
            {
                Stage4Gamemanager.isWhalepadUnlocked = true;
                interactionUI[0].GetComponent<Text>().text = "";
                Whale.SetActive(true);
                audiosource2.Play();

                Debug.Log("click WhalePad");
                //��ũ�� ������.
            }
        }



        else if (hitInfo.transform.name == "Keyboard") //
        {
            if (!Stage4Gamemanager.issafeboxunlocked) interactionUI[0].GetComponent<Text>().text = "Ű�е� �Է��ϱ�";


            if (Input.GetMouseButton(0))
            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click Keyboard");

            }
        }

        else if (hitInfo.transform.name == "Key") //
        {
            interactionUI[0].GetComponent<Text>().text = "���� �ݱ�";

            if (Input.GetMouseButton(0))
            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click Key");

            }
        }



        else if (hitInfo.transform.name == "Wall_Entrance")
        {
            interactionUI[0].GetComponent<Text>().text = "�� ����";

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

                //�ǳ�Ű�� ���������� �ذ��� ���¸� ��������������, �׷��� �������� '���� ������ �ʾ�' ���.
            }

        }


        else if (hitInfo.transform.name == "PINOCCHIO") //
        {
            interactionUI[0].GetComponent<Text>().text = "�������� ���ɱ�";

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
                interactionUI[0].GetComponent<Text>().text = "����й�ȣ�Է±��Է�";
            }

            if (Input.GetMouseButton(0))
            {
                Stage4Gamemanager.isWhalepadUnlocked = true;
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click screen");
                //��ũ�� ������.
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
        noticeUI.GetComponentInChildren<Text>().text = "���� ������ �ʾ�..";
        yield return new WaitForSeconds(2f);
        noticeUI.SetActive(false);

    }
    


    IEnumerator feelScarry()
    {

        noticeUI.SetActive(true);
        noticeUI.GetComponentInChildren<Text>().text = "�ǳ�Ű�������ΰ�..?������..";
        yield return new WaitForSeconds(2f);
        noticeUI.SetActive(false);

    }

    IEnumerator Doll_saying1()
    {

        noticeUI.SetActive(true);
        noticeUI.GetComponentInChildren<Text>().text = "���� �������Ҿƹ����� �׿����� űű. ������������.";
        yield return new WaitForSeconds(2f);
        noticeUI.SetActive(false);

    }

    IEnumerator Doll_saying2()
    {

        noticeUI.SetActive(true);
        noticeUI.GetComponentInChildren<Text>().text = "���� �������ڸ��� ���� ������ �ִ¹�.";
        yield return new WaitForSeconds(2f);
        noticeUI.SetActive(false);

    }

    IEnumerator Doll_saying3()
    {

        noticeUI.SetActive(true);
        noticeUI.GetComponentInChildren<Text>().text = "�ǳ�Ű�� �������� �������� ���� ������.";
        yield return new WaitForSeconds(2f);
        noticeUI.SetActive(false);

    }

    IEnumerator Doll_saying4()
    {

        noticeUI.SetActive(true);
        noticeUI.GetComponentInChildren<Text>().text = "�ǳ�Ű���� �� ������ �� ������� ��� �׾���.";
        yield return new WaitForSeconds(2f);
        noticeUI.SetActive(false);

    }





}

