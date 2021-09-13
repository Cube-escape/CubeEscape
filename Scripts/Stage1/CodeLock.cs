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

        if (codeTextValue == "27")//비밀번호에 따라 숫자 변경
        {
            InteractionController1.isUsingCodeLock = false; //crosshair 다시 띄우기

            Stage1Gamemanager.does2ndSolved = 0;

            codeLockUI.SetActive(false); //자물쇠 UI 끄기
        }

        if (codeTextValue.Length >= 2)//입력이 2글자가 넘어가면
        {
            codeTextValue = "";
        }

        if (Input.GetMouseButtonDown(1)) //우클릭시 자물쇠 끄기
        {
            CloseCodeLockUI();
        }
    }

    public void AddDigit(string digit) //버튼에 연결할 함수
    {
        codeTextValue += digit;
    }

    public void CloseCodeLockUI()
    {
        InteractionController1.isUsingCodeLock = false; //crosshair 다시 띄우기

        GameObject.Find("Player(2)").GetComponent<MovePlayer>().enabled = true; //플레이어 움직임 활성화
        GameObject.Find("MainCamera(2)").GetComponent<MoveCamera>().enabled = true; //카메라 움직임 활성화
        Cursor.lockState = CursorLockMode.Locked; //커서 락 활성화

        codeLockUI.SetActive(false); //자물쇠 UI 끄기

        codeTextValue = "";
    }
}
