using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour
{
    public GameObject paperUI;

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) //��Ŭ���� �ڹ��� ����
        {
            ClosePaperUI();
        }
    }

    public void ClosePaperUI()
    {
        InteractionController1.isReadingPaper = false; //crosshair �ٽ� ����

        GameObject.Find("Player(2)").GetComponent<MovePlayer>().enabled = true; //�÷��̾� ������ Ȱ��ȭ
        GameObject.Find("MainCamera(2)").GetComponent<MoveCamera>().enabled = true; //ī�޶� ������ Ȱ��ȭ
        Cursor.lockState = CursorLockMode.Locked; //Ŀ�� �� Ȱ��ȭ

        paperUI.SetActive(false); //���� UI ����
    }
}
