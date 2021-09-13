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


        if (Physics.Raycast(ray, out hitInfo, sizeofLazer) && hitInfo.transform.CompareTag("interaction")) //� �ݶ��̴��� ���̰� �浹������ true, �ƴϸ� false. // hitinfo �� ray�� ���� ��ü�� ������ �����ϴ� ����


        {

            Contact();
            Debug.Log(hitInfo.transform.name);// �������� ���� �繰�� �̸� ���.
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

    void showEvent()
    {
        if (hitInfo.transform.name == "keypad") 
        {

          


            //�� ���¿��� ���콺 ���ʹ�ư�� Ŭ���ϸ�
            if (Input.GetMouseButton(0)) //0�� ���콺 ����. 1�� ���콺 ������
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
