using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodePanel : MonoBehaviour
{
    [SerializeField]
    Text codeText;
    string codeTextValue = "";

    public GameObject keyPadUI;

    // Update is called once per frame
    void Update()
    {
        codeText.text = codeTextValue;

        if (codeTextValue == "8621")//��й�ȣ�� ���� ���� ����
        {
            InteractionController1.isUsingKeyPad = false; //crosshair �ٽ� ����
            Stage1Gamemanager.does1stSolved = 0; //ù��° ���� �ذ� �÷��� ��ȯ

            keyPadUI.SetActive(false); //Ű�е� UI ����
        }

        if (codeTextValue.Length >= 4)//�Է��� 4���ڰ� �Ѿ��
        {
            codeTextValue = "";
        }

        if (Input.GetMouseButtonDown(1)) //��Ŭ���� Ű�е� ����
        {
            CloseKeypadUI();
        }
    }

    public void AddDigit(string digit) //��ư�� ������ �Լ�
    {
        codeTextValue += digit;
    }

    public void CloseKeypadUI()
    {
        InteractionController1.isUsingKeyPad = false; //crosshair �ٽ� ����

        GameObject.Find("Player(2)").GetComponent<MovePlayer>().enabled = true; //�÷��̾� ������ Ȱ��ȭ
        GameObject.Find("MainCamera(2)").GetComponent<MoveCamera>().enabled = true; //ī�޶� ������ Ȱ��ȭ
        Cursor.lockState = CursorLockMode.Locked; //Ŀ�� �� Ȱ��ȭ

        keyPadUI.SetActive(false); //Ű�е� UI ����

        codeTextValue = "";
    }
}
