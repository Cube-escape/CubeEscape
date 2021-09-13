using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionController_stage7 : MonoBehaviour
{
    [SerializeField] Camera cam;

    RaycastHit hitInfo;

    [SerializeField] int sizeofLazer = 30;

    [SerializeField] GameObject[] interactionUI;
    [SerializeField] GameObject[] keypadUI;
    [SerializeField] GameObject keypad;
    [SerializeField] GameObject Player;
    [SerializeField] InputField inputfield;
        



    public bool iskeypadClicked = false;




    // Start is called before the first frame update
    void Start()
    {

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

        for (int i = 0; i < interactionUI.Length; i++)
        {
            interactionUI[0].GetComponent<Text>().text = "";
        }


    }

    void showEvent()
    {
        if (hitInfo.transform.name == "keypad") 
        {

          


            //그 상태에서 마우스 왼쪽버튼을 클릭하면
            if (Input.GetMouseButton(0)) //0이 마우스 왼쪽. 1이 마우스 오른쪽
            {

                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("keypad clicked");

                iskeypadClicked = true;

                inputfield.gameObject.SetActive(true);

                GameObject.Find("Player").GetComponent<MovePlayer>().enabled = false;
                GameObject.Find("Main Camera").GetComponent<MoveCamera>().enabled = false;

            }

        }





    }
}
