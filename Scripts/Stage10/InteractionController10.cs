using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionController10 : MonoBehaviour
{

    [SerializeField] Camera cam;
    RaycastHit hitInfo;

    [SerializeField] int sizeofLazer = 50;
    [SerializeField] GameObject[] interactionUI;
    [SerializeField] GameObject player;
    [SerializeField] GameObject[] cards;
    [SerializeField] GameObject CardsF;
    [SerializeField] GameObject Darts;
    [SerializeField] GameObject[] dartpins;
    [SerializeField] GameObject sofaseat;

    [SerializeField] Text explainTxt;

    [SerializeField] MovePlayer10 mc10;


    [SerializeField] Text text;
    [SerializeField] int speed = 10;

    public bool isonchair;
    public bool completecard; // card game t or f
    private bool justcardclick;
    private bool fail;
    private SceneManagement sm10;
    bool b1;

    // Start is called before the first frame update
    void Start()
    {
        SceneManagement.currentStage = 10;
        isonchair = false;
        completecard = false;
        sm10 = new SceneManagement();
        b1 = true;

    }

    // Update is called once per frame
    void Update()
    {
        Stage10GameManager.DoesCardGameEnd = completecard;
        CheckObject();

        quitChair();


        if (completecard == true &&b1)
        {
            Darts.gameObject.SetActive(true);

            StartCoroutine("explain", "ī������� ����߱�. �׷� ���� ��Ʈ���� ã�ƺ�");
            b1 = false;

        }

        void quitChair() //�̺κ��� ���� showEvent �Լ����� �����Ǿ��־��µ�, showEvent�Լ��� interaction�±װ� �޸� �繰�� ���̸� ���������� �ߵ��Ǵ� �Լ�����
                         // ���ڿ� ����ä�� ���콺 ��Ŭ�� �� ���� �߰������� interaction �±׸� �� �繰�� ���̸� ���� ���ڿ��� �Ͼ �� �ְ� �Ǿ��ִ°� ���Ƽ� �׳� �Լ������  update������ �Ű���ϴ�!
        {

            if (isonchair == true && Input.GetMouseButtonDown(1))
            {
                //ī������� �������������� ���ڿ��� �Ͼ �� �ְ� �Ǿ��־��µ� ī�带 ���� �������� ��쿡�� ���ڿ��� �Ͼ���ְ� �ϴ����� �� �����Ű��Ƽ� ���� �����߽��ϴ�..!@

                Debug.Log("���ڿ� �ɾƼ� ���콺 ������ Ŭ��");
                isonchair = false;


                player.transform.parent = null; //�������

                /*  if (completecard == true)
                  {
                      isonchair = false;

                      player.transform.parent = null; //�����Ӱ� ������.
                      //player.gameObject.transform.position = new Vector3(122, 51, 16);
                  }
                */



                if (fail == true)
                {
                    sm10.gameover(10);
                }

            }

        }

        void CheckObject()
        {
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

            Debug.DrawRay(ray.origin, ray.direction * sizeofLazer, Color.red);


            if (Physics.Raycast(ray, out hitInfo, sizeofLazer) && hitInfo.transform.CompareTag("interaction")) //� �ݶ��̴��� ���̰� �浹������ true, �ƴϸ� false. // hitinfo �� ray�� ���� ��ü�� ������ �����ϴ� ����


            {

                Contact();
                Debug.Log(hitInfo.transform.name); // �������� ���� �繰�� �̸� ���.
            }

            else
            {

                notContact();
            }
        }

        void Contact()
        {

            if (hitInfo.transform.CompareTag("interaction")) // �������� ���� �繰�� �±װ� interaction���� �Ǿ�������� true��ȯ.
            {


                showEvent(); // �������� ���� ��ü�� ������ ���� �� �� �ִ� ������ ���� UI �� ������.



            }



        }


        void notContact()
        {

            for (int i = 0; i < interactionUI.Length; i++)
            {
                interactionUI[0].GetComponent<Text>().text = "";
            }


        }


        //showEvent �Լ��� 
        void showEvent()


        {

            if (hitInfo.transform.name == "hint1")
            {
                interactionUI[0].GetComponent<Text>().text = "�����ϱ�";
                if (Input.GetMouseButtonDown(0) == true)
                {
                    interactionUI[0].GetComponent<Text>().text = "";
                    StartCoroutine("explain", "��� �߰��� ���� ������ ������ �˷��ش�.");
                }
            }

            else if (hitInfo.transform.name == "hint2")
            {
                interactionUI[0].GetComponent<Text>().text = "�����ϱ�";
                if (Input.GetMouseButtonDown(0) == true)
                {
                    interactionUI[0].GetComponent<Text>().text = "";
                    StartCoroutine("explain", "���� �տ��� �ʿ��� �� ���� �� ���̴�.");
                   
                }
            }


            else if (hitInfo.transform.name == "hint3")
            {
                interactionUI[0].GetComponent<Text>().text = "�����ϱ�";
                if (Input.GetMouseButtonDown(0) == true)
                {
                    interactionUI[0].GetComponent<Text>().text = "";
                    StartCoroutine("explain", "������ ��� �ð� ���� �͵� ������ ���� ��������");
                    
                }
            }

            else if (hitInfo.transform.name == "hint4")
            {
                interactionUI[0].GetComponent<Text>().text = "�����ϱ�";
                if (Input.GetMouseButtonDown(0) == true)
                {
                    interactionUI[0].GetComponent<Text>().text = "";
                    StartCoroutine("explain", "� �൵ ������ �ʾ�. �׳� �� �� ���ļ� ���� ������ ���ۿ�.");
                  
                }
            }


            //���� �ΰ� �߰�.
            else if (hitInfo.transform.name == "Sofa")
            {
                interactionUI[0].GetComponent<Text>().text = "�ɱ�";
                if (Input.GetMouseButtonDown(0) == true)
                {

                    player.transform.position = new Vector3(117.42f, 51.55f, 15.65f);
                    Debug.Log("On chair");

                    isonchair = true;

                }
            }

            else if (hitInfo.transform.name == "Chair")
            {
                interactionUI[0].GetComponent<Text>().text = "�ɱ�";
                if (Input.GetMouseButtonDown(0) == true)
                {

                    player.transform.parent = hitInfo.transform;
                    player.transform.localPosition = new Vector3(0.075f, 1.056f, -0.014f);
                    Debug.Log("On chair");

                    isonchair = true;

                }
            }

            // 1. Card Game ; ī�带 ���常 �̰� �ϴ� ��� �ʿ�.
            if (completecard == false)
            {

                if (hitInfo.transform.name == "Card_Chair")
                {
                    interactionUI[0].GetComponent<Text>().text = "�ɱ�";
                    if (Input.GetMouseButtonDown(0) == true)
                    {

                        // ���ڿ� �ɰ� �ϴ� ���: �÷��̾��� transform�� ���ڿ� ��ӽ�Ű�� �������� ���߱�.

                        player.transform.parent = hitInfo.transform;
                        player.transform.localPosition = new Vector3(-0.024f, 1.012f, 0.033f);
                        Debug.Log("On chair");



                        isonchair = true;
                    }
                }



                //�ؿ� �κκ� table�� ���̷� ������ ui�� ��µǴ°� �ƴ϶�, ���� ���ڿ� �ɾ������� failī�带 �̾����� ������������ �׷��� ���� ���ʰ� ��µǰ� ���������  ���� ���߿� �����س����Կ�!!!

                /* if (hitInfo.transform.name == "Table")
                 {
                     interactionUI[0].GetComponent<Text>().text = "������ ��� �ð� ���� �͵� ������ ���� �������� \n ī�带 ������ ��";
                 }

                 if (hitInfo.transform.name == "Table" && isonchair == true && fail == true)
                 {
                     interactionUI[0].GetComponent<Text>().text = "������. \n (���콺 �������� Ŭ���ϼ���)";
                 }

                 */



                if (isonchair == true) //+ ī��ü� �ɾ������� ���� �߰� �ʿ�. ������ ������ ������ � ���ڿ� �ɾƵ� ī�� ������ ����.
                {
                    if (hitInfo.transform.name == "CloverQ")
                    {
                        interactionUI[0].GetComponent<Text>().text = "������";
                        if (Input.GetMouseButtonDown(0))
                        {
                            cards[0].transform.Rotate(new Vector3(0, 0, 180));
                            interactionUI[0].GetComponent<Text>().text = "";
                            completecard = true;
                            Debug.Log("Complete Card Game");
                        }
                    }

                    if (hitInfo.transform.name == "CloverK")
                    {
                        interactionUI[0].GetComponent<Text>().text = "������";
                        if (Input.GetMouseButtonDown(0))
                        {
                            cards[1].transform.Rotate(new Vector3(0, 0, 180));
                            interactionUI[0].GetComponent<Text>().text = "";
                            completecard = true;
                            Debug.Log("Complete Card Game");
                        }
                    }

                    if (hitInfo.transform.name == "HeartQ")
                    {
                        interactionUI[0].GetComponent<Text>().text = "������";
                        if (Input.GetMouseButtonDown(0))
                        {
                            cards[2].transform.Rotate(new Vector3(0, 0, 180));
                            interactionUI[0].GetComponent<Text>().text = "";
                            completecard = true;
                            Debug.Log("Complete Card Game");
                        }
                    }

                    if (hitInfo.transform.name == "Heart10")
                    {
                        interactionUI[0].GetComponent<Text>().text = "������";
                        if (Input.GetMouseButtonDown(0))
                        {
                            cards[3].transform.Rotate(new Vector3(0, 0, 180));
                            interactionUI[0].GetComponent<Text>().text = "";
                            completecard = true;
                            Debug.Log("Complete Card Game");
                        }
                    }

                }

                if (hitInfo.transform.name == "Spade2")
                {
                    interactionUI[0].GetComponent<Text>().text = "������";
                    if (Input.GetMouseButtonDown(0))
                    {
                        cards[4].transform.Rotate(new Vector3(0, 0, 180));
                        interactionUI[0].GetComponent<Text>().text = "";
                        fail = true;
                    }
                }

                if (hitInfo.transform.name == "Spade1")
                {
                    interactionUI[0].GetComponent<Text>().text = "������";
                    if (Input.GetMouseButtonDown(0))
                    {
                        cards[5].transform.Rotate(new Vector3(0, 0, 180));
                        interactionUI[0].GetComponent<Text>().text = "";
                        fail = true;
                    }
                }

                if (hitInfo.transform.name == "Clover4")
                {
                    interactionUI[0].GetComponent<Text>().text = "������";
                    if (Input.GetMouseButtonDown(0))
                    {
                        cards[6].transform.Rotate(new Vector3(0, 0, 180));
                        interactionUI[0].GetComponent<Text>().text = "";
                        fail = true;
                    }
                }

                if (hitInfo.transform.name == "Spade9")
                {
                    interactionUI[0].GetComponent<Text>().text = "������";
                    if (Input.GetMouseButtonDown(0))
                    {
                        cards[7].transform.Rotate(new Vector3(0, 0, 180));
                        interactionUI[0].GetComponent<Text>().text = "";
                        fail = true;
                    }
                }

                if (hitInfo.transform.name == "Heart7")
                {
                    interactionUI[0].GetComponent<Text>().text = "������";
                    if (Input.GetMouseButtonDown(0))
                    {
                        cards[8].transform.Rotate(new Vector3(0, 0, 180));
                        interactionUI[0].GetComponent<Text>().text = "";
                        fail = true;
                    }
                }

                if (hitInfo.transform.name == "Dia4")
                {
                    interactionUI[0].GetComponent<Text>().text = "������";
                    if (Input.GetMouseButtonDown(0))
                    {
                        cards[9].transform.Rotate(new Vector3(0, 0, 180));
                        interactionUI[0].GetComponent<Text>().text = "";
                        justcardclick = true;
                    }
                }



            }

            if (isonchair == true)
            {

                if (hitInfo.transform.name == "CloverQ" && completecard == true)
                {
                    interactionUI[0].GetComponent<Text>().text = "Clover Q. ����";
                }

                if (hitInfo.transform.name == "CloverK" && completecard == true)
                {
                    interactionUI[0].GetComponent<Text>().text = "Clover K. ģ��";
                }

                if (hitInfo.transform.name == "HeartQ" && completecard == true)
                {
                    interactionUI[0].GetComponent<Text>().text = "Heart Q. ����";
                }

                if (hitInfo.transform.name == "Heart10" && completecard == true)
                {
                    interactionUI[0].GetComponent<Text>().text = "Heart 10. ��� �׸��� ����";
                }

                if (hitInfo.transform.name == "Spade2" && fail == true)
                {
                    interactionUI[0].GetComponent<Text>().text = "Spade 2. ���";
                }

                if (hitInfo.transform.name == "Spade1" && fail == true)
                {
                    interactionUI[0].GetComponent<Text>().text = "Spade 1. ����";
                }
                if (hitInfo.transform.name == "Clover4" && fail == true)
                {
                    interactionUI[0].GetComponent<Text>().text = "Clover 4. ���Ӽ�";
                }
                if (hitInfo.transform.name == "Spade9" && fail == true)
                {
                    interactionUI[0].GetComponent<Text>().text = "Spade 9. ����";
                }
                if (hitInfo.transform.name == "Heart7" && fail == true)
                {
                    interactionUI[0].GetComponent<Text>().text = "Heart 7. ����";
                }
                if (hitInfo.transform.name == "Dia4" && justcardclick == true)
                {
                    interactionUI[0].GetComponent<Text>().text = "Dia 4. ����";
                }
            }

            if (hitInfo.transform.name == "Door")
            {
                interactionUI[0].GetComponent<Text>().text = "�ɱ�";
                if (Input.GetMouseButtonDown(0) == true)
                {


                }
            }




            if (hitInfo.transform.name == "DartTable")
            {
                /*interactionUI[0].GetComponent<Text>().text = "��Ʈ���� ã�ƺ� \n �� ����� ��?";
                if (finddart == true)
                {
                    interactionUI[0].GetComponent<Text>().text = "���� �߰��߱�.";
                }

                */

            }

            //���ݻ��·δ� dart�� 3���� ��ã�ƾ� �Ѿ�°� �ƴ϶� 1���� ã�Ƶ� �Ѿ���� �Ǽ� ���� ���� �ʿ�.
            if (hitInfo.transform.name == "dartpin1")
            {
                interactionUI[0].GetComponent<Text>().text = "��Ʈ�� ������";
                if (Input.GetMouseButtonDown(0) == true)
                {
                    dartpins[0].GetComponent<Rigidbody>().AddForce(new Vector3(0, 200, 200));
                    Stage10GameManager.DoseDartGameEnd = true;
                }
            }
            if (hitInfo.transform.name == "dartpin2")
            {
                interactionUI[0].GetComponent<Text>().text = "��Ʈ�� ������";
                if (Input.GetMouseButtonDown(0) == true)
                {
                    dartpins[1].GetComponent<Rigidbody>().AddForce(new Vector3(0, 200, 200));
                    Stage10GameManager.DoseDartGameEnd = true;
                }
            }
            if (hitInfo.transform.name == "dartpin1")
            {
                interactionUI[0].GetComponent<Text>().text = "��Ʈ�� ������";
                if (Input.GetMouseButtonDown(0) == true)
                {
                    dartpins[2].GetComponent<Rigidbody>().AddForce(new Vector3(0, 200, 200));
                    Stage10GameManager.DoseDartGameEnd = true;
                }
            }



        }




    }


    IEnumerator explain(string txt) //���� �� ���(��� ���)
    {
        explainTxt.text = txt;

        yield return new WaitForSeconds(5f);
        explainTxt.text = "";

    }
}
    
    




