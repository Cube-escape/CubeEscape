using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class InteractionController5 : MonoBehaviour
{
    //[SerializeField]�� �̿��ϸ� inspector â���� ������ ����ٰ� �ʱ�ȭ ��ų �� ����. public �� ����� ����.

    [SerializeField] Camera cam;

    RaycastHit hitInfo; // RaycastHit�� �������� ���� ����� ������ ����ϴ� Ŭ����.

    [SerializeField] int sizeofLazer = 100; //lazer�� ũ��.

    [SerializeField] GameObject[] obj;
    public GameObject[] interactionUI;
    public GameObject noticeUI;
    [SerializeField] GameObject image;
    [SerializeField] GameObject Subtitle;
    [SerializeField] Sprite[] WallPaintings;
    AudioSource audio;

    //���� ���� ���� ������
    bool OpenFenceState = false;
    SceneManagement sm = new SceneManagement();
    bool end = false;
    private bool isWatchingWall = false;

    [SerializeField] GameObject Panel;
    void Start()
    {
        noticeUI.SetActive(false);
        obj[1].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        
        CheckObject();
        if (end) {

            SceneManagement.completedStage = 5;
            sm.movetoNextStage();
        }
        if (Input.GetMouseButtonDown(1))
        {
            PickDownTurnOff();
            audio = GameObject.Find("Player").GetComponent<AudioSource>();
            audio.Play();
        }
        if (obj[21].activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {

                StartCoroutine("FadeOut");
            }
            else if (Input.GetKeyDown(KeyCode.N))
            {
                StartCoroutine("notice", "���� ������� ������....");
                obj[21].SetActive(false);
            }
        }
    }

    void CheckObject()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));


        //��ȭ�� ���� ���ȿ��� contact ��Ȱ��ȭ
        if ((Physics.Raycast(ray, out hitInfo, sizeofLazer) && (hitInfo.transform.CompareTag("interaction") || hitInfo.transform.root.CompareTag("interaction"))) && !isWatchingWall) //� �ݶ��̴��� ���̰� �浹������ true, �ƴϸ� false. // hitinfo �� ray�� ���� ��ü�� ������ �����ϴ� ����
        {
            //������ ������ interaction �±׸� ���ŷӰ� �޾�����߾��µ� ������ �ֻ��� �θ� interaction �±� �޾��൵ �νĵ�.

            Contact();
            Debug.Log(hitInfo.transform.root.name);
            // Debug.Log(hitInfo.transform.name);// �������� ���� �繰�� �̸� ���.
        }
        else
        {
            notContact();
        }
    }
    void Contact()
    {
        showEvent();

    }


    void notContact()
    {

        for (int i = 0; i < interactionUI.Length; i++)
        {
            interactionUI[0].GetComponent<Text>().text = "";
        }



    }
    void showEvent()
    {
        if (Stage5GameManager.GettingCoin && Stage5GameManager.GettingFlower) {
            obj[17].SetActive(false);
            obj[20].SetActive(true);
        }
            
        else if (hitInfo.transform.name == "BoatRiding" && !(Stage5GameManager.GettingCoin && Stage5GameManager.GettingFlower)) //�÷��̾ Ż �� ���� �̺�Ʈ ����
        {
            interactionUI[0].GetComponent<Text>().text = "�� Ÿ��";


            if (GameObject.Find("Hand").transform.childCount == 0) //�÷��̾ �ƹ��͵� ��� ���� ���� ��
            {
                if (Input.GetMouseButtonDown(0)) //Ŭ���� �ϸ�
                {
                    Debug.Log("click click");
                    BoatState();
                }

            }
            else if (GameObject.Find("Hand").transform.childCount == 1)
            { //�÷��̾ ���𰡸� ������ ���� ��
                if (GameObject.Find("Hand").transform.GetChild(0).name == "Coin") //������ ��� ������
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        Stage5GameManager.GettingCoin = true;
                        PickDownTurnOff();
                        obj[2].SetActive(false);
                        BoatState(obj[2]);
                    }

                }

                else if (GameObject.Find("Hand").transform.GetChild(0).name == "plant1") //���� ��� ������
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        Stage5GameManager.GettingFlower = true;
                        PickDownTurnOff();
                        obj[3].SetActive(false);
                        BoatState(obj[3]);

                    }

                }
                else if (GameObject.Find("Hand").transform.GetChild(0).name == "plant2")
                {
                    if (Input.GetMouseButtonDown(0))
                        BoatState(obj[4]);

                }

                else if (GameObject.Find("Hand").transform.GetChild(0).name == "plant3")
                {
                    if (Input.GetMouseButtonDown(0))
                        BoatState(obj[5]);
                }
            }



        }
        else if (hitInfo.transform.name == "fence_gate1" || hitInfo.transform.name == "fence_gate2") //�빮 ���� �̺�Ʈ ����
        {
            if (!OpenFenceState) interactionUI[0].GetComponent<Text>().text = "�빮 ����";
            else interactionUI[0].GetComponent<Text>().text = "�빮 �ݱ�";


            if (Input.GetMouseButtonDown(0))
            {
                audio = GameObject.Find("Fence").GetComponent<AudioSource>();
                audio.Play();
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click �빮");
                OpenFence(); //�� ���ݱ�

            }
        }
        else if (hitInfo.transform.name == "FirePlace") //ȭ�� ���� �̺�Ʈ ����,root�� �ֻ��� �θ� ã����.
        {
            Debug.Log("ȭ��");
            if (GameObject.Find("Hand").transform.childCount == 1)
            {
                if (GameObject.Find("Hand").transform.GetChild(0).name == "OldHandTorch")
                {
                    interactionUI[0].GetComponent<Text>().text = "�� ���̱�";
                    if (Input.GetMouseButtonDown(0))
                    {
                        obj[1].SetActive(true);
                        Stage5GameManager.isCandleBright = true;
                        audio = GameObject.Find("OldHandTorch").GetComponent<AudioSource>();
                        audio.Play();
                    }

                }//ȶ���� ��� ���� ��
                else
                {
                    interactionUI[0].GetComponent<Text>().text = "ȭ�ο� ��������";
                    if (Input.GetMouseButtonDown(0)) StartCoroutine("notice", "�̰� �������� Ÿ ���� �ž�...");
                }//�ٸ� �� ��� ���� ��

            }//�տ� ���𰡸� ��� ���� ��

            else if (GameObject.Find("Hand").transform.childCount == 0)
            {
                interactionUI[0].GetComponent<Text>().text = "ȭ�� ����";
                if (Input.GetMouseButtonDown(0))
                {
                    interactionUI[0].GetComponent<Text>().text = "";
                    Debug.Log("click ȭ��");
                    StartCoroutine("notice", "���� ���� ������ ��������...."); //�ڷ�ƾ�Լ��̸������� ,(��ǥ)��� �������� ����.
                }
            }//�տ� �ƹ��͵� ��� ���� ���� ��



        }
        else if (hitInfo.transform.name == "GameObj") //���� ���� �̺�Ʈ ����
        {


            interactionUI[0].GetComponent<Text>().text = "���� ����";



            if (Input.GetMouseButtonDown(0))
            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click ȭ��");
                StartCoroutine("notice", "���� �� �̷��� ����..");
            }
        }
        else if (hitInfo.transform.name == "SecretDoor") //����� �� ���� �̺�Ʈ ����
        {

            Debug.Log("���� �ε����� ������");
            interactionUI[0].GetComponent<Text>().text = "�� ���캸��";



            if (Input.GetMouseButtonDown(0))
            {
                audio = GameObject.Find("SecretDoor").GetComponent<AudioSource>();
                audio.Play();
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click");
                GameObject.Find("RoomDoor").GetComponent<Animation>().Play("RoomDoor");
            }
        }
        else if (hitInfo.transform.name == "OldHandTorch") //ȶ�� ���� �̺�Ʈ ����
        {
            if (GameObject.Find("Hand").transform.childCount == 0) //�տ� �ƹ��͵� ���� ���� �߱�
                interactionUI[0].GetComponent<Text>().text = "ȶ�� �ݱ�";



            if (Input.GetMouseButtonDown(0))
            {
                audio = GameObject.Find("Player").GetComponent<AudioSource>();
                audio.Play();
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click ��");
                PickUp(obj[0]);
            }
        }


        else if (hitInfo.transform.name == "plant1" && GameObject.Find("Hand").transform.childCount == 0) //�ɸ� ���� �̺�Ʈ
        {
            interactionUI[0].GetComponent<Text>().text = "�ɸ� ����";
            if (Input.GetMouseButtonDown(0))
            {
                audio = GameObject.Find("Player").GetComponent<AudioSource>();
                audio.Play();
                StartCoroutine("notice", "�δ���(Rodanthe)\n\"�׻� ����϶�.\"");
                PickUp(obj[3]); //�� �ݱ�
            }
        }
        else if (hitInfo.transform.name == "plant2" && GameObject.Find("Hand").transform.childCount == 0) // �ɸ� ���� �̺�Ʈ
        {
            interactionUI[0].GetComponent<Text>().text = "�ɸ� ����";
            if (Input.GetMouseButtonDown(0))
            {
                audio = GameObject.Find("Player").GetComponent<AudioSource>();
                audio.Play();
                StartCoroutine("notice", "���� ����\n\"����\"");
                PickUp(obj[4]);//�� �ݱ�
            }

        }
        else if (hitInfo.transform.name == "plant3" && GameObject.Find("Hand").transform.childCount == 0) //�ɸ� ���� �̺�Ʈ
        {
            if (Input.GetMouseButtonDown(0))
            {
                audio = GameObject.Find("Player").GetComponent<AudioSource>();
                audio.Play();
                interactionUI[0].GetComponent<Text>().text = "�ɸ� ����";
                StartCoroutine("notice", "�Ķ� ���\n\"�Ұ���\"");
                PickUp(obj[5]);//�� �ݱ�
            }

        }
        else if (hitInfo.transform.name == "Coin")
        {
            interactionUI[0].GetComponent<Text>().text = "���� �ݱ�";
            if (Input.GetMouseButtonDown(0))
            {
                audio = GameObject.Find("Player").GetComponent<AudioSource>();
                audio.Play();
                PickUp(obj[2]);//���� �ݱ�
            }
        }
        else if (hitInfo.transform.name == "Lamp_in_Room1")  //����� �� �� �ѱ�
        {
           
            interactionUI[0].GetComponent<Text>().text = "�� �ѱ�";
            if (obj[1].activeSelf == true && obj[0].transform.parent.name == "Hand")
            {
                Debug.Log("���");

                if (Input.GetMouseButtonDown(0))
                {
                    audio = GameObject.Find("Player").GetComponent<AudioSource>();
                    audio.Play();
                    obj[7].SetActive(true);
                    obj[8].SetActive(true);

                }
            }
            else if (obj[0].transform.parent == null)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    audio = GameObject.Find("Player").GetComponent<AudioSource>();
                    audio.Play();
                    StartCoroutine("notice", "��ҿ� ���� �ٿ��� ��...");
                }
            }
            else if (obj[0].transform.parent != null&&obj[1].activeSelf == false)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    audio = GameObject.Find("Player").GetComponent<AudioSource>();
                    audio.Play();
                    StartCoroutine("notice", "ȶ�ҿ� ���� �ٿ��� ��...");
                }
            }

        }
        else if (hitInfo.transform.name == "Lamp_in_Room2") //����� �� �� �ѱ�
        {
            

            interactionUI[0].GetComponent<Text>().text = "�� �ѱ�";
            if (obj[1].activeSelf == true && obj[0].transform.parent.name == "Hand")
            {
                Debug.Log("���");

                if (Input.GetMouseButtonDown(0))
                {
                    audio = GameObject.Find("Player").GetComponent<AudioSource>();
                    audio.Play();
                    obj[9].SetActive(true);
                    obj[10].SetActive(true);


                }
            }
            else if (obj[0].transform.parent == null)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    audio = GameObject.Find("Player").GetComponent<AudioSource>();
                    audio.Play();
                    StartCoroutine("notice", "��ҿ� ���� �ٿ��� ��...");
                }
            }
            else if (obj[0].transform.parent != null && obj[1].activeSelf == false)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    audio = GameObject.Find("Player").GetComponent<AudioSource>();
                    audio.Play();
                    StartCoroutine("notice", "ȶ�ҿ� ���� �ٿ��� ��...");
                }
            }

        }
        else if (hitInfo.transform.name == "Lamp_in_Room3") //����� �� �� �ѱ�
        {
           
            interactionUI[0].GetComponent<Text>().text = "�� �ѱ�";
            if (obj[1].activeSelf == true && obj[0].transform.parent.name == "Hand")
            {
                

                if (Input.GetMouseButtonDown(0))
                {
                    audio = GameObject.Find("Player").GetComponent<AudioSource>();
                    audio.Play();
                    obj[11].SetActive(true);
                    obj[12].SetActive(true);


                }
            }
            else if (obj[0].transform.parent == null)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    audio = GameObject.Find("Player").GetComponent<AudioSource>();
                    audio.Play();
                    StartCoroutine("notice", "��ҿ� ���� �ٿ��� ��...");
                }
            }
            else if (obj[0].transform.parent != null && obj[1].activeSelf == false)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    audio = GameObject.Find("Player").GetComponent<AudioSource>();
                    audio.Play();
                    StartCoroutine("notice", "ȶ�ҿ� ���� �ٿ��� ��...");
                }
            }

        }
        else if (hitInfo.transform.name == "Lamp_in_Room4") //����� �� �� �ѱ�
        {
            interactionUI[0].GetComponent<Text>().text = "�� �ѱ�";
            if (obj[1].activeSelf == true && obj[0].transform.parent.name == "Hand"   && Input.GetMouseButtonDown(0))
            {
                Debug.Log("���");

                audio = GameObject.Find("Player").GetComponent<AudioSource>();
                audio.Play();
                obj[13].SetActive(true);
                obj[14].SetActive(true);
            }
            else if (obj[0].transform.parent == null&& Input.GetMouseButtonDown(0))
            {
                audio = GameObject.Find("Player").GetComponent<AudioSource>();
                audio.Play();
                StartCoroutine("notice", "��ҿ� ���� �ٿ��� ��...");
            }
            else if (obj[0].transform.parent != null && obj[1].activeSelf == false && Input.GetMouseButtonDown(0))
            {
                audio = GameObject.Find("Player").GetComponent<AudioSource>();
                audio.Play();
                StartCoroutine("notice", "ȶ�ҿ� ���� �ٿ��� ��...");
            }

        }

        else if ((hitInfo.transform.name == "WallPainting1" || hitInfo.transform.name == "WallPainting2" || hitInfo.transform.name == "WallPainting3")) //��ȭ �߿� �ϳ� ���� ��� ĵ���� ������
        {
            Debug.Log("��ȭ");
            
            
            if (obj[7].activeSelf == true && obj[9].activeSelf == true && obj[11].activeSelf == true && obj[13].activeSelf == true )
            {
                interactionUI[0].GetComponent<Text>().text = "��ȭ ����";
                if (Input.GetMouseButtonDown(0))
                {
                    audio = GameObject.Find("Player").GetComponent<AudioSource>();
                    audio.Play();
                    Debug.Log("��ȭ ���");
                    isWatchingWall = true; //��ȭ ���� ���� contact() ��Ȱ��ȭ
                    StartCoroutine("WallImage");
                }
            }

        }
        else if (hitInfo.transform == obj[6])
        {
            interactionUI[0].GetComponent<Text>().text = "���� ������";
            if (Input.GetMouseButtonDown(0))
            {
                sm.movetoNextStage();
            }
        }

        if (hitInfo.transform.name == "book_closed"&&Stage5GameManager.RidingBoat)
        {
            interactionUI[0].GetComponent<Text>().text = "å ����";
            if (Input.GetMouseButtonDown(0))
            {
                audio = GameObject.Find("Player").GetComponent<AudioSource>();
                audio.Play();
                obj[15].SetActive(true);
                obj[16].SetActive(false);
            }
        }
        else if (hitInfo.transform.name == "Scroll" && Stage5GameManager.RidingBoat)
        {
            interactionUI[0].GetComponent<Text>().text = "���� ����";
            if (Input.GetMouseButtonDown(0)) obj[18].SetActive(true);
        }
        else if (hitInfo.transform.name == "UnderTheWater") {

            interactionUI[0].GetComponent<Text>().text = "���� ������";
            if (Input.GetMouseButtonDown(0))
            {
                NextLevel();
            }
        }

    }

    IEnumerator notice(string txt) //txt �� ���ڷ� ����.
    {
        noticeUI.SetActive(true);
        noticeUI.GetComponentInChildren<Text>().text = txt;
        yield return new WaitForSeconds(2f);
        noticeUI.SetActive(false);
    }
    void OpenFence()
    { //�빮 ���ݴ� �Լ�
        if (!OpenFenceState) //���� ������ ��
        {
            GameObject.Find("Fence").GetComponent<Animation>().Play("DoorOpen"); //���� ������ �ִϸ��̼� ���
            OpenFenceState = true; //���� ���� �ɷ� ���� ����
        }
        else
        { //���� ������ ��
            GameObject.Find("Fence").GetComponent<Animation>().Play("DoorClose"); //���� ������ �ִϸ��̼� ���
            OpenFenceState = false; //���� ���� �ɷ� ���� ����
        }

    }

    void PickUp(GameObject name)
    { //���� �ݴ� �Լ�

        if (GameObject.Find("Hand").transform.childCount == 0)
        {
            name.transform.parent = GameObject.Find("Hand").transform; //�������� �տ� ��ӽ�Ű��
            name.transform.position = GameObject.Find("Hand").transform.position; //������ ��ġ�� �հ� �����ϰ�
            name.GetComponent<Rigidbody>().useGravity = false; //�����ۿ� �߷� ����
            name.GetComponent<Rigidbody>().isKinematic = true;
        }//���� �տ� �������� ���ٸ�


    }

    void PickDownTurnOff() //���� ����߸��� �Լ�
    {
        for (int i = 0; i <= 5; i++)
        {
            if(i!=1)
                obj[i].transform.parent = null; //�������� �ܵ����� �����(�θ� ����)
            obj[i].GetComponent<Rigidbody>().useGravity = true; //�����ۿ� �߷��� ����� ������ ��������
            obj[i].GetComponent<Rigidbody>().isKinematic = false;
        }
        obj[1].SetActive(false);
        obj[15].SetActive(false);
        obj[16].SetActive(true);
        obj[18].SetActive(false);
        obj[19].SetActive(true);


    }



    //�� �����̱�
    void BoatState(GameObject obj1)
    { //���� ��Ʈ�� Ż �� �ִ��� ����


        if (Stage5GameManager.GettingCoin) //������ ����� ��
        {
            if (!Stage5GameManager.GettingFlower) //���� ���� ������ ��
            {
                if (Input.GetMouseButtonDown(0))
                { //Ŭ���ϸ�
                    StartCoroutine("notice", "���� : �踦 �����̴� ����� ����� ���� �ʴ±�...");
                    
                }

            }
            else if (Stage5GameManager.GettingFlower) //���� ����� ��
            {
                if (Input.GetMouseButtonDown(0))
                {
                    StartCoroutine("notice", "�踦 ���� Ż �� �־�");
                    
                    StartCoroutine("RidingBoat");
                }

            }
        }
        else //������ ���� ������ ��
        {
            if (Stage5GameManager.GettingFlower) //���� ����� ��
            {
                if (Input.GetMouseButtonDown(0))
                { //Ŭ���ϸ�
                    StartCoroutine("notice", "���� : �踦 �����̴� ����� ��ﳪ�±���...!\n������ ����� ����� �踦 Ż �� �־�.");
                    
                }

            }

        }


    }
    void BoatState()
    { //���� ��Ʈ�� Ż �� �ִ��� ����
        if (!Stage5GameManager.GettingCoin)
        {

            StartCoroutine("notice", "���� : ����� ��߸� �踦 Ż �� �ֳ�.");
        }


    }
    IEnumerator RidingBoat()
    {
        Stage5GameManager.RidingBoat = true;
        yield return new WaitForSeconds(1f);
        
        GameObject.Find("Player").GetComponent<Animation>().Play("RidingBoat");  //�迡 �ö�Ÿ�� �ִϸ��̼�

        yield return new WaitForSeconds(2.5f);

        GameObject.Find("BoatRiding").transform.parent = GameObject.Find("Player").transform; //�÷��̾ �迡 ��ӽ�Ű��
        GameObject.Find("BoatRiding").transform.localPosition = new Vector3(0, -1, 4); //�÷��̾� ��ġ�� ���� ��ġ��

        GameObject.Find("BoatRiding").transform.localRotation = Quaternion.Euler(0f, 0f, 0f); //�÷��̾�� ���� ���� ����
        GameObject.Find("Player").transform.localRotation = Quaternion.Euler(0f, 180f, 0f);

        yield return new WaitForSeconds(3f);
        interactionUI[2].SetActive(true);
        yield return new WaitForSeconds(3f);
        interactionUI[2].SetActive(false);

    }
    IEnumerator WallImage()
    {
        obj[22].SetActive(true); //��ƼŬ ������ �����
        yield return new WaitForSeconds(1.5f); // ����
        StartCoroutine("notice", "����..?!"); 
        yield return new WaitForSeconds(3f);
        
        //���� ��� ���� �� ��� �ѱ� ���̵��ν���
        GameObject.Find("Hand").GetComponent<AudioSource>().Stop();
        GameObject.Find("Main Camera").GetComponent<AudioSource>().Stop();
        interactionUI[0].SetActive(false);
        interactionUI[1].SetActive(false);
        GameObject.Find("FadeInOut").GetComponent<Animation>().Play("FadeOuy");
        yield return new WaitForSeconds(0.5f);
        GameObject.Find("FadeInOut").GetComponent<Animation>().Play("FadeIn");
        
        GameObject.Find("FadeInOut").GetComponent<Animation>().Play("FadeOuy");

        obj[23].GetComponent<AudioSource>().Play();
        for (int i = 1; i < 9; i++)
        {
            
            
            
            image.GetComponent<Image>().sprite = WallPaintings[i];
            Subtitle.SetActive(true);
            if (i == 1) GameObject.Find("Subtitles").GetComponentInChildren<Text>().text = "���� ������, �� ������ �ູ�� ������� �����ߴ�.";
            else if (i == 2) GameObject.Find("Subtitles").GetComponentInChildren<Text>().text = "�׷��� ��� ��, ���콺�� �ΰ� ���� ����� ������������ �Ͽ��� �ǵ��� �ΰ� ���� �������´�.\n";
            else if (i == 3) GameObject.Find("Subtitles").GetComponentInChildren<Text>().text = "�ΰ� ���� ������ �ǵ���� �ູ�� ������ ���εǾ� �ִ� ���ڸ� ���� �Ǿ���.";
            else if (i == 4) GameObject.Find("Subtitles").GetComponentInChildren<Text>().text = "ȣ����� ���� �ǵ���� �ᱹ ����� �� �� ���ڸ� ������Ȱ� �ᱹ ���󿡴� ���ͼ� �� �� �ؾǵ��� ������ ���Ҵ�.\n����, ��, ������ ������ ���� �ؾǵ��� ���� ������ �ΰ����� ���θ� �����ϰ� �̿��ϸ� ��ġ�� �׿���.";
            else if (i == 5) GameObject.Find("Subtitles").GetComponentInChildren<Text>().text = "���θ� ��ġ�� �̿��ϸ� �ΰ����� �˴� ���� ���ſ����� �ᱹ �ٽ� �̻��� ��ư��� ������ ���� �����ϸ� ��ư����ߴ�.";
            else if (i == 6) GameObject.Find("Subtitles").GetComponentInChildren<Text>().text = "������ ����� ������ �̻��� ��ư��� �ΰ����� ����ؼ� ����޾Ұ� �̸� ��Ÿ���� ���� ���״� �ΰ��鿡�� �ູ�� �������� �Ͽ���.";
            else if (i == 7) GameObject.Find("Subtitles").GetComponentInChildren<Text>().text = "�� �ູ�� �ٷ� '����'�̾���. �ΰ����� ���� �� ������ ������ ������ ���ð� ������ ����� ������ ���� ������ ���Ӱ� �̻��� �� �� �ְ� �Ǿ���. ";
            else if (i == 8) GameObject.Find("Subtitles").GetComponentInChildren<Text>().text = "�װ��� �ٷ� ������ �ູ, '����'�̴�.";


            yield return new WaitForSeconds(7f);
            GameObject.Find("FadeInOut").GetComponent<Animation>().Play("FadeInOut");
            yield return new WaitForSeconds(1.5f);
        }
        
        obj[22].SetActive(false);
        Subtitle.SetActive(false);
        Subtitle.GetComponent<AudioSource>().Stop();
        obj[2].SetActive(true);
        
        GameObject.Find("Hand").GetComponent<AudioSource>().Play();
        GameObject.Find("Main Camera").GetComponent<AudioSource>().Play();

        obj[23].GetComponent<AudioSource>().Stop();

        yield return new WaitForSeconds(2.5f);
        
        StartCoroutine("notice", "�׷��ٸ� �̰��� ������ '��� ������ ��'...?");
        obj[2].GetComponent<AudioSource>().Play();
        CoinDrop();
        interactionUI[0].SetActive(true);
        interactionUI[1].SetActive(true);
        isWatchingWall = false; //�ٽ� contact() Ȱ��ȭ 
    }
    void CoinDrop() {
        obj[2].SetActive(true);
    }
    void NextLevel() {
        obj[21].SetActive(true);
        
    }
    IEnumerator FadeOut() {
        yield return new WaitForSeconds(1.5f);
        Panel.SetActive(true);
        yield return new WaitForSeconds(3f);
        end = true;

    }
}