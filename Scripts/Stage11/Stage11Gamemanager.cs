using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage11Gamemanager : MonoBehaviour
{
    public GameObject interactionUI;
    public GameObject stageIntroUI;
    public GameObject fadeInOutPanel;

    public GameObject player;
    public GameObject stageIntroCamera;

    public AudioSource asBGM; //������� ����
    public AudioClip stage8bgm; //���� �������

    public AudioSource asEffect;  //ȿ���� ����
    public AudioClip boxOpen; //���� ���� ȿ����
    public AudioClip doorOpen; //�� ���� ȿ����

    public static bool isBoxOpen = false;
    public static bool isDoorOpen = false;
    public bool a = false;
    private bool startFlag = true;
    private bool doesIntroEnd = false;

    void Start()
    {
        interactionUI.SetActive(false);
        fadeInOutPanel.SetActive(true);
        player.SetActive(false);

        stageIntroCamera.SetActive(true);
        stageIntroUI.SetActive(true);

        asBGM.loop = true;
        asBGM.playOnAwake = true;
        asBGM.clip = stage8bgm;
        asBGM.Play();

        player.GetComponent<MovePlayer>().enabled = false;
    }

    void Update()
    {
        if (startFlag == true)
        {
            StartCoroutine("Stage11Intro");
            startFlag = false;
        }

        if (doesIntroEnd == true)
        {
            player.GetComponent<MovePlayer>().enabled = true;
            fadeInOutPanel.SetActive(false); //���̵� ��, �ƿ��� �г� off
            interactionUI.SetActive(true); //���ͷ��� UI Ȱ��ȭ
            doesIntroEnd = false; //�÷��� �ʱ�ȭ
        }

        if (isBoxOpen)
        {
            asEffect.PlayOneShot(boxOpen); //���� ������ ȿ���� ���
            isBoxOpen = false;
            a = true;
        }

        if (isDoorOpen)
        {
            asEffect.PlayOneShot(doorOpen); //�� ������ ȿ���� ���
            isDoorOpen = false;
        }
    }

    IEnumerator Stage11Intro() //11��
    {
        yield return new WaitForSeconds(7f); //5�ʵ��� ���̵� �� - �������� ��Ʈ�� ��� - ���̵� �ƿ� - 2�ʵ��� ī�޶� ����, �������� �Ұ� UI ����
        stageIntroUI.SetActive(false);
        stageIntroCamera.SetActive(false);
        player.SetActive(true);

        yield return new WaitForSeconds(4f); //���̵� ��
        doesIntroEnd = true;
    }
}
