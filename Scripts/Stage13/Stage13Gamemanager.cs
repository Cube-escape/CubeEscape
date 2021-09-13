using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage13Gamemanager : MonoBehaviour
{

    public static bool isAllMarkClicked; //���繮�� �ذῩ��
    public static bool isLightingSystemSetRightly; //������ġ�� ������ �ǰ� �����Ͽ� �۵����״���
    public static bool isButterflyArrived; //���� ������ġ�۵����� ������ ������ ������ �̵��ߴ���.
   // public static bool pollen_of_light

    public GameObject rock;
    public GameObject butterfly;
    public GameObject letter;
    public GameObject portal;
    AudioSource portalEffect;

    public MeshRenderer ground;


    Animation rockanimaion;
     Animator butterflyanimator;
    

    [SerializeField] AudioSource audioEffect;
    AudioSource rockmove;

    public GameObject noticeUI;

    private SceneManagement sm13;

    bool b1;
    bool b2;


    // Start is called before the first frame update
    void Start()
    {
        portal.SetActive(false);
        butterfly.SetActive(false);
        isAllMarkClicked = false;
        isLightingSystemSetRightly = false;
        letter.SetActive(false);
        sm13 = new SceneManagement();
        b1 = true;
        b2 = true;
        butterflyanimator = butterfly.GetComponent<Animator>();
        
        rockmove=rock.GetComponent<AudioSource > ();
        rockanimaion = rock.GetComponent<Animation>();

        portalEffect = portal.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       

        if (isAllMarkClicked && b1)
        {
            Debug.Log("��� ������ ã�Ҵ�.");

            rockanimaion.Play("rock down");
          
            rockmove.Play(); //������ġ �۵� ȿ����

                butterfly.SetActive(true);
             //�������.
              butterflyanimator.Play("ButterflyMove");


            letter.SetActive(true);
                StartCoroutine("notice", "���� ���󰡺���.");


            letter.SetActive(true);

              b1 = false;
        }

       
       

        if (isLightingSystemSetRightly && b2)
        {
            ground.material.color = Color.white;
            //������� �� ��½ �� ������� �� ���� 
            // �������������� �̵��ϴ� ��Ż ����
            portal.SetActive(true);
            portalEffect.Play();

           b2 = false;
        }



    }


    IEnumerator notice(string txt) //�÷��̾� ����(�ϴ� ���)
    {
        noticeUI.SetActive(true);
        noticeUI.GetComponentInChildren<Text>().text = txt;

        yield return new WaitForSeconds(3f);
        noticeUI.SetActive(false);
    }
}


