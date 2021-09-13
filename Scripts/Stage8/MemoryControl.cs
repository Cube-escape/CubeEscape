using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryControl : MonoBehaviour
{
    public GameObject player;
    public GameObject cam;

    public GameObject firstMemory;  //ù��° ��� �̹��� 
    public GameObject secondMemory; //�ι�° ��� �̹���
    public GameObject thirdMemory;  //����° ��� �̹���
    public GameObject noticeUI; //�÷��̾� ���� �г�

    public bool fadeOutFinished = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) //��Ŭ���� ��� ����
        {
            if (InteractionController8.isWatchingMemory1) //ù��° ����� �� ���
            {
                CloseMemory(firstMemory);
            }
            else if (InteractionController8.isWatchingMemory2) //�ι�° ����� �� ���
            {
                CloseMemory(secondMemory);
            }
            else if (InteractionController8.isWatchingMemory3) //����° ����� �� ���
            {
                CloseMemory(thirdMemory);
            }
        }

        if (fadeOutFinished)
        {
            player.GetComponent<MovePlayer>().enabled = true; //�÷��̾� ������ Ȱ��ȭ
            cam.GetComponent<MoveCamera>().enabled = true; //ī�޶� ������ Ȱ��ȭ
            Cursor.lockState = CursorLockMode.Locked; //Ŀ�� �� Ȱ��ȭ

            if (InteractionController8.isWatchingMemory1)
            {
                firstMemory.SetActive(false); //��� UI ����
                Stage8Gamemanager.watchedFirst = true; //�÷��� ��ȯ
                InteractionController8.isWatchingMemory1 = false; //crosshair �ٽ� ����
                InteractionController8.dialog1 = true; //��� �� �� ���� ���
            }
            else if (InteractionController8.isWatchingMemory2)
            {
                secondMemory.SetActive(false); //��� UI ����
                Stage8Gamemanager.watchedSecond = true; //�÷��� ��ȯ
                InteractionController8.isWatchingMemory2 = false; //crosshair �ٽ� ����
                InteractionController8.dialog2 = true; //��� �� �� ���� ���

            }
            else if (InteractionController8.isWatchingMemory3)
            {
                thirdMemory.SetActive(false); //��� UI ����
                Stage8Gamemanager.watchedThird = true; //�÷��� ��ȯ
                InteractionController8.isWatchingMemory3 = false; //crosshair �ٽ� ����
                InteractionController8.dialog3 = true; //��� �� �� ���� ���
            }

            fadeOutFinished = false;
        }
    }

    void CloseMemory(GameObject fadeImage)
    {
        StartCoroutine("FadeOut", fadeImage.GetComponent<Image>()); //���̵� �ƿ�
    }

    IEnumerator FadeOut(Image fadeImage)
    {
        float fadeCount = 1; //ó�� ���İ� 1
        WaitForSeconds ws = new WaitForSeconds(0.05f);

        while (fadeCount >= 0f) //���� �ּڰ� 0���� �ݺ�
        {
            fadeCount -= 0.05f;
            yield return ws; //0.05�ʸ��� ����
            fadeImage.color = new Color(1, 1, 1, fadeCount);
        }

        if(fadeCount <= 0)
        {
            fadeOutFinished = true; //�÷��̾�, ī�޶� ������, Ŀ���� Ȱ��ȭ �� �̹��� UI ����, ũ�ν���� ���� �÷��� ��ȯ 
        }
    }
    
}
