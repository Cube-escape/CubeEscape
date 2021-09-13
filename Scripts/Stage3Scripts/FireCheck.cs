using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCheck : MonoBehaviour
{

    [SerializeField] Transform arm;
    [SerializeField] GameObject FirecheckUI;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject cam;
    [SerializeField] AudioSource fire;


    SceneManagement sm3 = new SceneManagement();
    

    // Start is called before the first frame update
    public void FireCheckBtn(){

        if (this.gameObject.name == "yes")

        {

            if (arm.GetChild(0).gameObject.name == "clock" || arm.GetChild(0).gameObject.name == "sock" || arm.GetChild(0).gameObject.name == "��������")
            {
                //�¿�� ȿ���� ���.
                fire.Play();
                arm.GetChild(0).transform.gameObject.SetActive(false);//�¿ü ��Ȱ��ȭ
                arm.GetChild(0).parent = null; //��Ӱ��� ����
                FirecheckUI.SetActive(false);//UI����
                Cursor.lockState = CursorLockMode.Locked; //Ŀ�����.
                Player.GetComponent<MovePlayer>().enabled = true; //ī�޶�����̱� Ȱ��ȭ.
                cam.GetComponent<MoveCamera>().enabled = true; //�÷��̾� �����̱� Ȱ��ȭ.
                Debug.Log("�ùٸ��� �¿�.");
            }

            else
            {
                Debug.Log("�̻��Ѱ� �¿�.");


                sm3.gameover(3);
            }
           
        }

        else
        {
            FirecheckUI.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked; //Ŀ�����.
            Player.GetComponent<MovePlayer>().enabled = true; //ī�޶�����̱� Ȱ��ȭ.
            cam.GetComponent<MoveCamera>().enabled = true; //�÷��̾� �����̱� Ȱ��ȭ.

        }

    }

    public void YesBtn()
    {
        if (arm.GetChild(0).gameObject.name == "clock" || arm.GetChild(0).gameObject.name == "sock" || arm.GetChild(0).gameObject.name == "��������")
        {
            //�¿�� ȿ���� ���.
            fire.Play();
            arm.GetChild(0).transform.gameObject.SetActive(false);//�¿ü ��Ȱ��ȭ
            arm.GetChild(0).parent = null; //��Ӱ��� ����
            FirecheckUI.SetActive(false);//UI����
            Cursor.lockState = CursorLockMode.Locked; //Ŀ�����.
            Player.GetComponent<MovePlayer>().enabled = true; //ī�޶�����̱� Ȱ��ȭ.
            cam.GetComponent<MoveCamera>().enabled = true; //�÷��̾� �����̱� Ȱ��ȭ.
            Debug.Log("�ùٸ��� �¿�.");
        }

        else
        {
            Debug.Log("�̻��Ѱ� �¿�.");


            sm3.gameover(3);
        }
    }
    
    public void NoBtn()
    {
        FirecheckUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked; //Ŀ�����.
        Player.GetComponent<MovePlayer>().enabled = true; //ī�޶�����̱� Ȱ��ȭ.
        cam.GetComponent<MoveCamera>().enabled = true; //�÷��̾� �����̱� Ȱ��ȭ.
    }
}


