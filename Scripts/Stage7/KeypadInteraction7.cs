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

        if (Physics.Raycast(ray, out hitInfo, sizeofLazer) && hitInfo.transform.CompareTag("interaction")) //� �ݶ��̴��� ���̰� �浹������ true, �ƴϸ� false. // hitinfo �� ray�� ���� ��ü�� ������ �����ϴ� ����


        {

            Debug.Log(hitInfo.transform.name);// �������� ���� �繰�� �̸� ���.
            if(hitInfo.transform.name == "keypad")
            {
                ment.GetComponent<Text>().text = "��й�ȣ�� �Է��Ѵ�.";
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

