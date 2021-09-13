using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage8Gamemanager : MonoBehaviour
{
    public static bool watchedFirst = false;  //ù��° ����� �����ߴ°�
    public static bool watchedSecond = false; //�ι�° ����� �����ߴ°�
    public static bool watchedThird = false;  //����° ����� �����ߴ°�
    public static bool e1 = false; //��� �� �� ȿ���� ����� ����
    public static bool e2 = false; //��� �� �� �� ȿ���� ����� ����

    private bool doesIntroEnd = false;
    private int startFlag = 0;

    public ParticleSystem ps;

    public GameObject interactionUI;
    public GameObject stageIntroUI;
    public GameObject fadeInOutPanel;

    public GameObject player;
    public GameObject stageIntroCamera;
    public GameObject falseDoor; //����� �� �� �� ����� ����

    public AudioSource asBGM; //������� ����
    public AudioClip stage8bgm; //���� �������   

    public AudioSource asEffect;  //ȿ���� ����
    public AudioClip watchMemory; //����� �� �� ȿ����
    public AudioClip watchedEveryMemory; //����� �� ���� �� ȿ����

    void Start()
    {
        ps.Play(); //��ƼŬ �ý��� ���

        asBGM.loop = true;
        asBGM.playOnAwake = true;
        asBGM.clip = stage8bgm;
        asBGM.Play();

        asEffect.loop = false;
        asEffect.playOnAwake = true;

        interactionUI.SetActive(false);
        fadeInOutPanel.SetActive(true);
        player.SetActive(false);

        stageIntroCamera.SetActive(true);
        stageIntroUI.SetActive(true);

        player.GetComponent<MovePlayer>().enabled = false;
    }

    void Update()
    {
        if (startFlag == 0)
        {
            StartCoroutine("Stage8Intro");
            startFlag = 1;
        }

        if (doesIntroEnd == true)
        {
            player.GetComponent<MovePlayer>().enabled = true;
            fadeInOutPanel.SetActive(false); //���̵� ��, �ƿ��� �г� off
            interactionUI.SetActive(true); //���ͷ��� UI Ȱ��ȭ
            doesIntroEnd = false; //�÷��� �ʱ�ȭ
        }

        if ((InteractionController8.isWatchingMemory1 || InteractionController8.isWatchingMemory2 || InteractionController8.isWatchingMemory3) && e1) //����� �����ϴ� ���̸�
        {
            asEffect.PlayOneShot(watchMemory); //��� ���� ȿ���� ��� 
            e1 = false; //�÷��� �ʱ�ȭ
        }

        if (watchedFirst && watchedSecond && watchedThird) //��� ����� �� �ôٸ�
        {
            if(e2 == true)
            {
                asEffect.PlayOneShot(watchedEveryMemory); //��� �� �� ȿ���� ���
                e2 = false;
            }

            falseDoor.SetActive(false);  //�� �ϳ� ����� ������ �����
        }
    }

    IEnumerator Stage8Intro() //11��
    {
        yield return new WaitForSeconds(7f); //5�ʵ��� ���̵� �� - �������� ��Ʈ�� ��� - ���̵� �ƿ� - 2�ʵ��� ī�޶� ����, �������� �Ұ� UI ����
        stageIntroUI.SetActive(false);
        stageIntroCamera.SetActive(false);
        player.SetActive(true);

        yield return new WaitForSeconds(4f); //���̵� ��
        doesIntroEnd = true;
    }


}
