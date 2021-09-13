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
    [SerializeField] int sizeofLazer = 40; //lazer�� ũ��

    public GameObject[] interactionUI; //ũ�ν����, ��ȣ�ۿ� �ȳ� �ؽ�Ʈ
    public GameObject noticeUI; //�÷��̾� ���� �г�
    public GameObject fadeOutPanel; //�̷� Ż�� �� fade out

    public Camera cam; //�÷��̾� �ڽ� ī�޶�(���� ī�޶�)
    public Transform arm; //player2�� ��
    public GameObject key;

    private bool stageEnd = false; //�̷� Ż�� �� �� ������ �� ���̵� �ƿ� ���� true
    private bool openDoor = false; //�� ���� ���ͷ��� UI ���� ���� �÷���
    private bool doesPlayerHaveKey = false;

    void Start()
    {
        sm11 = new SceneManagement();
    }

    void Update()
    {
        CheckObject();

        if (arm.transform.childCount == 1 && Input.GetMouseButtonDown(1)) //���踦 �� ä�� ��Ŭ�� ��
        {
            arm.transform.GetComponentInChildren<Rigidbody>().useGravity = true; //�߷� ���� - ���� ����������
            arm.transform.GetComponentInChildren<Rigidbody>().isKinematic = false;
            arm.GetChild(0).parent = null;

            doesPlayerHaveKey = false;
        }

        if (stageEnd) //���� ���������� ��ȯ
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
        showEvent(); // �������� ���� ��ü�� ������ ���� �� �� �ִ� ������ ���� UI �� ������
    }

    void notContact()
    {
        if (!openDoor) 
        {
            for (int i = 0; i < interactionUI.Length; i++)
            {
                interactionUI[i].SetActive(true); //��� interaction UI Ȱ��ȭ (crosshair, ���� �ؽ�Ʈ)
            }
            interactionUI[1].GetComponent<Text>().text = ""; //���ͷ��� ���� �ؽ�Ʈ �ʱ�ȭ
        }
        else //���� �� ��
        {
            for (int i = 0; i < interactionUI.Length; i++)
            {
                interactionUI[i].SetActive(false); //crosshair�� ������ ��� interaction UI�� ��Ȱ��ȭ ��Ų��.
            }
        }
    }

    void showEvent()
    {
        if (hitInfo.transform.name == "Door(2)") //ray�� Door�� �浹�� ���
        {
            interactionUI[1].GetComponent<Text>().text = "�� ����";

            if (Input.GetMouseButtonDown(0)) //0�� ���콺 ����. 1�� ���콺 ������
            {
                if (doesPlayerHaveKey) //���踦 ��� �ִ� ���
                {
                    interactionUI[1].GetComponent<Text>().text = "";//�̺�Ʈ ��Ÿ���� UI ���� �����.
                    openDoor = true;
                    Stage11Gamemanager.isDoorOpen = true;
                    fadeOutPanel.SetActive(true); //fade out panel �ѱ�
                    StartCoroutine("StageEndFadeOut");
                }
                else StartCoroutine("notice", "���谡 �ʿ���..."); //���� ������ �ʾ� ���� ����
            }
        }
        else if (hitInfo.transform.name == "Chest") //��������
        {
            interactionUI[1].GetComponent<Text>().text = "���� ����";

            if (Input.GetMouseButtonDown(0)) //0�� ���콺 ����. 1�� ���콺 ������
            {
                interactionUI[1].GetComponent<Text>().text = "";
                Stage11Gamemanager.isBoxOpen = true;

                //���� ȹ�� - arm�� ��� ��
                if (arm.transform.childCount == 0)
                {
                    key.GetComponent<Rigidbody>().useGravity = false; // gravity�� ����.
                    key.GetComponent<Rigidbody>().isKinematic = true; // kinematic�� �Ѹ� ��ũ��Ʈ�� ���ؼ��� �����δ�. ������ �տ� ������ �� ���� ���׿� ���� ���ۺ��� ���� �ʵ��� �ϱ� ���� �ʿ��ϴ�. 
                    key.transform.position = arm.transform.position; // �ȷ� �����ص� ��ġ�� �̵���Ų��.
                    key.transform.parent = arm.transform; // ���� child�� �־��ش�.

                    key.GetComponent<Transform>().localRotation = Quaternion.Euler(90f, 0f, 0f); // �ո��� ���̵��� ȸ�� ���� ����
                    key.GetComponent<Transform>().localScale = new Vector3(2f, 2f, 7f);

                    doesPlayerHaveKey = true;
                }
            }
        }

        else if (hitInfo.transform.name == "Key" && !doesPlayerHaveKey) //���踦 �ٴڿ� ����߸� �� �ٽ� �ݴ� ��� 
        {
            interactionUI[1].GetComponent<Text>().text = "���� �ݱ�";

            if (Input.GetMouseButtonDown(0)) //���콺 ���� Ŭ����
            {
                interactionUI[1].GetComponent<Text>().text = ""; //���� �ݱ� ����

                //���� ȹ�� - arm�� ��� ��
                if (arm.transform.childCount == 0)
                {
                    key.GetComponent<Rigidbody>().useGravity = false; // gravity�� ����.
                    key.GetComponent<Rigidbody>().isKinematic = true; // kinematic�� �Ѹ� ��ũ��Ʈ�� ���ؼ��� �����δ�. ������ �տ� ������ �� ���� ���׿� ���� ���ۺ��� ���� �ʵ��� �ϱ� ���� �ʿ��ϴ�. 
                    key.transform.position = arm.transform.position; // �ȷ� �����ص� ��ġ�� �̵���Ų��.
                    key.transform.parent = arm.transform; // ���� child�� �־��ش�.

                    key.GetComponent<Transform>().localRotation = Quaternion.Euler(90f, 0f, 0f); // �ո��� ���̵��� ȸ�� ���� ����
                    key.GetComponent<Transform>().localScale = new Vector3(2f, 2f, 7f);

                    doesPlayerHaveKey = true;
                }
            }
        }
    }

    IEnumerator notice(string txt) //�÷��̾� ����(�ϴ� ���)
    {
        noticeUI.SetActive(true);
        noticeUI.GetComponentInChildren<Text>().text = txt;

        yield return new WaitForSeconds(3f);
        noticeUI.SetActive(false);
    }

    IEnumerator StageEndFadeOut() //�������� ��ȯ �� ���̵� �ƿ�
    {
        yield return new WaitForSeconds(3f);
        stageEnd = true;
    }
}
