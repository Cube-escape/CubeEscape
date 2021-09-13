using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactioncontroller3 : MonoBehaviour
{


    [SerializeField] Camera cam;

    RaycastHit hitInfo;

    [SerializeField] int sizeofLazer = 10;

    [SerializeField] GameObject[] interactionUI;

    [SerializeField] GameObject noticeUI;

    [SerializeField] GameObject fireCheckUI; //�¿�ðڽ��ϱ�?

    [SerializeField] private Transform arm;

    [SerializeField] GameObject diary1;

    [SerializeField] GameObject diary2;

    [SerializeField] GameObject SecretBox;
 
    [SerializeField] Stage3Gamemanager gm3;

    [SerializeField] GameObject Player;
    [SerializeField] GameObject News;
    [SerializeField] InputField inputfield;





    // Update is called once per frame
    void Update()
    {
        

        CheckObject();
        Debug.Log(arm.transform.childCount);

        if (arm.transform.childCount == 1 && Input.GetMouseButtonDown(1))
        {
            arm.transform.GetComponentInChildren<Rigidbody>().useGravity = true;
            arm.transform.GetComponentInChildren<Rigidbody>().isKinematic = false;
            arm.GetChild(0).parent = null;
        }

       
    }

    void CheckObject()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));



        Debug.DrawRay(ray.origin, ray.direction * sizeofLazer, Color.red);


        if (Physics.Raycast(ray, out hitInfo, sizeofLazer)&&hitInfo.transform.CompareTag("interaction")) //� �ݶ��̴��� ���̰� �浹������ true, �ƴϸ� false. // hitinfo �� ray�� ���� ��ü�� ������ �����ϴ� ����


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
        
       /* if (hitInfo.transform.name == "girl" && arm.transform.childCount == 0 &&!gm3.isSecretBoxUnlocked)
        {
            interactionUI[0].GetComponent<Text>().text = "�ҳ࿡�� ���ɱ�";

            if (Input.GetMouseButtonDown(0))
            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click girl");

                int r = Random.Range(0, 2);
                if (r==1)
                StartCoroutine("sayingMerryChristmas");
                else
                StartCoroutine("sayingHello");
               
              


            }
        }
       */

        if (hitInfo.transform.name == "girl" && arm.transform.childCount == 0 )
        {
            interactionUI[0].GetComponent<Text>().text = "�ҳ࿡�� ���ɱ�";

            if (Input.GetMouseButtonDown(0))
            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click girl");

                    StartCoroutine("fireAll"); //�ҳ� ��ȭ ver.
               




            }
        }




       else if (hitInfo.transform.name == "girl" && arm.transform.childCount == 1)
        {
            interactionUI[0].GetComponent<Text>().text = "�ҳ࿡�� �ǳױ�";

            if (Input.GetMouseButtonDown(0))
            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("");

                //�ҳ࿡�� �ǳ� ������ ������ ���� UI�ٸ��� ����.

                if (arm.transform.GetChild(0).name == "clock")
                    StartCoroutine("sayingAboutClock");

                else if (arm.transform.GetChild(0).name == "sock")
                    StartCoroutine("sayingAboutSock");

                else if (arm.transform.GetChild(0).name == "��������")
                    StartCoroutine("sayingAboutFamilypicture");

                else
                    StartCoroutine("noCare");
            }
        }




        else if (hitInfo.transform.name == "diary1")
        {
            interactionUI[0].GetComponent<Text>().text = "�ϱ��� �ڼ�������";

            if (Input.GetMouseButtonDown(0))
            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("");

                diary1.SetActive(true);
            }


        }
        else if (hitInfo.transform.name == "diary2")
        {
            interactionUI[0].GetComponent<Text>().text = "�ϱ��� �ڼ�������";

            if (Input.GetMouseButtonDown(0))
            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("");

                diary2.SetActive(true);
            }


        }

       


        else if (hitInfo.transform.name == "Teddybear" && arm.transform.childCount == 0&& Stage3Gamemanager.isNewsviewed)
        {
            interactionUI[0].GetComponent<Text>().text = "������ ���";

            if (Input.GetMouseButtonDown(0))
            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click Teddybear");

                hitInfo.transform.GetComponent<Rigidbody>().useGravity = false; // gravity�� ����.
                hitInfo.transform.GetComponent<Rigidbody>().isKinematic = true; // kinematic�� �Ѹ� ��ũ��Ʈ�� ���ؼ��� �����δ�. ������ �տ� ������ �� ���� ���׿� ���� ���ۺ��� ���� �ʵ��� �ϱ� ���� �ʿ��ϴ�. 
                hitInfo.transform.position = arm.position; // �ȷ� �����ص� ��ġ�� �̵���Ų��.
                hitInfo.transform.parent = GameObject.Find("Arm").transform; // ���� child�� �־��ش�.
              
            }
        }

        else if (hitInfo.transform.name == "TTbox" && arm.transform.childCount == 0 && Stage3Gamemanager.isNewsviewed)
        {
            interactionUI[0].GetComponent<Text>().text = "TT�������� ���";

            if (Input.GetMouseButtonDown(0))
            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click TTbox");

                hitInfo.transform.GetComponent<Rigidbody>().useGravity = false; // gravity�� ����.
                hitInfo.transform.GetComponent<Rigidbody>().isKinematic = true; // kinematic�� �Ѹ� ��ũ��Ʈ�� ���ؼ��� �����δ�. ������ �տ� ������ �� ���� ���׿� ���� ���ۺ��� ���� �ʵ��� �ϱ� ���� �ʿ��ϴ�. 
                hitInfo.transform.position = arm.position; // �ȷ� �����ص� ��ġ�� �̵���Ų��.
                hitInfo.transform.parent = GameObject.Find("Arm").transform; // ���� child�� �־��ش�.
               
            }
        }

        else if (hitInfo.transform.name == "clock" && arm.transform.childCount == 0 &&Stage3Gamemanager.isNewsviewed)
        {
            interactionUI[0].GetComponent<Text>().text = "�ð� �����";

            if (Input.GetMouseButtonDown(0))
            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click clock");

                hitInfo.transform.GetComponent<Rigidbody>().useGravity = false; // gravity�� ����.
                hitInfo.transform.GetComponent<Rigidbody>().isKinematic = true; // kinematic�� �Ѹ� ��ũ��Ʈ�� ���ؼ��� �����δ�. ������ �տ� ������ �� ���� ���׿� ���� ���ۺ��� ���� �ʵ��� �ϱ� ���� �ʿ��ϴ�. 
                hitInfo.transform.position = arm.position; // �ȷ� �����ص� ��ġ�� �̵���Ų��.
                hitInfo.transform.parent = GameObject.Find("Arm").transform; // ���� child�� �־��ش�.

            }
        }


        else if (hitInfo.transform.name == "giftbox" && arm.transform.childCount == 0 && Stage3Gamemanager.isNewsviewed)
        {
            interactionUI[0].GetComponent<Text>().text = "�������� ���";

            if (Input.GetMouseButtonDown(0))
            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click giftbox");

                hitInfo.transform.GetComponent<Rigidbody>().useGravity = false; // gravity�� ����.
                hitInfo.transform.GetComponent<Rigidbody>().isKinematic = true; // kinematic�� �Ѹ� ��ũ��Ʈ�� ���ؼ��� �����δ�. ������ �տ� ������ �� ���� ���׿� ���� ���ۺ��� ���� �ʵ��� �ϱ� ���� �ʿ��ϴ�. 
                hitInfo.transform.position = arm.position; // �ȷ� �����ص� ��ġ�� �̵���Ų��.
                hitInfo.transform.parent = GameObject.Find("Arm").transform; // ���� child�� �־��ش�.
               
            }
        }

        else if (hitInfo.transform.name == "Candle" && arm.transform.childCount == 0 && Stage3Gamemanager.isNewsviewed)
        {
            interactionUI[0].GetComponent<Text>().text = "���� ���";

            if (Input.GetMouseButtonDown(0))
            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click candle");


                hitInfo.transform.GetComponent<Rigidbody>().useGravity = false; // gravity�� ����.
                hitInfo.transform.GetComponent<Rigidbody>().isKinematic = true; // kinematic�� �Ѹ� ��ũ��Ʈ�� ���ؼ��� �����δ�. ������ �տ� ������ �� ���� ���׿� ���� ���ۺ��� ���� �ʵ��� �ϱ� ���� �ʿ��ϴ�. 
                hitInfo.transform.position = arm.position; // �ȷ� �����ص� ��ġ�� �̵���Ų��.
                hitInfo.transform.parent = GameObject.Find("Arm").transform; // ���� child�� �־��ش�.
              
            }
        }




        else if (hitInfo.transform.name == "��������" && arm.transform.childCount == 0 && Stage3Gamemanager.isNewsviewed)
        {
            interactionUI[0].GetComponent<Text>().text = "��������  �����";

            if (Input.GetMouseButtonDown(0))
            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click family picture");

                hitInfo.transform.GetComponent<Rigidbody>().useGravity = false; // gravity�� ����.
                hitInfo.transform.GetComponent<Rigidbody>().isKinematic = true; // kinematic�� �Ѹ� ��ũ��Ʈ�� ���ؼ��� �����δ�. ������ �տ� ������ �� ���� ���׿� ���� ���ۺ��� ���� �ʵ��� �ϱ� ���� �ʿ��ϴ�. 
                hitInfo.transform.position = arm.position; // �ȷ� �����ص� ��ġ�� �̵���Ų��.
                hitInfo.transform.parent = GameObject.Find("Arm").transform; // ���� child�� �־��ش�.
                hitInfo.transform.GetComponent<Transform>().localRotation = Quaternion.Euler(0f, -29f, 0f); // �ո��� ���̵��� ȸ�� ������ ���� 0���� �����ش�.
               




            }
        }

        else if (hitInfo.transform.name == "sock" && arm.transform.childCount == 0 && Stage3Gamemanager.isNewsviewed)
        {
            interactionUI[0].GetComponent<Text>().text = "��Ÿ�縻 �����";

            if (Input.GetMouseButtonDown(0))
            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click sock");

                hitInfo.transform.GetComponent<Rigidbody>().useGravity = false; // gravity�� ����.
                hitInfo.transform.GetComponent<Rigidbody>().isKinematic = true; // kinematic�� �Ѹ� ��ũ��Ʈ�� ���ؼ��� �����δ�. ������ �տ� ������ �� ���� ���׿� ���� ���ۺ��� ���� �ʵ��� �ϱ� ���� �ʿ��ϴ�. 
                hitInfo.transform.position = arm.position; // �ȷ� �����ص� ��ġ�� �̵���Ų��.
                hitInfo.transform.parent = GameObject.Find("Arm").transform; // ���� child�� �־��ش�.
               
                


            }
        }


        else if (hitInfo.transform.name == "SecretBox" && arm.transform.childCount == 0 && Stage3Gamemanager.isNewsviewed)
        {
            interactionUI[0].GetComponent<Text>().text = "��л��� ���빰 ����";

            if (Input.GetMouseButtonDown(0))
            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click secret box");
                News.SetActive(true);




            }
        }
        else if (hitInfo.transform.name == "SecretBox" && arm.transform.childCount == 0 && Stage3Gamemanager.isSecretBoxUnlocked)
        {
            interactionUI[0].GetComponent<Text>().text = "��л��� ���빰 ����";

            if (Input.GetMouseButtonDown(0))
            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click secret box");
                Stage3Gamemanager.isNewsviewed = true;



            }
        }




     
        else if (hitInfo.transform.name == "SecretBox" && arm.transform.childCount == 0 && !Stage3Gamemanager.isSecretBoxUnlocked)
        {
            interactionUI[0].GetComponent<Text>().text = "��л��� ��� �����ϱ�.";

            if (Input.GetMouseButtonDown(0))
            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click secret box");

                inputfield.gameObject.SetActive(true);


                GameObject.Find("Player").GetComponent<MovePlayer>().enabled = false;
                GameObject.Find("Main Camera").GetComponent<MoveCamera>().enabled = false;



            }
        }



        else if (hitInfo.transform.name == "Gingerbread" && arm.transform.childCount == 0)
        {
            interactionUI[0].GetComponent<Text>().text = "��Ű�Ա�";

            if (Input.GetMouseButtonDown(0))
            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("eat cookie");
                hitInfo.transform.gameObject.SetActive(false);

                StartCoroutine("eat_cookie");



            }
        }



        else if (hitInfo.transform.name == "Santa_Hat" && arm.transform.childCount == 0 && Stage3Gamemanager.isNewsviewed)
        {
            interactionUI[0].GetComponent<Text>().text = "��Ÿ���� ����";

            if (Input.GetMouseButtonDown(0))
            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click santa_hat");

                hitInfo.transform.GetComponent<Rigidbody>().useGravity = false; // gravity�� ����.
                hitInfo.transform.GetComponent<Rigidbody>().isKinematic = true; // kinematic�� �Ѹ� ��ũ��Ʈ�� ���ؼ��� �����δ�. ������ �տ� ������ �� ���� ���׿� ���� ���ۺ��� ���� �ʵ��� �ϱ� ���� �ʿ��ϴ�. 
                hitInfo.transform.position = arm.position; // �ȷ� �����ص� ��ġ�� �̵���Ų��.
                hitInfo.transform.parent = GameObject.Find("Arm").transform; // ���� child�� �־��ش�.
           

            }
        }


        else if (hitInfo.transform.name == "Candy_Cane" && arm.transform.childCount == 0 && Stage3Gamemanager.isNewsviewed)
        {
            interactionUI[0].GetComponent<Text>().text = "���������� ���";

            if (Input.GetMouseButtonDown(0))
            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click candy_cane");

                hitInfo.transform.GetComponent<Rigidbody>().useGravity = false; // gravity�� ����.
                hitInfo.transform.GetComponent<Rigidbody>().isKinematic = true; // kinematic�� �Ѹ� ��ũ��Ʈ�� ���ؼ��� �����δ�. ������ �տ� ������ �� ���� ���׿� ���� ���ۺ��� ���� �ʵ��� �ϱ� ���� �ʿ��ϴ�. 
                hitInfo.transform.position = arm.position; // �ȷ� �����ص� ��ġ�� �̵���Ų��.
                hitInfo.transform.parent = GameObject.Find("Arm").transform; // ���� child�� �־��ش�.
               


            }
        }





        else if (hitInfo.transform.name == "fireplace" && arm.transform.childCount == 0 && !Stage3Gamemanager.isNewsviewed)
        {
            interactionUI[0].GetComponent<Text>().text = "������ �����ϱ�";

            if (Input.GetMouseButtonDown(0))
            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("explain_original_ fireplace");
                
                StartCoroutine("explain_fireplace");
            }
        }

        else if (hitInfo.transform.name == "fireplace" && arm.transform.childCount == 0&& Stage3Gamemanager.isNewsviewed)
        {
            interactionUI[0].GetComponent<Text>().text = "������ �����ϱ�";

            if (Input.GetMouseButtonDown(0))
            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("explain_changed_ fireplace");

                StartCoroutine("explain_changed_fireplace");
            }
        }

        else if (hitInfo.transform.name == "fireplace" && arm.transform.childCount == 1 && Stage3Gamemanager.isNewsviewed)
        {
            interactionUI[0].GetComponent<Text>().text = "�����ο� �¿��";

            if (Input.GetMouseButtonDown(0))
            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click fireplace");

                Cursor.lockState = CursorLockMode.None;
                fireCheckUI.SetActive(true);
                Player.GetComponent<MovePlayer>().enabled = false; //ī�޶�����̱� ��Ȱ��ȭ.
                cam.GetComponent<MoveCamera>().enabled = false; //�÷��̾� �����̱� ��Ȱ��ȭ.  

            }
        }

    }



    IEnumerator explain_changed_fireplace()
    {
        noticeUI.SetActive(true);
        noticeUI.GetComponentInChildren<Text>().text = "���� ȰȰ Ÿ������ �������̴�. ���𰡸� �¿�� ������ ����.";
        yield return new WaitForSeconds(2f);
        noticeUI.SetActive(false);
    }

    IEnumerator explain_fireplace()
    {
        noticeUI.SetActive(true);
        noticeUI.GetComponentInChildren<Text>().text = "������ ���̴� �������̴�. ���� �����ϰ� Ÿ������.";
        yield return new WaitForSeconds(2f);
        noticeUI.SetActive(false);
    }

    IEnumerator eat_cookie()
    {
        noticeUI.SetActive(true);
        noticeUI.GetComponentInChildren<Text>().text = "�ȳȳ� ���־�";
        yield return new WaitForSeconds(2f);
        noticeUI.SetActive(false);
    }


    IEnumerator sayingAboutClock()
    {
        noticeUI.SetActive(true);
        noticeUI.GetComponentInChildren<Text>().text = "�װ� ���� ����� �̻���. �ð��� �帣�� �ʾ�. �� �׷���? ���� ���� �ʾ�! �����ϰ� ���� �ʾ�!";
        yield return new WaitForSeconds(2f);
        noticeUI.SetActive(false);
    }


    IEnumerator sayingAboutSock()
    {
        noticeUI.SetActive(true);
        
        noticeUI.GetComponentInChildren<Text>().text = "ũ�������� ��ħ�� �޾� ����! ������? ������ ����! �ٵ� �θ���� ��� �����? ����! ����, ��� �־�䡦? ����! ... ��� �����ϼ̳���.";
       
        yield return new WaitForSeconds(2f);
        noticeUI.SetActive(false);
       
    }

    IEnumerator sayingAboutFamilypicture()
    {
        noticeUI.SetActive(true);
        noticeUI.GetComponentInChildren<Text>().text = "���� ũ�������� ������ �׸��ž�. �ູ�غ����� �ʾ�? ����...�ƺ�... ��ε�... ";
        yield return new WaitForSeconds(2f);
        noticeUI.SetActive(false);

    }

    IEnumerator noCare()
    {
        noticeUI.SetActive(true);
        noticeUI.GetComponentInChildren<Text>().text = "...";
        yield return new WaitForSeconds(2f);
        noticeUI.SetActive(false);
    }

    IEnumerator sayingHello()
    {

        noticeUI.SetActive(true);
        noticeUI.GetComponentInChildren<Text>().text = "�ȳ�! �������� ����̳�? ���� ��հ� ����!";
        yield return new WaitForSeconds(2f);
        noticeUI.SetActive(false);

    }

    IEnumerator sayingMerryChristmas()
    {

        noticeUI.SetActive(true);
        noticeUI.GetComponentInChildren<Text>().text = "������ �ϳ⿡ �ѹ����� Ư���� ũ��������!";
        yield return new WaitForSeconds(2f);
        noticeUI.SetActive(false);

    }

    IEnumerator fireAll()
    {

        noticeUI.SetActive(true);
        noticeUI.GetComponentInChildren<Text>().text = "������ �͵��� ��� ���¿���������.";
        yield return new WaitForSeconds(2f);
        noticeUI.SetActive(false);

    }



}








