using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3Gamemanager : MonoBehaviour
{

    [SerializeField] private GameObject clock;
    [SerializeField] private GameObject decorate; //ũ�������� Ʈ�� ���(�縻)
    [SerializeField] private GameObject familypicture;
    [SerializeField] private GameObject girl;
    private SceneManagement sm3 = new SceneManagement();
    //�¿����� 3���� ������Ʈ
    [SerializeField] private GameObject news;
    [SerializeField] private GameObject mainCam; //�÷��̾�ķ
    [SerializeField] private GameObject fadeinout; //���̵��ξƿ� �г�
    [SerializeField] private GameObject fadeinout2;
    [SerializeField] private GameObject subcam; // �÷��̾ ���ڿ����� ī�޶�
    [SerializeField] private AudioSource audioPlayer;
    [SerializeField] private AudioClip[] bgm;
    [SerializeField] private AudioClip[] effect; //fire�Ҹ�,õ�ռҸ� ,�����Ҹ�, Ÿ�ڼҸ�
    [SerializeField] private Transform Letter; //���� ����� �˾ƹ����ž�?
    [SerializeField] private GameObject doodle;//����
    [SerializeField] private AudioSource newsSound; 



    public static bool isSecretBoxUnlocked; //��л��� ������ true�� �ٲ��ٰ�.
     public static bool isNewsviewed; //�÷��̾ ��л��ڿ� �ִ� ���ڸ� Ŭ���Ұ��.
    [SerializeField] Light firePlacelight;
    [SerializeField] ParticleSystem firePlaceParticle;
    [SerializeField] Interactioncontroller3 ic3;

    private bool b;
   




    [SerializeField] GameObject Player;

    public static bool isClockFired;
    public static bool isDecorateFired ;
    public static bool isFamilyPictureFired;

    //3���� ������ �����ο� �� �¿�� clear

    public static bool isStageCleared;

    /* [��л��� ������]
    * �����ο� ���� �¿�� �Ұ���. (���� �Ҿ��� ����)
    * ������ ���� �Ұ���
    * ������ ��� �ҳ����� ����°� �Ұ���
    * 
    * [��л��� ������]
    * �ҳడ õ�������� ����.
    * �����ο� ���� �¿�� ���� (�Ҿ��� Ŀ��)
    *  ������ ���Ⱑ��
    *  ������ ��� �ҳ����� ����°� ����
    *  
    */



    // Start is called before the first frame update
    void Start()
    {
        girl.SetActive(false);
        doodle.SetActive(false);
        isSecretBoxUnlocked = false; //�����������
        isNewsviewed = false; //���� �� ���빰Ȯ�ο���
        isClockFired = false;
        isDecorateFired = false;
        isFamilyPictureFired = false;
        isStageCleared = false;

        audioPlayer.clip = bgm[0]; //ù��° bgm����
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
            // ������ ��������������.

            SceneManagement.completedStage = 3;
            sm3.movetoNextStage();
            


        }

        if (isNewsviewed && b )


        {
            StartCoroutine("secretBoxOpen");


            







            //���ο�ķ���� �ҳ� ���� + õ��,�� ȿ�� +

            //�Ҿ�Ŀ��. ȰȰŸ����. 
            b = false;
           
        }
        


    }

    IEnumerator secretBoxOpen()
    {
        Player.GetComponent<MovePlayer>().enabled = false; //ī�޶�����̱� ��Ȱ��ȭ.
        mainCam.GetComponent<MoveCamera>().enabled = false; //�÷��̾� �����̱� ��Ȱ��ȭ. 
        ic3.enabled = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        news.GetComponent<Quit>().enabled = false;

        girl.SetActive(true);
        doodle.SetActive(true);
        news.SetActive(true);


        audioPlayer.Stop();//ù��° bgm ����.


        newsSound.Play();

        yield return new WaitForSeconds(28f);
        /* for (int i=0;i<10;i++)

       {Letter.GetChild(i).gameObject.SetActive(true);
       yield return new WaitForSeconds(0.5f); }
       Letter.gameObject.SetActive(false); //������ ����*/
        //���� ����� �˾ƹ����ž�? ���� ������� ���.



        news.SetActive(false); // 5���Ŀ� ��������. +��Ÿ�� ȿ����.

        fadeinout.SetActive(true); //ȭ�� ���̵��� +�ƿ� 
        yield return new WaitForSeconds(3f);
        mainCam.SetActive(false);
        subcam.SetActive(true);
        yield return new WaitForSeconds(3f);
        audioPlayer.clip = effect[0]; //fire ȿ����
        audioPlayer.Play();

        firePlacelight.color = Color.red; //���� �� ������.
        firePlacelight.range = 100;

        firePlaceParticle.startSpeed = 3;
        firePlaceParticle.startSize = 2; //�Ҿ�Ŀ��. �� ȰȰŸ����. 
        //������ ���ϴ� subcam on. 
       


        yield return new WaitForSeconds(5f);
        fadeinout2.SetActive(true); //ȭ�� ���̵��� +�ƿ� 

       
        yield return new WaitForSeconds(3f);
        subcam.SetActive(false);
        mainCam.SetActive(true);
        Player.GetComponent<MovePlayer>().enabled = true; //ī�޶�����̱� Ȱ��ȭ.
        mainCam.GetComponent<MoveCamera>().enabled = true; //�÷��̾� �����̱� Ȱ��ȭ.
        ic3.enabled = true;

        if (mainCam.activeInHierarchy) //����ķ��������
        audioPlayer.clip = bgm[1]; //�ٲ������.
        audioPlayer.Play();
        audioPlayer.loop = true;

        news.GetComponent<Quit>().enabled = true;

    }

}


