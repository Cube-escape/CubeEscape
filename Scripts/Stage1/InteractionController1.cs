using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionController1 : MonoBehaviour 
{
    //[SerializeField]�� �̿��ϸ� inspector â���� ������ ����ٰ� �ʱ�ȭ ��ų �� ����. public �� ����� ����.

    RaycastHit hitInfo; // RaycastHit�� �������� ���� ����� ������ ����ϴ� Ŭ����.

    private Stage1Gamemanager gm1;
    private SceneManagement sm1;

    [SerializeField] int sizeofLazer = 40; //lazer�� ũ��.

    public GameObject[] interactionUI;
    public GameObject noticeUI;
    public GameObject keypadUI;
    public GameObject codeLockUI;
    public GameObject paperUI;
    public GameObject fadeOutPanel; //�������� Ŭ���� �� fade out

    public GameObject player1; 
    public GameObject player2;
    public Camera cam2; //player2�� ī�޶�
    public Transform arm; //player2�� ��

    public GameObject key;

    public static bool isUsingKeyPad = false;
    public static bool isUsingCodeLock = false;
    public static bool isReadingPaper = false;

    private bool stageEnd = false; //�������� Ŭ���� �� ���̵� �ƿ� ���� true
    private bool openDoor = false; //�� ���� ���ͷ��� UI ���� ���� �÷���
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

        if (arm.transform.childCount == 1 && Input.GetMouseButtonDown(1)) //���踦 �� ä�� ��Ŭ�� ��
        {
            arm.transform.GetComponentInChildren<Rigidbody>().useGravity = true; //�߷� ���� - ���� ����������
            arm.transform.GetComponentInChildren<Rigidbody>().isKinematic = false;
            arm.GetChild(0).parent = null;

            Stage1Gamemanager.doesPlayerhavekey = false;
        }

        if (stageEnd) //���� ���������� ��ȯ
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

        //(Ray ����, Ray ����, �浹 ������ RaycastHit, Ray �Ÿ�(����))
        //isUsingKeyPad�� isUsingCodeLock�� false�� �� ray�� interaction �±׸� �ް� �ִ� ������Ʈ�� �浹�ϸ�
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
        showEvent(); // �������� ���� ��ü�� ������ ���� �� �� �ִ� ������ ���� UI �� ������.
    }

    void notContact()
    {
        if (!isUsingKeyPad && !isUsingCodeLock && !isReadingPaper && !openDoor)
        {
            for (int i = 1; i < interactionUI.Length; i++)
            {
                interactionUI[i].SetActive(false); //crosshair�� ������ ��� interaction UI�� ��Ȱ��ȭ ��Ų��.
            }
            interactionUI[0].SetActive(true); //crosshair Ȱ��ȭ
        }
        else 
        {
            for (int i = 0; i < interactionUI.Length; i++)
            {
                interactionUI[i].SetActive(false); //��� interaction UI�� ��Ȱ��ȭ ��Ų��.
            }
        }
    }

    void showEvent()
    {
        if (hitInfo.transform.name == "CubePoster") // ray�� ���� ����� �̸��� "CubePoster" (���� ������Ʈ �̸�) ���
        {
            interactionUI[1].SetActive(true);//PosterUI�� ����.

            //�� ���¿��� ���콺 ���ʹ�ư�� Ŭ���ϸ�
            if (Input.GetMouseButtonDown(0)) //0�� ���콺 ����. 1�� ���콺 ������
            {
                interactionUI[1].SetActive(false); //Event�� ��Ÿ���� ui�� ����.
                if (Random.Range(0, 2) == 0)
                    StartCoroutine("Poster_Saying1");
                if (Random.Range(0, 2) == 1)
                    StartCoroutine("Poster_Saying2");
            }
        }

        else if (hitInfo.transform.name == "KeyPad") //ray�� keypad�� �浹�� ��� + ���� 1�� �ذ��ϱ� ���� ���
        {
            interactionUI[2].SetActive(true); //Keypad UI�� ����

            if (Input.GetMouseButtonDown(0)) //���콺 ���� Ŭ����
            {
                isUsingKeyPad = true; //crosshair ����

                player2.GetComponent<MovePlayer>().enabled = false; //ȭ�� ������ ����
                cam2.GetComponent<MoveCamera>().enabled = false; //ī�޶� ������ ����
                Cursor.lockState = CursorLockMode.None; //Ŀ���� ����

                keypadUI.SetActive(true); //Ű�е� UI �ѱ�
            }

        }

        //���� ���踦 ��� �ִ� ���¿� �ƴ� ���·� ����
        else if (hitInfo.transform.name == "Door") //ray�� Door�� �浹�� ���
        {
            interactionUI[3].SetActive(true); //Door UI�� ���� 
            interactionUI[5].SetActive(false); //���� ��ġ UI ����
            interactionUI[6].SetActive(false); //�ڹ��� UI ����
            interactionUI[7].SetActive(false); //���� ���� UI ����

            if (Input.GetMouseButtonDown(0)) //0�� ���콺 ����. 1�� ���콺 ������
            {
                interactionUI[3].SetActive(false); //Door UI�� ����

                if (Stage1Gamemanager.doesPlayerhavekey) //���踦 ��� �ִ� ���
                {
                    openDoor = true;
                    fadeOutPanel.SetActive(true); //fade out panel �ѱ�
                    StartCoroutine("StageEndFadeOut");
                }
                else StartCoroutine("noKey");
            }
        }

        else if (hitInfo.transform.name == "Monitor(off)")
        {
            interactionUI[4].SetActive(true); //Monitor UI�� ���� 

            if (Input.GetMouseButtonDown(0)) //0�� ���콺 ����. 1�� ���콺 ������
            {
                interactionUI[4].SetActive(false); //Monitor UI�� ����
                if (recallFlag == 0)
                    StartCoroutine("recall_dialogue1");
                if (recallFlag == 1)
                    StartCoroutine("recall_dialogue2");
            }
        }

        else if (hitInfo.transform.name == "Paper")
        {
            if (Stage1Gamemanager.does2ndSolved == -1) //������ Ǯ�� ������ �۵�
            {
                interactionUI[5].SetActive(true); //���� ��ġ ��ġ�� ����
                interactionUI[6].SetActive(false); //�ڹ��� UI ����
                interactionUI[3].SetActive(false); //������ UI ����

                if (Input.GetMouseButtonDown(0)) //���콺 ���� Ŭ����
                {
                    isReadingPaper = true; //crosshair�� ������ interactionUI ����

                    player2.GetComponent<MovePlayer>().enabled = false; //ȭ�� ������ ����
                    cam2.GetComponent<MoveCamera>().enabled = false; //ī�޶� ������ ����
                    Cursor.lockState = CursorLockMode.None; //Ŀ���� ����

                    paperUI.SetActive(true); //���� UI �ѱ�
                }
            }

            //��Ŭ�� �� ���� ���� 
        }

        else if (hitInfo.transform.name == "Container")
        {
            if ((Stage1Gamemanager.does1stSolved == 1) && (Stage1Gamemanager.does2ndSolved == -1)) //1�� ���� �ذ� �� 2�� ���� �ذ� ��
            {
                interactionUI[6].SetActive(true); //�ڹ��� �����ϱ� ����
                interactionUI[5].SetActive(false); //���� ��ġ UI ����
                interactionUI[3].SetActive(false); //������ UI ����

                if (Input.GetMouseButtonDown(0)) //���콺 ���� Ŭ����
                {
                    isUsingCodeLock = true; //crosshair�� ������ interactionUI ����

                    player2.GetComponent<MovePlayer>().enabled = false; //ȭ�� ������ ����
                    cam2.GetComponent<MoveCamera>().enabled = false; //ī�޶� ������ ����
                    Cursor.lockState = CursorLockMode.None; //Ŀ���� ����

                    codeLockUI.SetActive(true); //�ڹ��� UI �ѱ�
                }

            }
            else if (Stage1Gamemanager.does2ndSolved == 0) //2�� ���� �ذ� ��
            {
                interactionUI[7].SetActive(true); //���� ���� ����
                interactionUI[3].SetActive(false); //������ UI ����

                if (Input.GetMouseButtonDown(0)) //���콺 ���� Ŭ����
                {
                    interactionUI[7].SetActive(false); //���� ���� ����

                    //���� ȹ�� - arm�� ��� ��
                    if (arm.transform.childCount == 0)
                    {
                        key.GetComponent<Rigidbody>().useGravity = false; // gravity�� ����.
                        key.GetComponent<Rigidbody>().isKinematic = true; // kinematic�� �Ѹ� ��ũ��Ʈ�� ���ؼ��� �����δ�. ������ �տ� ������ �� ���� ���׿� ���� ���ۺ��� ���� �ʵ��� �ϱ� ���� �ʿ��ϴ�. 
                        key.transform.position = arm.transform.position; // �ȷ� �����ص� ��ġ�� �̵���Ų��.
                        key.transform.parent = arm.transform; // ���� child�� �־��ش�.

                        key.GetComponent<Transform>().localRotation = Quaternion.Euler(90f, 90f, 0f); // �ո��� ���̵��� ȸ�� ���� ����
                        key.GetComponent<Transform>().localScale = new Vector3(20f, 20f, 20f);

                        Stage1Gamemanager.doesPlayerhavekey = true;
                    }
                }
            }
        }

        else if (hitInfo.transform.name == "Key" && !Stage1Gamemanager.doesPlayerhavekey) //���踦 �ٴڿ� ����߸� �� �ٽ� �ݴ� ��� 
        {
            interactionUI[8].SetActive(true); //���� �ݱ� ����

            if (Input.GetMouseButtonDown(0)) //���콺 ���� Ŭ����
            {
                interactionUI[8].SetActive(false); //���� �ݱ� ����

                //���� ȹ�� - arm�� ��� ��
                if (arm.transform.childCount == 0)
                {
                    key.GetComponent<Rigidbody>().useGravity = false; // gravity�� ����.
                    key.GetComponent<Rigidbody>().isKinematic = true; // kinematic�� �Ѹ� ��ũ��Ʈ�� ���ؼ��� �����δ�. ������ �տ� ������ �� ���� ���׿� ���� ���ۺ��� ���� �ʵ��� �ϱ� ���� �ʿ��ϴ�. 
                    key.transform.position = arm.transform.position; // �ȷ� �����ص� ��ġ�� �̵���Ų��.
                    key.transform.parent = arm.transform; // ���� child�� �־��ش�.

                    key.GetComponent<Transform>().localRotation = Quaternion.Euler(90f, 90f, 0f); // �ո��� ���̵��� ȸ�� ���� ����
                    key.GetComponent<Transform>().localScale = new Vector3(20f, 20f, 20f);

                    Stage1Gamemanager.doesPlayerhavekey = true;
                }
            }
        }
    }

    IEnumerator Poster_Saying1()
    {
        noticeUI.SetActive(true);
        noticeUI.GetComponentInChildren<Text>().text = "��¼�� ���� �̷� ����..";

        yield return new WaitForSeconds(2f);
        noticeUI.SetActive(false);
    }

    IEnumerator Poster_Saying2()
    {
        noticeUI.SetActive(true);
        noticeUI.GetComponentInChildren<Text>().text = "ť��� 3x3 �����ΰǰ�?";

        yield return new WaitForSeconds(2f);
        noticeUI.SetActive(false);
    }

    IEnumerator noKey()
    {
        noticeUI.SetActive(true);
        noticeUI.GetComponentInChildren<Text>().text = "���谡 �ʿ���...";
        
        yield return new WaitForSeconds(2f);
        noticeUI.SetActive(false);
    }

    IEnumerator recall_dialogue1()
    {
        noticeUI.SetActive(true);
        noticeUI.GetComponentInChildren<Text>().text = "�������� �繰�� �ٹ������ �ֽ��϶�� �ߴ� �� ����.";

        yield return new WaitForSeconds(2f);
        noticeUI.SetActive(false);

        recallFlag = 1;
    }

    IEnumerator recall_dialogue2()
    {
        noticeUI.SetActive(true);
        noticeUI.GetComponentInChildren<Text>().text = "ū ���� ���� ���� ���� ������� �ߴ���?";

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



