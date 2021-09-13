using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage13Gamemanager : MonoBehaviour
{

    public static bool isAllMarkClicked; //문양문제 해결여부
    public static bool isLightingSystemSetRightly; //조명장치의 각도를 옳게 제어하여 작동시켰는지
    public static bool isButterflyArrived; //나비가 빛의장치작동법이 적혀진 땅까지 무사히 이동했는지.
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
            Debug.Log("모든 문양을 찾았다.");

            rockanimaion.Play("rock down");
          
            rockmove.Play(); //바위장치 작동 효과음

                butterfly.SetActive(true);
             //나비등장.
              butterflyanimator.Play("ButterflyMove");


            letter.SetActive(true);
                StartCoroutine("notice", "나비를 따라가보자.");


            letter.SetActive(true);

              b1 = false;
        }

       
       

        if (isLightingSystemSetRightly && b2)
        {
            ground.material.color = Color.white;
            //가운데에서 빛 번쩍 후 사방으로 빛 퍼짐 
            // 다음스테이지로 이동하는 포탈 생성
            portal.SetActive(true);
            portalEffect.Play();

           b2 = false;
        }



    }


    IEnumerator notice(string txt) //플레이어 독백(하단 출력)
    {
        noticeUI.SetActive(true);
        noticeUI.GetComponentInChildren<Text>().text = txt;

        yield return new WaitForSeconds(3f);
        noticeUI.SetActive(false);
    }
}


