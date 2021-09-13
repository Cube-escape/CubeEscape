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

            StartCoroutine("explain", "카드게임을 통과했군. 그럼 이제 다트핀을 찾아봐");
            b1 = false;

        }

        void quitChair() //이부분이 원래 showEvent 함수내에 구현되어있었는데, showEvent함수는 interaction태그가 달린 사물에 레이를 쐈을때에만 발동되는 함수여서
                         // 의자에 앉은채로 마우스 우클릭 에 더해 추가적으로 interaction 태그를 단 사물에 레이를 쏴야 의자에서 일어날 수 있게 되어있는거 같아서 그냥 함수만들고  update문으로 옮겼습니다!
        {

            if (isonchair == true && Input.GetMouseButtonDown(1))
            {
                //카드게임을 성공시켰을때만 의자에서 일어날 수 있게 되어있었는데 카드를 아직 뽑지않은 경우에도 의자에서 일어날수있게 하는편이 더 좋을거같아서 조금 수정했습니당..!@

                Debug.Log("의자에 앉아서 마우스 오른쪽 클릭");
                isonchair = false;


                player.transform.parent = null; //상속해제

                /*  if (completecard == true)
                  {
                      isonchair = false;

                      player.transform.parent = null; //자유롭게 움직임.
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


            if (Physics.Raycast(ray, out hitInfo, sizeofLazer) && hitInfo.transform.CompareTag("interaction")) //어떤 콜라이더와 레이가 충돌했으면 true, 아니면 false. // hitinfo 는 ray에 맞은 객체의 정보를 저장하는 변수


            {

                Contact();
                Debug.Log(hitInfo.transform.name); // 레이저에 닿은 사물의 이름 출력.
            }

            else
            {

                notContact();
            }
        }

        void Contact()
        {

            if (hitInfo.transform.CompareTag("interaction")) // 레이저에 맞은 사물의 태그가 interaction으로 되어있을경우 true반환.
            {


                showEvent(); // 레이저에 맞은 객체의 종류에 따라 할 수 있는 행위를 담은 UI 를 보여줌.



            }



        }


        void notContact()
        {

            for (int i = 0; i < interactionUI.Length; i++)
            {
                interactionUI[0].GetComponent<Text>().text = "";
            }


        }


        //showEvent 함수는 
        void showEvent()


        {

            if (hitInfo.transform.name == "hint1")
            {
                interactionUI[0].GetComponent<Text>().text = "조사하기";
                if (Input.GetMouseButtonDown(0) == true)
                {
                    interactionUI[0].GetComponent<Text>().text = "";
                    StartCoroutine("explain", "운과 발견은 때로 죽음의 샛길을 알려준다.");
                }
            }

            else if (hitInfo.transform.name == "hint2")
            {
                interactionUI[0].GetComponent<Text>().text = "조사하기";
                if (Input.GetMouseButtonDown(0) == true)
                {
                    interactionUI[0].GetComponent<Text>().text = "";
                    StartCoroutine("explain", "죽음 앞에서 필요한 건 오직 운 뿐이다.");
                   
                }
            }


            else if (hitInfo.transform.name == "hint3")
            {
                interactionUI[0].GetComponent<Text>().text = "조사하기";
                if (Input.GetMouseButtonDown(0) == true)
                {
                    interactionUI[0].GetComponent<Text>().text = "";
                    StartCoroutine("explain", "죽음을 운명에 맡겨 보는 것도 나쁘지 않은 선택이지");
                    
                }
            }

            else if (hitInfo.transform.name == "hint4")
            {
                interactionUI[0].GetComponent<Text>().text = "조사하기";
                if (Input.GetMouseButtonDown(0) == true)
                {
                    interactionUI[0].GetComponent<Text>().text = "";
                    StartCoroutine("explain", "어떤 약도 통하지 않아. 그냥 한 번 미쳐서 운을 따르는 수밖에.");
                  
                }
            }


            //의자 두개 추가.
            else if (hitInfo.transform.name == "Sofa")
            {
                interactionUI[0].GetComponent<Text>().text = "앉기";
                if (Input.GetMouseButtonDown(0) == true)
                {

                    player.transform.position = new Vector3(117.42f, 51.55f, 15.65f);
                    Debug.Log("On chair");

                    isonchair = true;

                }
            }

            else if (hitInfo.transform.name == "Chair")
            {
                interactionUI[0].GetComponent<Text>().text = "앉기";
                if (Input.GetMouseButtonDown(0) == true)
                {

                    player.transform.parent = hitInfo.transform;
                    player.transform.localPosition = new Vector3(0.075f, 1.056f, -0.014f);
                    Debug.Log("On chair");

                    isonchair = true;

                }
            }

            // 1. Card Game ; 카드를 한장만 뽑게 하는 기능 필요.
            if (completecard == false)
            {

                if (hitInfo.transform.name == "Card_Chair")
                {
                    interactionUI[0].GetComponent<Text>().text = "앉기";
                    if (Input.GetMouseButtonDown(0) == true)
                    {

                        // 의자에 앉게 하는 기능: 플레이어의 transform을 의자에 상속시키고 움직임을 멈추기.

                        player.transform.parent = hitInfo.transform;
                        player.transform.localPosition = new Vector3(-0.024f, 1.012f, 0.033f);
                        Debug.Log("On chair");



                        isonchair = true;
                    }
                }



                //밑에 두부분 table을 레이로 쐈을때 ui로 출력되는게 아니라, 각각 의자에 앉았을때랑 fail카드를 뽑았을때 족보느낌으로 그래픽 만들어서 몇초간 출력되고 사라지도록  제가 나중에 수정해놓을게요!!!

                /* if (hitInfo.transform.name == "Table")
                 {
                     interactionUI[0].GetComponent<Text>().text = "죽음을 운명에 맡겨 보는 것도 나쁘지 않은 선택이지 \n 카드를 뒤집어 봐";
                 }

                 if (hitInfo.transform.name == "Table" && isonchair == true && fail == true)
                 {
                     interactionUI[0].GetComponent<Text>().text = "끝났군. \n (마우스 오른쪽을 클릭하세요)";
                 }

                 */



                if (isonchair == true) //+ 카드체어에 앉았을때만 조건 추가 필요. 지금은 세개의 의자중 어떤 의자에 앉아도 카드 뒤집기 가능.
                {
                    if (hitInfo.transform.name == "CloverQ")
                    {
                        interactionUI[0].GetComponent<Text>().text = "뒤집기";
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
                        interactionUI[0].GetComponent<Text>().text = "뒤집기";
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
                        interactionUI[0].GetComponent<Text>().text = "뒤집기";
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
                        interactionUI[0].GetComponent<Text>().text = "뒤집기";
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
                    interactionUI[0].GetComponent<Text>().text = "뒤집기";
                    if (Input.GetMouseButtonDown(0))
                    {
                        cards[4].transform.Rotate(new Vector3(0, 0, 180));
                        interactionUI[0].GetComponent<Text>().text = "";
                        fail = true;
                    }
                }

                if (hitInfo.transform.name == "Spade1")
                {
                    interactionUI[0].GetComponent<Text>().text = "뒤집기";
                    if (Input.GetMouseButtonDown(0))
                    {
                        cards[5].transform.Rotate(new Vector3(0, 0, 180));
                        interactionUI[0].GetComponent<Text>().text = "";
                        fail = true;
                    }
                }

                if (hitInfo.transform.name == "Clover4")
                {
                    interactionUI[0].GetComponent<Text>().text = "뒤집기";
                    if (Input.GetMouseButtonDown(0))
                    {
                        cards[6].transform.Rotate(new Vector3(0, 0, 180));
                        interactionUI[0].GetComponent<Text>().text = "";
                        fail = true;
                    }
                }

                if (hitInfo.transform.name == "Spade9")
                {
                    interactionUI[0].GetComponent<Text>().text = "뒤집기";
                    if (Input.GetMouseButtonDown(0))
                    {
                        cards[7].transform.Rotate(new Vector3(0, 0, 180));
                        interactionUI[0].GetComponent<Text>().text = "";
                        fail = true;
                    }
                }

                if (hitInfo.transform.name == "Heart7")
                {
                    interactionUI[0].GetComponent<Text>().text = "뒤집기";
                    if (Input.GetMouseButtonDown(0))
                    {
                        cards[8].transform.Rotate(new Vector3(0, 0, 180));
                        interactionUI[0].GetComponent<Text>().text = "";
                        fail = true;
                    }
                }

                if (hitInfo.transform.name == "Dia4")
                {
                    interactionUI[0].GetComponent<Text>().text = "뒤집기";
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
                    interactionUI[0].GetComponent<Text>().text = "Clover Q. 믿음";
                }

                if (hitInfo.transform.name == "CloverK" && completecard == true)
                {
                    interactionUI[0].GetComponent<Text>().text = "Clover K. 친절";
                }

                if (hitInfo.transform.name == "HeartQ" && completecard == true)
                {
                    interactionUI[0].GetComponent<Text>().text = "Heart Q. 도움";
                }

                if (hitInfo.transform.name == "Heart10" && completecard == true)
                {
                    interactionUI[0].GetComponent<Text>().text = "Heart 10. 행운 그리고 성공";
                }

                if (hitInfo.transform.name == "Spade2" && fail == true)
                {
                    interactionUI[0].GetComponent<Text>().text = "Spade 2. 경고";
                }

                if (hitInfo.transform.name == "Spade1" && fail == true)
                {
                    interactionUI[0].GetComponent<Text>().text = "Spade 1. 불행";
                }
                if (hitInfo.transform.name == "Clover4" && fail == true)
                {
                    interactionUI[0].GetComponent<Text>().text = "Clover 4. 속임수";
                }
                if (hitInfo.transform.name == "Spade9" && fail == true)
                {
                    interactionUI[0].GetComponent<Text>().text = "Spade 9. 질병";
                }
                if (hitInfo.transform.name == "Heart7" && fail == true)
                {
                    interactionUI[0].GetComponent<Text>().text = "Heart 7. 집착";
                }
                if (hitInfo.transform.name == "Dia4" && justcardclick == true)
                {
                    interactionUI[0].GetComponent<Text>().text = "Dia 4. 조언";
                }
            }

            if (hitInfo.transform.name == "Door")
            {
                interactionUI[0].GetComponent<Text>().text = "앉기";
                if (Input.GetMouseButtonDown(0) == true)
                {


                }
            }




            if (hitInfo.transform.name == "DartTable")
            {
                /*interactionUI[0].GetComponent<Text>().text = "다트핀을 찾아봐 \n 꽤 어려울 걸?";
                if (finddart == true)
                {
                    interactionUI[0].GetComponent<Text>().text = "운을 발견했군.";
                }

                */

            }

            //지금상태로는 dart핀 3개를 다찾아야 넘어가는게 아니라 1개만 찾아도 넘어가지게 되서 추후 수정 필요.
            if (hitInfo.transform.name == "dartpin1")
            {
                interactionUI[0].GetComponent<Text>().text = "다트핀 던지기";
                if (Input.GetMouseButtonDown(0) == true)
                {
                    dartpins[0].GetComponent<Rigidbody>().AddForce(new Vector3(0, 200, 200));
                    Stage10GameManager.DoseDartGameEnd = true;
                }
            }
            if (hitInfo.transform.name == "dartpin2")
            {
                interactionUI[0].GetComponent<Text>().text = "다트핀 던지기";
                if (Input.GetMouseButtonDown(0) == true)
                {
                    dartpins[1].GetComponent<Rigidbody>().AddForce(new Vector3(0, 200, 200));
                    Stage10GameManager.DoseDartGameEnd = true;
                }
            }
            if (hitInfo.transform.name == "dartpin1")
            {
                interactionUI[0].GetComponent<Text>().text = "다트핀 던지기";
                if (Input.GetMouseButtonDown(0) == true)
                {
                    dartpins[2].GetComponent<Rigidbody>().AddForce(new Vector3(0, 200, 200));
                    Stage10GameManager.DoseDartGameEnd = true;
                }
            }



        }




    }


    IEnumerator explain(string txt) //설명 및 명언(상단 출력)
    {
        explainTxt.text = txt;

        yield return new WaitForSeconds(5f);
        explainTxt.text = "";

    }
}
    
    




