using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour
{
    public GameObject paperUI;

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) //우클릭시 자물쇠 끄기
        {
            ClosePaperUI();
        }
    }

    public void ClosePaperUI()
    {
        InteractionController1.isReadingPaper = false; //crosshair 다시 띄우기

        GameObject.Find("Player(2)").GetComponent<MovePlayer>().enabled = true; //플레이어 움직임 활성화
        GameObject.Find("MainCamera(2)").GetComponent<MoveCamera>().enabled = true; //카메라 움직임 활성화
        Cursor.lockState = CursorLockMode.Locked; //커서 락 활성화

        paperUI.SetActive(false); //쪽지 UI 끄기
    }
}
