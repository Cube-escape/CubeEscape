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

        if (codeTextValue == "8621")//비밀번호에 따라 숫자 변경
        {
            InteractionController1.isUsingKeyPad = false; //crosshair 다시 띄우기
            Stage1Gamemanager.does1stSolved = 0; //첫번째 문제 해결 플래그 전환

            keyPadUI.SetActive(false); //키패드 UI 해제
        }

        if (codeTextValue.Length >= 4)//입력이 4글자가 넘어가면
        {
            codeTextValue = "";
        }

        if (Input.GetMouseButtonDown(1)) //우클릭시 키패드 끄기
        {
            CloseKeypadUI();
        }
    }

    public void AddDigit(string digit) //버튼에 연결할 함수
    {
        codeTextValue += digit;
    }

    public void CloseKeypadUI()
    {
        InteractionController1.isUsingKeyPad = false; //crosshair 다시 띄우기

        GameObject.Find("Player(2)").GetComponent<MovePlayer>().enabled = true; //플레이어 움직임 활성화
        GameObject.Find("MainCamera(2)").GetComponent<MoveCamera>().enabled = true; //카메라 움직임 활성화
        Cursor.lockState = CursorLockMode.Locked; //커서 락 활성화

        keyPadUI.SetActive(false); //키패드 UI 끄기

        codeTextValue = "";
    }
}
