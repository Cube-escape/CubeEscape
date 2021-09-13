using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionController13 : MonoBehaviour
{
    [SerializeField] Camera cam;

    RaycastHit hitInfo;

    [SerializeField] int sizeofLazer = 30;

    [SerializeField] GameObject interactionUI;

    [SerializeField] GameObject Player;
    [SerializeField] GameObject Arm;
    [SerializeField] GameObject[] mark_hided; //숨겨진 마크
    [SerializeField] GameObject[] mark_showed; //중앙에 바위위에 뜨는 마크
    [SerializeField] GameObject Letter;
    [SerializeField] GameObject PollenOfLight;

    [SerializeField] AudioSource soundEffect;
    [SerializeField] AudioClip[] effects;
    [SerializeField] GameObject fadeout;
    [SerializeField] GameObject fadein;



    private SceneManagement sm13;







    // Start is called before the first frame update
    void Start()
    {
        soundEffect.clip = effects[0];
        sm13 = new SceneManagement();
       // fadein.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

        CheckObject();


    }

    void CheckObject()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        Debug.DrawRay(ray.origin, ray.direction * sizeofLazer, Color.red);


        if (Physics.Raycast(ray, out hitInfo, sizeofLazer) && hitInfo.transform.CompareTag("interaction")) //어떤 콜라이더와 레이가 충돌했으면 true, 아니면 false. // hitinfo 는 ray에 맞은 객체의 정보를 저장하는 변수


        {

            Contact();
            Debug.Log(hitInfo.transform.name);// 레이저에 닿은 사물의 이름 출력.
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

        interactionUI.GetComponent<Text>().text = "";



    }

    void showEvent()
    {
        if (hitInfo.transform.name == "mark_white1")
        {


            interactionUI.GetComponent<Text>().text = "문양 만지기";

            //그 상태에서 마우스 왼쪽버튼을 클릭하면
            if (Input.GetMouseButtonDown(0) && mark_showed[0].activeInHierarchy) //0이 마우스 왼쪽. 1이 마우스 오른쪽
            {

                hitInfo.transform.gameObject.SetActive(false);
                mark_showed[0].SetActive(false);
                mark_showed[1].SetActive(true);
                soundEffect.clip = effects[0];
                soundEffect.Play();
                interactionUI.GetComponent<Text>().text = "";
                Debug.Log("click mark1");




            }

        }

        else if (hitInfo.transform.name == "mark_white2")
        {

            interactionUI.GetComponent<Text>().text = "문양 만지기";


            //그 상태에서 마우스 왼쪽버튼을 클릭하면
            if (Input.GetMouseButtonDown(0) && mark_showed[1].activeInHierarchy) //0이 마우스 왼쪽. 1이 마우스 오른쪽
            {

                interactionUI.GetComponent<Text>().text = "";


                hitInfo.transform.gameObject.SetActive(false);
                soundEffect.clip = effects[0];
                soundEffect.Play(); //문양의 변화가 일어났다는걸 알려주는 효과음
                mark_showed[1].SetActive(false);
                mark_showed[2].SetActive(true);
                

                Debug.Log("click mark2");




            }


        }


        else if (hitInfo.transform.name == "mark_white3")
        {


            interactionUI.GetComponent<Text>().text = "문양 만지기";

            //그 상태에서 마우스 왼쪽버튼을 클릭하면
            if (Input.GetMouseButtonDown(0) && mark_showed[2].activeInHierarchy) //0이 마우스 왼쪽. 1이 마우스 오른쪽
            {

                hitInfo.transform.gameObject.SetActive(false);
                soundEffect.clip = effects[0];
                soundEffect.Play(); //문양의 변화가 일어났다는걸 알려주는 효과음
                mark_showed[2].SetActive(false);
                mark_showed[3].SetActive(true);
                
                interactionUI.GetComponent<Text>().text = "";
                Debug.Log("click mark3");




            }


        }



        else if (hitInfo.transform.name == "mark_white4")
        {


            interactionUI.GetComponent<Text>().text = "문양 만지기";

            //그 상태에서 마우스 왼쪽버튼을 클릭하면
            if (Input.GetMouseButtonDown(0) && mark_showed[3].activeInHierarchy) //0이 마우스 왼쪽. 1이 마우스 오른쪽
            {

                hitInfo.transform.gameObject.SetActive(false);
                soundEffect.clip = effects[0];
                soundEffect.Play(); //문양의 변화가 일어났다는걸 알려주는 효과음
                mark_showed[3].SetActive(false);
                mark_showed[4].SetActive(true);
                interactionUI.GetComponent<Text>().text = "";
                Debug.Log("click mark4");



            }

        }


        else if (hitInfo.transform.name == "mark_white5")
        {


            interactionUI.GetComponent<Text>().text = "문양 만지기";

            //그 상태에서 마우스 왼쪽버튼을 클릭하면
            if (Input.GetMouseButtonDown(0) && mark_showed[4].activeInHierarchy) //0이 마우스 왼쪽. 1이 마우스 오른쪽
            {

                hitInfo.transform.gameObject.SetActive(false);
                mark_showed[4].SetActive(false);
                soundEffect.clip = effects[1];
                soundEffect.Play(); // 모든 문양을 클릭했을때 효과음
                interactionUI.GetComponent<Text>().text = "";
                Debug.Log("click mark5");
                Stage13Gamemanager.isAllMarkClicked = true;




            }



        }

        else if (hitInfo.transform.name == "Letter")
        {


            interactionUI.GetComponent<Text>().text = "자세히보기";

            //그 상태에서 마우스 왼쪽버튼을 클릭하면
            if (Input.GetMouseButtonDown(0)) //0이 마우스 왼쪽. 1이 마우스 오른쪽
            {

                Letter.SetActive(true);
                interactionUI.GetComponent<Text>().text = "";
                Debug.Log("click letter");



            }

        }

        //나비가 글씨있는곳까지 도달했다면.

        else if (hitInfo.transform.name == "ButterflyMesh")
        {


            interactionUI.GetComponent<Text>().text = "빛의 꽃가루 채집하기";

            //그 상태에서 마우스 왼쪽버튼을 클릭하면
            if (Input.GetMouseButtonDown(0)) //0이 마우스 왼쪽. 1이 마우스 오른쪽
            {
                soundEffect.clip = effects[2];
                soundEffect.Play();
                PollenOfLight.SetActive(true);
                interactionUI.GetComponent<Text>().text = "";
                Debug.Log("click butterfly");



            }

        }



        else if ((hitInfo.transform.name == "head1" || hitInfo.transform.name == "head2" || hitInfo.transform.name == "head3" || hitInfo.transform.name == "head4" || hitInfo.transform.name == "head5") && (Arm.transform.GetChild(0).gameObject.activeInHierarchy))
        {

            Lightinf lightinf = hitInfo.transform.gameObject.GetComponent<Lightinf>();
            Debug.Log(hitInfo.transform.gameObject.name);

            if (lightinf.GetPollenOfLight == false) //빛의 꽃가루를 아직 넣기 전일때만
            {
                interactionUI.GetComponent<Text>().text = "빛의 꽃가루 넣기";

                //그 상태에서 마우스 왼쪽버튼을 클릭하면
                if (Input.GetMouseButtonDown(0)) //0이 마우스 왼쪽. 1이 마우스 오른쪽
                {
                    soundEffect.clip = effects[3];
                    soundEffect.Play();
                    hitInfo.transform.gameObject.GetComponent<Lightinf>().enabled = true; //조명장치 켜짐

                    interactionUI.GetComponent<Text>().text = "";
                    Debug.Log("put pollenOfLight into" + hitInfo.transform.root.name);
                    lightinf.GetPollenOfLight = true;
                }

            }
           



        }


        else if ((hitInfo.transform.name == "head1" || hitInfo.transform.name == "head2" || hitInfo.transform.name == "head3" || hitInfo.transform.name == "head4" || hitInfo.transform.name == "head5") && (!Arm.transform.GetChild(0).gameObject.activeInHierarchy))
        {

            Lightinf lightinf = hitInfo.transform.gameObject.GetComponent<Lightinf>();
            Debug.Log(hitInfo.transform.gameObject.name);

            if (lightinf.GetPollenOfLight == false) //빛의 꽃가루를 아직 넣기 전일때만
            {
                interactionUI.GetComponent<Text>().text = "꺼져있다.";

                //그 상태에서 마우스 왼쪽버튼을 클릭하면
                if (Input.GetMouseButtonDown(0)) //0이 마우스 왼쪽. 1이 마우스 오른쪽
                {

                    interactionUI.GetComponent<Text>().text = "";
                   
                }

            }

           




        }


        else if (hitInfo.transform.name == "PortalMesh")
        {


            interactionUI.GetComponent<Text>().text = "차원의 균열로 들어가기";

            //그 상태에서 마우스 왼쪽버튼을 클릭하면
            if (Input.GetMouseButtonDown(0)) //0이 마우스 왼쪽. 1이 마우스 오른쪽
            {

                PollenOfLight.SetActive(true);
                interactionUI.GetComponent<Text>().text = "";
                Debug.Log("click portal");


                StartCoroutine("FadeOut");




            }

        }



        //시간나면 빛의 꽃가루 넣지 않았을때 "꺼져있다" UI 출력하는 기능 추가.



    }


    IEnumerator FadeOut() 
    {

        fadeout.SetActive(true);
        yield return new WaitForSeconds(5f);
        fadeout.SetActive(false);
        SceneManagement.completedStage = 13;
        sm13.movetoNextStage();


    }
}



    





        

    




   




