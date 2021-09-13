using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodeLock : MonoBehaviour
{
    [SerializeField]
    Text codeText;
    string codeTextValue = "";

    public GameObject codeLockUI;

    // Update is called once per frame
    void Update()
    {
        codeText.text = codeTextValue;

        if (codeTextValue == "27")//��й�ȣ�� ���� ���� ����
        {
            InteractionController1.isUsingCodeLock = false; //crosshair �ٽ� ����

            Stage1Gamemanager.does2ndSolved = 0;

            codeLockUI.SetActive(false); //�ڹ��� UI ����
        }

        if (codeTextValue.Length >= 2)//�Է��� 2���ڰ� �Ѿ��
        {
            codeTextValue = "";
        }

        if (Input.GetMouseButtonDown(1)) //��Ŭ���� �ڹ��� ����
        {
            CloseCodeLockUI();
        }
    }

    public void AddDigit(string digit) //��ư�� ������ �Լ�
    {
        codeTextValue += digit;
    }

    public void CloseCodeLockUI()
    {
        InteractionController1.isUsingCodeLock = false; //crosshair �ٽ� ����

        GameObject.Find("Player(2)").GetComponent<MovePlayer>().enabled = true; //�÷��̾� ������ Ȱ��ȭ
        GameObject.Find("MainCamera(2)").GetComponent<MoveCamera>().enabled = true; //ī�޶� ������ Ȱ��ȭ
        Cursor.lockState = CursorLockMode.Locked; //Ŀ�� �� Ȱ��ȭ

        codeLockUI.SetActive(false); //�ڹ��� UI ����

        codeTextValue = "";
    }
}
