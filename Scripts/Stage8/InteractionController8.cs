using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class InteractionController8 : MonoBehaviour
{
    private SceneManagement sm8;
    private bool e2Flag = true; //��� �� �� �� ȿ���� ��� ���� �÷���
    private bool stageEnd = false; //��� �� �� �� ���̵� �ƿ� ������ true
    private bool stageEnd2 = false; //��� �� �� �� �� �������� ���ͷ��� UI ����

    RaycastHit hitInfo;
    [SerializeField] int sizeofLazer = 40; //lazer�� ũ��

    public static bool isWatchingMemory1 = false;
    public static bool isWatchingMemory2 = false;
    public static bool isWatchingMemory3 = false;

    public static bool dialog1 = false; //ù��° ��� �� �� ����
    public static bool dialog2 = false; //�ι�° ��� �� �� ����
    public static bool dialog3 = false; //����° ��� �� �� ����

    public GameObject[] interactionUI; //ũ�ν����, ��ȣ�ۿ� �ȳ� �ؽ�Ʈ
    public GameObject noticeUI; //�÷��̾� ���� �г�
    public Camera cam; //�÷��̾� �ڽ� ī�޶�(���� ī�޶�)
    public GameObject player;
    public GameObject fadeOutPanel; //�������� ���� �� ���̵� �ƿ�

    public GameObject firstMemory;  //ù��° ��� �̹��� 
    public GameObject secondMemory; //�ι�° ��� �̹���
    public GameObject thirdMemory;  //����° ��� �̹���

    public Text explainTxt; //���, ���ʾ� ���� ���ھ� ����� ��� ��� �ؽ�Ʈ

    void Start()
    {
        sm8 = new SceneManagement();
        explainTxt.text = "";
    }

    void Update()
    {
        CheckObject();

        if (Stage8Gamemanager.watchedFirst && Stage8Gamemanager.watchedSecond && Stage8Gamemanager.watchedThird && e2Flag)
        {
            Stage8Gamemanager.e2 = true;
            e2Flag = false;
        }

        if (dialog1)
        {
            StartCoroutine("notice", "� ������ �ƹ����� �д븦 ���� �ǰ�...?"); //��� �� �� �÷��̾� ����
            dialog1 = false;
        }
        else if (dialog2)
        {
            StartCoroutine("notice", "ģ���鿡�Ե� �������� ���߳�..."); //��� �� �� �÷��̾� ����
            dialog2 = false;
        }
        else if (dialog3)
        {
            StartCoroutine("notice", "�׷� �ƹ��������� �Ҿ���� �ǰ�..."); //��� �� �� �÷��̾� ����
            dialog3 = false;
        }

        if (stageEnd)
        {
            SceneManagement.completedStage = 8;
            sm8.movetoNextStage();
        }
    }

    void CheckObject()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        //Debug.DrawRay(ray.origin, ray.direction * sizeofLazer, Color.red);

        if ((Physics.Raycast(ray, out hitInfo, sizeofLazer) && (hitInfo.transform.CompareTag("interaction") || hitInfo.transform.CompareTag("interaction"))) && !isWatchingMemory1 && !isWatchingMemory2 && !isWatchingMemory3 && !stageEnd2)
        {
            //�ֻ��� �θ� interaction �±� �޾Ƶ� �νĵǵ���.
            Contact();
            //Debug.Log(hitInfo.transform.root.name);
        }

        else
        {
            notContact();
        }
    }

    void Contact()
    {
        showEvent(); // �������� ���� ��ü�� ������ ���� �� �� �ִ� ������ ���� UI �� ������
    }

    void notContact()
    {
        if (!isWatchingMemory1 && !isWatchingMemory2 && !isWatchingMemory3 && !stageEnd2) //����� �����ϴ� ���� �ƴ϶�� 
        {
            for (int i = 0; i < interactionUI.Length; i++)
            {
                interactionUI[i].SetActive(true); //��� interaction UI Ȱ��ȭ (crosshair, ���� �ؽ�Ʈ)
            }
            interactionUI[1].GetComponent<Text>().text = ""; //���ͷ��� ���� �ؽ�Ʈ �ʱ�ȭ
        }
        else //����� �����ϴ� ���̸�
        {
            for (int i = 0; i < interactionUI.Length; i++)
            {
                interactionUI[i].SetActive(false); //��� interaction UI ��Ȱ��ȭ (crosshair, ���� �ؽ�Ʈ)
            }
        }
    }

    void showEvent()
    {
        if (hitInfo.transform.root.name == "Bat") // ray�� ���� ����� �̸��� "Bat" (���� ������Ʈ �̸�) ���
        {
            interactionUI[1].GetComponent<Text>().text = "������ ���� ��� Ȯ���ϱ�";

            //�� ���¿��� ���콺 ���ʹ�ư�� Ŭ���ϸ�
            if (Input.GetMouseButtonDown(0)) //0�� ���콺 ����. 1�� ���콺 ������
            {
                isWatchingMemory1 = true; //ũ�ν���� �� ���� �ؽ�Ʈ ��Ȱ��ȭ
                Stage8Gamemanager.e1 = true; //ȿ���� ��� �÷��� 

                firstMemory.SetActive(true);

                player.GetComponent<MovePlayer>().enabled = false; //ȭ�� ������ ����
                player.GetComponentInChildren<MoveCamera>().enabled = false; //ī�޶� ������ ����
                Cursor.lockState = CursorLockMode.None; //Ŀ���� ����

                StartCoroutine("FadeIn", firstMemory.GetComponent<Image>()); //ù��° ��� ���� - �̹��� ����(���̵� ��)
            }
        }

        else if (hitInfo.transform.root.name == "Locker")
        {
            interactionUI[1].GetComponent<Text>().text = "�繰�� ���� ��� Ȯ���ϱ�";

            //�� ���¿��� ���콺 ���ʹ�ư�� Ŭ���ϸ�
            if (Input.GetMouseButtonDown(0))
            {
                isWatchingMemory2 = true; //ũ�ν���� �� ���� �ؽ�Ʈ ��Ȱ��ȭ
                Stage8Gamemanager.e1 = true; //ȿ���� ��� �÷��� 

                secondMemory.SetActive(true);

                player.GetComponent<MovePlayer>().enabled = false; //ȭ�� ������ ����
                player.GetComponentInChildren<MoveCamera>().enabled = false; //ī�޶� ������ ����
                Cursor.lockState = CursorLockMode.None; //Ŀ���� ����

                StartCoroutine("FadeIn", secondMemory.GetComponent<Image>()); //�ι�° ��� ���� - �̹��� ����(���̵� ��)
            }
        }

        else if (hitInfo.transform.root.name == "Frame")
        {
            interactionUI[1].GetComponent<Text>().text = "���� ���� ��� Ȯ���ϱ�";

            //�� ���¿��� ���콺 ���ʹ�ư�� Ŭ���ϸ�
            if (Input.GetMouseButtonDown(0))
            {
                isWatchingMemory3 = true; //ũ�ν���� �� ���� �ؽ�Ʈ ��Ȱ��ȭ
                Stage8Gamemanager.e1 = true; //ȿ���� ��� �÷��� 

                thirdMemory.SetActive(true);

                player.GetComponent<MovePlayer>().enabled = false; //ȭ�� ������ ����
                player.GetComponentInChildren<MoveCamera>().enabled = false; //ī�޶� ������ ����
                Cursor.lockState = CursorLockMode.None; //Ŀ���� ����

                StartCoroutine("FadeIn", thirdMemory.GetComponent<Image>()); //����° ��� ���� - �̹��� ����(���̵� ��)
            }
        }

        else if (hitInfo.transform.root.name == "Mask")
        {
            interactionUI[1].GetComponent<Text>().text = "���ʾ�";

            //�� ���¿��� ���콺 ���ʹ�ư�� Ŭ���ϸ�
            if (Input.GetMouseButtonDown(0))
            {
                interactionUI[1].GetComponent<Text>().text = "";

                //�ڷ�ƾ �Լ��̸������� , ��� �������� ����.
                StartCoroutine("explain", "���ʾ�: �������� �ھ��� �Ϻκ����� ������ ���� ��� �����̰�\n��� �߽����� ������ ���� �ھ� ���"); //���ʾ� ���� �ؽ�Ʈ ����
            }
        }

        else if (hitInfo.transform.root.name == "Libido")
        {
            interactionUI[1].GetComponent<Text>().text = "����";

            //�� ���¿��� ���콺 ���ʹ�ư�� Ŭ���ϸ�
            if (Input.GetMouseButtonDown(0))
            {
                interactionUI[1].GetComponent<Text>().text = "";
                StartCoroutine("explain", "����: ����� ���������� ���� �ִ� ���� �Ǵ� ���� �浿"); //���� ���� �ؽ�Ʈ ����
            }
        }

        else if (hitInfo.transform.root.name == "Scale")
        {
            interactionUI[1].GetComponent<Text>().text = "���ھ�";

            //�� ���¿��� ���콺 ���ʹ�ư�� Ŭ���ϸ�
            if (Input.GetMouseButtonDown(0))
            {
                interactionUI[1].GetComponent<Text>().text = "";
                StartCoroutine("explain", "���ھ�: �������� ���� ���� �̻����� �߱��ϴ� ���� ����"); //���ھ� ���� �ؽ�Ʈ ����
            }
        }

        else if (hitInfo.transform.root.name == "Brain")
        {
            interactionUI[1].GetComponent<Text>().text = "��";

            //�� ���¿��� ���콺 ���ʹ�ư�� Ŭ���ϸ�
            if (Input.GetMouseButtonDown(0))
            {
                interactionUI[1].GetComponent<Text>().text = "";
                StartCoroutine("explain", "\"�츮�� �ǽ��� �׻� � ������ ���� ���踦 �ΰ� �ֱ� ������\n��� ���� �ǽ��� �Ű��� ���� �ʰ��� ������� �ٷ� �� ����.\"\n- ���幮Ʈ �ļ� -");//��� 1 ����
            }
        }

        else if (hitInfo.transform.root.name == "Heart")
        {
            interactionUI[1].GetComponent<Text>().text = "����";

            //�� ���¿��� ���콺 ���ʹ�ư�� Ŭ���ϸ�
            if (Input.GetMouseButtonDown(0))
            {
                interactionUI[1].GetComponent<Text>().text = "";
                StartCoroutine("explain", "\"���ǽ��� �ǽ�ȭ���� �ʴ´ٸ� ���ǽ��� ���� ������ �����ϰ� �ȴ�.\n�츮�� �׷� ���� �ΰ�, �ٷ� '���'�̶�� �θ���.\"- Į �� -");//��� 2 ����
            }
        }

        else if (hitInfo.transform.root.name == "TrueDoor" || hitInfo.transform.root.name == "FalseDoor") //root�� �ֻ��� �θ� ��ȯ.
        {
            interactionUI[1].GetComponent<Text>().text = "�� ����";

            //�� ���¿��� ���콺 ���ʹ�ư�� Ŭ���ϸ�
            if (Input.GetMouseButtonDown(0))
            {
                interactionUI[1].GetComponent<Text>().text = "";//�̺�Ʈ ��Ÿ���� UI ���� �����.

                if (Stage8Gamemanager.watchedFirst && Stage8Gamemanager.watchedSecond && Stage8Gamemanager.watchedThird) //��� ����� �� ������ ���
                {
                    stageEnd2 = true;
                    fadeOutPanel.SetActive(true);
                    StartCoroutine("StageEndFadeOut");
                }
                else StartCoroutine("notice", "���� ������ �ʾ�..."); //���� ������ �ʾ� ���� ����
            }
        }
    }

    IEnumerator notice(string txt) //�÷��̾� ����(�ϴ� ���)
    {
        noticeUI.SetActive(true);
        noticeUI.GetComponentInChildren<Text>().text = txt;

        yield return new WaitForSeconds(3f);
        noticeUI.SetActive(false);
    }

    IEnumerator explain(string txt) //���� �� ���(��� ���)
    {
        explainTxt.text = txt;

        yield return new WaitForSeconds(3f);
        explainTxt.text = "";

    }

    IEnumerator FadeIn(Image fadeImage)
    {
        float fadeCount = 0; //ó�� ���İ� 0
        WaitForSeconds ws = new WaitForSeconds(0.05f);

        while (fadeCount <= 1.0f) //���� �ִ� 1.0���� �ݺ�
        {
            fadeCount += 0.05f;
            yield return ws; //0.05�ʸ��� ����
            fadeImage.color = new Color(1, 1, 1, fadeCount);
        }
    }

    IEnumerator StageEndFadeOut()
    {
        yield return new WaitForSeconds(3f);
        stageEnd = true;
    }
}
