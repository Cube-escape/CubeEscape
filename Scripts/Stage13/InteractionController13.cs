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
    [SerializeField] GameObject[] mark_hided; //������ ��ũ
    [SerializeField] GameObject[] mark_showed; //�߾ӿ� �������� �ߴ� ��ũ
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

        interactionUI.GetComponent<Text>().text = "";



    }

    void showEvent()
    {
        if (hitInfo.transform.name == "mark_white1")
        {


            interactionUI.GetComponent<Text>().text = "���� ������";

            //�� ���¿��� ���콺 ���ʹ�ư�� Ŭ���ϸ�
            if (Input.GetMouseButtonDown(0) && mark_showed[0].activeInHierarchy) //0�� ���콺 ����. 1�� ���콺 ������
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

            interactionUI.GetComponent<Text>().text = "���� ������";


            //�� ���¿��� ���콺 ���ʹ�ư�� Ŭ���ϸ�
            if (Input.GetMouseButtonDown(0) && mark_showed[1].activeInHierarchy) //0�� ���콺 ����. 1�� ���콺 ������
            {

                interactionUI.GetComponent<Text>().text = "";


                hitInfo.transform.gameObject.SetActive(false);
                soundEffect.clip = effects[0];
                soundEffect.Play(); //������ ��ȭ�� �Ͼ�ٴ°� �˷��ִ� ȿ����
                mark_showed[1].SetActive(false);
                mark_showed[2].SetActive(true);
                

                Debug.Log("click mark2");




            }


        }


        else if (hitInfo.transform.name == "mark_white3")
        {


            interactionUI.GetComponent<Text>().text = "���� ������";

            //�� ���¿��� ���콺 ���ʹ�ư�� Ŭ���ϸ�
            if (Input.GetMouseButtonDown(0) && mark_showed[2].activeInHierarchy) //0�� ���콺 ����. 1�� ���콺 ������
            {

                hitInfo.transform.gameObject.SetActive(false);
                soundEffect.clip = effects[0];
                soundEffect.Play(); //������ ��ȭ�� �Ͼ�ٴ°� �˷��ִ� ȿ����
                mark_showed[2].SetActive(false);
                mark_showed[3].SetActive(true);
                
                interactionUI.GetComponent<Text>().text = "";
                Debug.Log("click mark3");




            }


        }



        else if (hitInfo.transform.name == "mark_white4")
        {


            interactionUI.GetComponent<Text>().text = "���� ������";

            //�� ���¿��� ���콺 ���ʹ�ư�� Ŭ���ϸ�
            if (Input.GetMouseButtonDown(0) && mark_showed[3].activeInHierarchy) //0�� ���콺 ����. 1�� ���콺 ������
            {

                hitInfo.transform.gameObject.SetActive(false);
                soundEffect.clip = effects[0];
                soundEffect.Play(); //������ ��ȭ�� �Ͼ�ٴ°� �˷��ִ� ȿ����
                mark_showed[3].SetActive(false);
                mark_showed[4].SetActive(true);
                interactionUI.GetComponent<Text>().text = "";
                Debug.Log("click mark4");



            }

        }


        else if (hitInfo.transform.name == "mark_white5")
        {


            interactionUI.GetComponent<Text>().text = "���� ������";

            //�� ���¿��� ���콺 ���ʹ�ư�� Ŭ���ϸ�
            if (Input.GetMouseButtonDown(0) && mark_showed[4].activeInHierarchy) //0�� ���콺 ����. 1�� ���콺 ������
            {

                hitInfo.transform.gameObject.SetActive(false);
                mark_showed[4].SetActive(false);
                soundEffect.clip = effects[1];
                soundEffect.Play(); // ��� ������ Ŭ�������� ȿ����
                interactionUI.GetComponent<Text>().text = "";
                Debug.Log("click mark5");
                Stage13Gamemanager.isAllMarkClicked = true;




            }



        }

        else if (hitInfo.transform.name == "Letter")
        {


            interactionUI.GetComponent<Text>().text = "�ڼ�������";

            //�� ���¿��� ���콺 ���ʹ�ư�� Ŭ���ϸ�
            if (Input.GetMouseButtonDown(0)) //0�� ���콺 ����. 1�� ���콺 ������
            {

                Letter.SetActive(true);
                interactionUI.GetComponent<Text>().text = "";
                Debug.Log("click letter");



            }

        }

        //���� �۾��ִ°����� �����ߴٸ�.

        else if (hitInfo.transform.name == "ButterflyMesh")
        {


            interactionUI.GetComponent<Text>().text = "���� �ɰ��� ä���ϱ�";

            //�� ���¿��� ���콺 ���ʹ�ư�� Ŭ���ϸ�
            if (Input.GetMouseButtonDown(0)) //0�� ���콺 ����. 1�� ���콺 ������
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

            if (lightinf.GetPollenOfLight == false) //���� �ɰ��縦 ���� �ֱ� ���϶���
            {
                interactionUI.GetComponent<Text>().text = "���� �ɰ��� �ֱ�";

                //�� ���¿��� ���콺 ���ʹ�ư�� Ŭ���ϸ�
                if (Input.GetMouseButtonDown(0)) //0�� ���콺 ����. 1�� ���콺 ������
                {
                    soundEffect.clip = effects[3];
                    soundEffect.Play();
                    hitInfo.transform.gameObject.GetComponent<Lightinf>().enabled = true; //������ġ ����

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

            if (lightinf.GetPollenOfLight == false) //���� �ɰ��縦 ���� �ֱ� ���϶���
            {
                interactionUI.GetComponent<Text>().text = "�����ִ�.";

                //�� ���¿��� ���콺 ���ʹ�ư�� Ŭ���ϸ�
                if (Input.GetMouseButtonDown(0)) //0�� ���콺 ����. 1�� ���콺 ������
                {

                    interactionUI.GetComponent<Text>().text = "";
                   
                }

            }

           




        }


        else if (hitInfo.transform.name == "PortalMesh")
        {


            interactionUI.GetComponent<Text>().text = "������ �տ��� ����";

            //�� ���¿��� ���콺 ���ʹ�ư�� Ŭ���ϸ�
            if (Input.GetMouseButtonDown(0)) //0�� ���콺 ����. 1�� ���콺 ������
            {

                PollenOfLight.SetActive(true);
                interactionUI.GetComponent<Text>().text = "";
                Debug.Log("click portal");


                StartCoroutine("FadeOut");




            }

        }



        //�ð����� ���� �ɰ��� ���� �ʾ����� "�����ִ�" UI ����ϴ� ��� �߰�.



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



    





        

    




   




