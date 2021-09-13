using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class Stage1Gamemanager : MonoBehaviour
{
    public static bool doesPlayerhavekey = false;
    public static int does1stSolved = -1; //ù��° ����(ť�� ����) �ذ� ���� - CodePanel�� ���� / -1�̸� 1�� ���� �ذ� x 0�̸� �ذ��� ��ȭ ���� 1�̸� ��ȭ ���� ��
    public static int does2ndSolved = -1; //�ι�° ����(ť�� ����) �ذ� ���� - CodeLock�� ����
    public static bool doesDialog1End = false; //dialog manager�� ����
    public static bool doesDialog2End = false; //dialog manager�� ����

    private bool doesGlitchEnd = false;
    private bool doesIntroEnd1 = false;
    private bool doesIntroEnd2 = false;
    private bool doesDialog2Start1 = false;
    private bool doesDialog2Start2 = false;
    private bool doesDialog2End2 = false;
    private bool doesDialog2End3 = false;

    private int glitchFlag = 0;
    private int laughFlag = 0;
    private int paperDropFlag = 0;
    private int secondBgmFlag = 0;
    private int gameControlFlag = 0;
    private int unlockedFlag = 0;

    public GameObject movingWall;

    public GameObject blinkPanel;
    public GameObject interactionUI;
    public GameObject stageIntroUI; //�������� �Ұ� �ؽ�Ʈ
    public GameObject fadeInOutPanel; //��ũ��Ʈ 1 ���� �� ��� ��ȯ
    public GameObject fadeInOutPanel2; //�������� �Ұ� �ؽ�Ʈ ��� �� ��� ��ȯ
    public GameObject fadeInOutPanel3; //��ũ��Ʈ 2 ���� �� ��� ��ȯ
    public GameObject gameControlUI; //���۹� UI
    public GameObject introCursorUI; //�������� ��Ʈ�� ���� Ŀ���� none

    public GameObject player1; //�������� �ʹ� �÷��̾�
    public GameObject player2; //��ũ��Ʈ1 ��� �� �̿��� �÷��̾�
    public GameObject dialogTrigger;
    public GameObject dialogBtn; //��ȭâ UI
    public GameObject dialog1Camera; //�������� �ʹ� ī�޶�
    public GameObject stage1IntroCamera; //�������� �Ұ��� ī�޶�
    public GameObject dialog2Camera; //�ι�° ��ȭ ī�޶�
    public GameObject monitorOff; 
    public GameObject monitorOn;
    public GameObject paper;

    public GameObject cube1;
    public GameObject cube2;
    public GameObject cube6;
    public GameObject cube8;

    public GameObject speaker;
    public GameObject poster1;
    public GameObject poster2;
    public GameObject keypad;

    public AudioSource asBGM;
    public AudioSource asBGM2; 
    public AudioSource asEffect;
    public AudioClip firstBgm;  //~ť�� ���� bgm
    public AudioClip secondBgm; //�� ���� bgm
    public AudioClip glitch;    //������ �Ҹ�
    public AudioClip paperDrop; //���̹�ġ �������� �Ҹ�
    public AudioClip laughing;  //������c �����Ҹ�
    public AudioClip unlocked;  //�ڹ��� ���� ȿ����

    private float rotateTime = 7f; //ī�޶� ȸ�� �ð�

    private void Start()
    {
        interactionUI.SetActive(false);
        player2.SetActive(false);
        dialogBtn.SetActive(false);
        fadeInOutPanel.SetActive(false);
        fadeInOutPanel2.SetActive(false);
        stageIntroUI.SetActive(false);
        
        introCursorUI.SetActive(true);
        blinkPanel.SetActive(true);
        StartCoroutine("BlinkPanelOff"); //���� 8.5�� �Ŀ� blinkPanel ���� ù��° ��ũ��Ʈ �ڵ� ���

        asBGM.loop = true;
        asBGM.playOnAwake = true;
        asBGM.clip = firstBgm;
        asBGM.Play();

        asEffect.loop = false;
    }

    private void Update()
    {

        /*  if ( �÷��̾ Ű�� �������ִٸ�)

               doesPlayerhavekey = true;
           }

           */

        var system = FindObjectOfType<DialogManager>();
        if (system.sentenceNum == 1) //ù ��� ��� �� ī�޶� �θ��� �θ���
        {
            dialogBtn.SetActive(false); //��ȭ �г� off

            //ī�޶� �θ��� �θ���
            if (rotateTime >= 5.5f && rotateTime <= 7f) //���������� 1.5�ʵ��� ȸ��
            {
                dialog1Camera.transform.RotateAround(player1.transform.position, Vector3.up, 20f * Time.deltaTime);
                rotateTime -= Time.deltaTime;
            }
            else if (rotateTime >= 5f && rotateTime < 5.5f) //0.5�ʵ��� �� �ڸ� �״�� ����
            {
                rotateTime -= Time.deltaTime;
            }
            else if (rotateTime >= 2f && rotateTime < 5f) //�������� 3�ʵ��� ȸ��
            {
                dialog1Camera.transform.RotateAround(player1.transform.position, Vector3.up, -20f * Time.deltaTime);
                rotateTime -= Time.deltaTime;
            }
            else if (rotateTime >= 1.5f && rotateTime < 2f) //0.5�ʵ��� �� �ڸ� �״�� ����
            {
                rotateTime -= Time.deltaTime;
            }
            else if (rotateTime >= 0 && rotateTime < 1.5f) //���������� 1.5�ʵ��� ȸ��
            {
                dialog1Camera.transform.RotateAround(player1.transform.position, Vector3.up, 20f * Time.deltaTime);
                rotateTime -= Time.deltaTime;
            }
            else
            {
                //�θ����Ÿ� �� ��� ���
                dialogBtn.SetActive(true);
            }
        }
        else if (system.sentenceNum == 3) //�ι�° ��� ��� �� ������ �Ҹ� + ����ͷ� �ü� �̵�
        {
            dialogBtn.SetActive(false);
            if (glitchFlag == 0)
            {
                asEffect.PlayOneShot(glitch);
                glitchFlag = 1;
            }
            StartCoroutine("PlayGlitch"); //������ ȿ���� ��� ���� ī�޶� �̵�
            if (doesGlitchEnd == true)
            {
                dialogBtn.SetActive(true); //���� script 1-(3) ���
            }
        }
        else if (system.sentenceNum == 31)  //��ũ��Ʈ 1 ������ �̷������ ��ȭ ���� - �������� �Ұ� �ؽ�Ʈ + �Ұ� UI ���
        {
            if (doesDialog1End == true)
            {   
                if(laughFlag == 0)
                {
                    asEffect.PlayOneShot(laughing); //�����Ҹ�
                    laughFlag = 1;
                }
                dialogBtn.SetActive(false);
                StartCoroutine("StageIntro"); //���̵� �ƿ� - ����� ����/ī�޶� ���� - ���̵� �� - �������� �Ұ�
            }
            
            if(doesIntroEnd1 == true)
            {
                doesDialog1End = false;
                StartCoroutine("StageIntro2"); //�ٽ� ���̵� �ƿ� - �÷��̾� 2�� ���� - ���̵� ��
            }

            if (doesIntroEnd2 == true)
            {
                doesIntroEnd1 = false;
                fadeInOutPanel.SetActive(false);
                fadeInOutPanel2.SetActive(false);
                introCursorUI.SetActive(false);

                if (gameControlFlag == 0)
                {
                    gameControlUI.SetActive(true);

                    player2.GetComponent<MovePlayer>().enabled = false; //ȭ�� ������ ����
                    dialog2Camera.GetComponent<MoveCamera>().enabled = false; //ī�޶� ������ ����
                    Cursor.lockState = CursorLockMode.None; //Ŀ���� ����
                }
                
                if (Input.GetMouseButtonDown(1)) //��Ŭ���� â �ݱ�
                {
                    gameControlUI.SetActive(false);
                    gameControlFlag = 1;

                    interactionUI.SetActive(true);

                    player2.GetComponent<MovePlayer>().enabled = true; //ȭ�� ������ Ȱ��ȭ
                    dialog2Camera.GetComponent<MoveCamera>().enabled = true; //ī�޶� ������ Ȱ��ȭ
                    Cursor.lockState = CursorLockMode.Locked; //Ŀ���� ���
                }
            }

            if (does1stSolved == 0) //ù��° ������ �ذ�Ǿ�����
            {
                doesIntroEnd2 = false;

                paper.SetActive(true); //���̹�ġ ������
                if(paperDropFlag == 0)
                {
                    asEffect.PlayOneShot(paperDrop);
                    paperDropFlag = 1;
                }
                
                StartCoroutine("Dialog2Start");//Ŀ���� ���� �� ���ͷ���, �÷��̾�, ī�޶� ��ũ��Ʈ ���� - 2�� �״�� - �ü� ���ڷ� �̵� 
            }

            if (doesDialog2Start1 == true)
            {
                does1stSolved = 1; //�÷��� ����

                GameObject.Find("Stage1Manager").GetComponent<InteractionController1>().enabled = false; //���ͷ��� ��ũ��Ʈ ����
                interactionUI.SetActive(false);

                if (glitchFlag == 1)
                {
                    asEffect.PlayOneShot(glitch);
                    glitchFlag = 2;
                }

                StartCoroutine("Dialog2Start2"); //4�� ���(glitch) - ����� �ѱ�
            }

            if (doesDialog2Start2 == true)
            {
                doesDialog2Start1 = false;
                GameObject.Find("Stage1Manager").GetComponent<InteractionController1>().enabled = false; //���ͷ��� ��ũ��Ʈ ����
                interactionUI.SetActive(false);

                //�ü� ����ͷ� �̵�
                player2.transform.position = Vector3.Lerp(player2.transform.position, new Vector3(20f, 68f, 0), 0.1f);
                player2.transform.localEulerAngles = new Vector3(0, 90f, 0);

                dialogBtn.SetActive(true); //���� script 2 ���
            }
        }
        else if(system.sentenceNum == 48) //script 2 ������
        {
            if (doesDialog2End == true)
            {
                doesDialog2Start2 = false; //�� �ʿ��� ���� �ƴ�
                dialogBtn.SetActive(false);

                if (laughFlag == 1)
                {
                    asEffect.PlayOneShot(laughing); //�����Ҹ�
                    laughFlag = 2;
                }

                StartCoroutine("Dialog2End"); //���̵� �� + �÷��̾� ��ġ �̵� + ť��, �����, ����Ŀ, Ű�е� ���ֱ� + �÷��̾� ������ Ȱ��ȭ
            }
            
            if (doesDialog2End2 == true) //4�� �� ��� ����
            {
                doesDialog2End = false;

                
            }

            if (doesDialog2End3 == true) //2�� �� �÷��̾� Ȱ��ȭ
            {
                if (secondBgmFlag == 0)
                {
                    asBGM2.PlayOneShot(secondBgm); //����� ������� ����
                    secondBgmFlag = 1;
                }

                doesDialog2End2 = false;
                fadeInOutPanel3.SetActive(false);
                //�� �����̱�
                movingWall.transform.position = Vector3.MoveTowards(movingWall.transform.position, new Vector3(-50f, 50f, 0), Time.deltaTime * 1.5f); 

                //�÷��̾ ���ڰ� ���� �浹�ϸ� ���� ���� if()
            }

            if (does2ndSolved == 0) //�ι�° ������ �ذ�Ǿ�����
            {
                doesDialog2End3 = false;

                player2.GetComponent<MovePlayer>().enabled = true;
                dialog2Camera.GetComponent<MoveCamera>().enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
                
                if (unlockedFlag == 0)
                {
                    asEffect.PlayOneShot(unlocked); //�ڹ��� Ǯ���� ȿ����
                    unlockedFlag = 1;
                }

            }
        }
    }

    IEnumerator BlinkPanelOff()
    {
        yield return new WaitForSeconds(8.5f);
        blinkPanel.SetActive(false);
        dialogTrigger.SetActive(true);
        dialogTrigger.GetComponent<DialogTrigger>().Trigger(); //�ڵ����� ù ���� ����
        dialogBtn.SetActive(true);
        dialogTrigger.SetActive(false);
    }


    IEnumerator PlayGlitch() //4��
    {
        yield return new WaitForSeconds(4f);

        //ī�޶� ����ͷ� �̵�
        dialog1Camera.transform.position = Vector3.Lerp(dialog1Camera.transform.position, new Vector3(20, 73, 0), 0.1f);
        //���� ����ͷ� ��ȯ(monitor(off)�� false��)
        monitorOff.SetActive(false);
        doesGlitchEnd = true;
    }

    IEnumerator StageIntro() //10��
    {
        fadeInOutPanel.SetActive(true); 

        yield return new WaitForSeconds(3f); //���̵� �ƿ�

        stageIntroUI.SetActive(true); //�������� �Ұ� �ؽ�Ʈ ���
        
        //����� ����
        monitorOn.SetActive(false);   
        monitorOff.SetActive(true);
        
        //ī�޶� ����
        player1.SetActive(false);
        stage1IntroCamera.SetActive(true);
        
        yield return new WaitForSeconds(4f); //���̵� ��
        
        fadeInOutPanel.SetActive(false);
        
        yield return new WaitForSeconds(3f);   //�������� �Ұ� ȭ�� 3�� �� ���
        
        doesIntroEnd1 = true;
    }

    IEnumerator StageIntro2() //6��
    {
        fadeInOutPanel2.SetActive(true); //�������� �Ұ� �� �ٽ� ���̵� �ƿ�
        yield return new WaitForSeconds(2.5f);
        
        stageIntroUI.SetActive(false);
        stage1IntroCamera.SetActive(false);
        player2.SetActive(true);
        yield return new WaitForSeconds(3.5f); //���̵� ��
        
        doesIntroEnd2 = true;
    }

    IEnumerator Dialog2Start()  //5��
    {
        //(movePlayer, moveCamera ��ũ��Ʈ ��Ȱ��ȭ) �� Ŀ���� ����
        player2.GetComponent<MovePlayer>().enabled = false; //ȭ�� ������ ����
        dialog2Camera.GetComponent<MoveCamera>().enabled = false; //ī�޶� ������ ����
        Cursor.lockState = CursorLockMode.None; //Ŀ���� ����
        GameObject.Find("Stage1Manager").GetComponent<InteractionController1>().enabled = false; //���ͷ��� ��ũ��Ʈ ����
        interactionUI.SetActive(false); //���ͷ��� UI ����
        yield return new WaitForSeconds(2f); //2�� �״��

        //�ü� ���ڷ� �̵�
        player2.transform.position = Vector3.Lerp(player2.transform.position, new Vector3(-10f, 10f, 0), 0.1f);
        player2.transform.localEulerAngles = new Vector3(10, -90, 0);

        yield return new WaitForSeconds(3f);//3�� �״��

        doesDialog2Start1 = true;
    }

    IEnumerator Dialog2Start2() //4��
    {
        yield return new WaitForSeconds(4f);//4�� �״��

        //���� ����ͷ� ��ȯ
        monitorOn.SetActive(true);
        monitorOff.SetActive(false);

        doesDialog2Start2 = true;
    }

    IEnumerator Dialog2End() //8��
    {
        fadeInOutPanel3.SetActive(true); 
        yield return new WaitForSeconds(4f); //���̵� �ƿ� - ������Ʈ ���� �÷��̾� ����ġ�� �̵�

        //ť��, �����, ����Ŀ, Ű�е� ��Ȱ��ȭ
        //GameObject.Find("Cube1").SetActive(false);
        cube1.SetActive(false);
        cube2.SetActive(false);
        cube6.SetActive(false);
        cube8.SetActive(false);
        monitorOn.SetActive(false);
        speaker.SetActive(false);
        keypad.SetActive(false);

        //������ ��ü
        poster1.SetActive(false);
        poster2.SetActive(true);

        player2.transform.position = new Vector3(0f, 30f, 0); //�÷��̾� ����ġ�� �̵�

        //�ٽ� Ŀ����, moveplayer, movecamera Ȱ��ȭ
        player2.GetComponent<MovePlayer>().enabled = true;
        dialog2Camera.GetComponent<MoveCamera>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;

        asBGM.Stop(); //��� ���߱�

        doesDialog2End2 = true; //�� ��� ���

        yield return new WaitForSeconds(2f); //���̵� ��, �� �����̱�

        //interactionUI �� ��ũ��Ʈ Ȱ��ȭ
        interactionUI.SetActive(true);
        GameObject.Find("Stage1Manager").GetComponent<InteractionController1>().enabled = true;

        doesDialog2End3 = true; //�� �����̱�, ���̵� �ƿ� �г� ����
    }

}
