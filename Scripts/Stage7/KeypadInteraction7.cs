using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeypadInteraction7 : MonoBehaviour

{

    [SerializeField] GameObject keypadUI;
    private string answer;

    RaycastHit hitInfo;

    [SerializeField] int sizeofLazer = 30;
    [SerializeField] GameObject player;
    [SerializeField] GameObject mc;
    [SerializeField] GameObject ment;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * sizeofLazer, Color.red);

        if (Physics.Raycast(ray, out hitInfo, sizeofLazer) && hitInfo.transform.CompareTag("interaction")) //어떤 콜라이더와 레이가 충돌했으면 true, 아니면 false. // hitinfo 는 ray에 맞은 객체의 정보를 저장하는 변수


        {

            Debug.Log(hitInfo.transform.name);// 레이저에 닿은 사물의 이름 출력.
            if(hitInfo.transform.name == "keypad")
            {
                ment.GetComponent<Text>().text = "비밀번호를 입력한다.";
                if (Input.GetMouseButton(0))
                {


                    keypadUI.SetActive(true);


                    Cursor.lockState = CursorLockMode.None;



                    //player.GetComponent<MovePlayer_addjump>().enabled = false;
                    mc.GetComponent<MoveCamera>().enabled = false;




                }
            }
        }



       
        
            
        }

    }

