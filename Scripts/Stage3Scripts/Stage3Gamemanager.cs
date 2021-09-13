using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3Gamemanager : MonoBehaviour
{

    [SerializeField] private GameObject clock;
    [SerializeField] private GameObject decorate; //크리스마스 트리 장식(양말)
    [SerializeField] private GameObject familypicture;
    [SerializeField] private GameObject girl;
    private SceneManagement sm3 = new SceneManagement();
    //태워야할 3개의 오브젝트
    [SerializeField] private GameObject news;
    [SerializeField] private GameObject mainCam; //플레이어캠
    [SerializeField] private GameObject fadeinout; //페이드인아웃 패널
    [SerializeField] private GameObject fadeinout2;
    [SerializeField] private GameObject subcam; // 플레이어가 상자열고난후 카메라
    [SerializeField] private AudioSource audioPlayer;
    [SerializeField] private AudioClip[] bgm;
    [SerializeField] private AudioClip[] effect; //fire소리,천둥소리 ,번개소리, 타자소리
    [SerializeField] private Transform Letter; //나의 비밀을 알아버린거야?
    [SerializeField] private GameObject doodle;//낙서
    [SerializeField] private AudioSource newsSound; 



    public static bool isSecretBoxUnlocked; //비밀상자 해제시 true로 바꿔줄것.
     public static bool isNewsviewed; //플레이어가 비밀상자에 있는 상자를 클릭할경우.
    [SerializeField] Light firePlacelight;
    [SerializeField] ParticleSystem firePlaceParticle;
    [SerializeField] Interactioncontroller3 ic3;

    private bool b;
   




    [SerializeField] GameObject Player;

    public static bool isClockFired;
    public static bool isDecorateFired ;
    public static bool isFamilyPictureFired;

    //3개의 물건을 벽난로에 다 태우면 clear

    public static bool isStageCleared;

    /* [비밀상자 해제전]
    * 벽난로에 물건 태우기 불가능. (아직 불씨가 약함)
    * 아이템 집기 불가능
    * 아이템 집어서 소녀한테 물어보는거 불가능
    * 
    * [비밀상자 해제후]
    * 소녀가 천장위에서 등장.
    * 벽난로에 물건 태우기 가능 (불씨가 커짐)
    *  아이템 집기가능
    *  아이템 집어서 소녀한테 물어보는거 가능
    *  
    */



    // Start is called before the first frame update
    void Start()
    {
        girl.SetActive(false);
        doodle.SetActive(false);
        isSecretBoxUnlocked = false; //잠금해제여부
        isNewsviewed = false; //상자 안 내용물확인여부
        isClockFired = false;
        isDecorateFired = false;
        isFamilyPictureFired = false;
        isStageCleared = false;

        audioPlayer.clip = bgm[0]; //첫번째 bgm시작
       audioPlayer.Play();

        b = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (!clock.activeInHierarchy)
            isClockFired = true;

        if (!decorate.activeInHierarchy)
            isDecorateFired = true;

        if (!familypicture.activeInHierarchy)
            isFamilyPictureFired = true;

        if (isClockFired && isDecorateFired && isFamilyPictureFired)
        {

            isStageCleared = true;
            // 엔딩후 다음스테이지로.

            SceneManagement.completedStage = 3;
            sm3.movetoNextStage();
            


        }

        if (isNewsviewed && b )


        {
            StartCoroutine("secretBoxOpen");


            







            //새로운캠으로 소녀 등장 + 천둥,비 효과 +

            //불씨커짐. 활활타오름. 
            b = false;
           
        }
        


    }

    IEnumerator secretBoxOpen()
    {
        Player.GetComponent<MovePlayer>().enabled = false; //카메라움직이기 비활성화.
        mainCam.GetComponent<MoveCamera>().enabled = false; //플레이어 움직이기 비활성화. 
        ic3.enabled = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        news.GetComponent<Quit>().enabled = false;

        girl.SetActive(true);
        doodle.SetActive(true);
        news.SetActive(true);


        audioPlayer.Stop();//첫번째 bgm 종료.


        newsSound.Play();

        yield return new WaitForSeconds(28f);
        /* for (int i=0;i<10;i++)

       {Letter.GetChild(i).gameObject.SetActive(true);
       yield return new WaitForSeconds(0.5f); }
       Letter.gameObject.SetActive(false); //모든글자 끄기*/
        //나의 비밀을 알아버린거야? 글자 순서대로 출력.



        news.SetActive(false); // 5초후에 뉴스끈다. +불타는 효과음.

        fadeinout.SetActive(true); //화면 페이드인 +아웃 
        yield return new WaitForSeconds(3f);
        mainCam.SetActive(false);
        subcam.SetActive(true);
        yield return new WaitForSeconds(3f);
        audioPlayer.clip = effect[0]; //fire 효과음
        audioPlayer.Play();

        firePlacelight.color = Color.red; //조명 더 빨갛게.
        firePlacelight.range = 100;

        firePlaceParticle.startSpeed = 3;
        firePlaceParticle.startSize = 2; //불씨커짐. 더 활활타오름. 
        //벽난로 향하는 subcam on. 
       


        yield return new WaitForSeconds(5f);
        fadeinout2.SetActive(true); //화면 페이드인 +아웃 

       
        yield return new WaitForSeconds(3f);
        subcam.SetActive(false);
        mainCam.SetActive(true);
        Player.GetComponent<MovePlayer>().enabled = true; //카메라움직이기 활성화.
        mainCam.GetComponent<MoveCamera>().enabled = true; //플레이어 움직이기 활성화.
        ic3.enabled = true;

        if (mainCam.activeInHierarchy) //메인캠이켜지면
        audioPlayer.clip = bgm[1]; //바뀐브금출력.
        audioPlayer.Play();
        audioPlayer.loop = true;

        news.GetComponent<Quit>().enabled = true;

    }

}


