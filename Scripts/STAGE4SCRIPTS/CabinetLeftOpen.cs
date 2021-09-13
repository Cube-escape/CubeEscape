using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CabinetLeftOpen : MonoBehaviour
{
    public float Speed = 5f;
    public bool open = false;
    public bool open2 = false;
    public GameObject arm;
    AudioSource audiosource;
    AudioSource audiosource2;

    GameObject obj;
    void Awake()
    {
        audiosource = GetComponent<AudioSource>();
        audiosource2 = GameObject.Find("Body").GetComponent<AudioSource>();
        obj = GameObject.Find("DoorLeftGrp");

    }

    void OnMouseDown()
    {

        audiosource2.Play();
        if (arm.transform.childCount == 1) //�ε��� ������ ���� ��
        {
            if (arm.transform.GetChild(0).name == "Key")//�ڽ��� Ű�� ��
            {
                if (open2 == false)//�ȿ����� �� Ű�� ��� �õ��ϸ�?
                {
                    audiosource.Play();
                    Quaternion targetRotation = Quaternion.Euler(0, 90, 0);
                    obj.transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, 90);
                    open2 = true;
                    open = true; //�� �� Ű�� ���� Ű�� ��� ���� ���ִ� ��ġ?

                }
                else if (open2 == true) //������ �� Ű�� ��� �ݴ´�.
                {
                    audiosource.Play();
                    Quaternion targetRotation = Quaternion.Euler(0, 0, 0);
                    obj.transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, 90);
                    open2 = false;

                }
            }
            else if (open == true)
            {
                if (open2 == false)
                {
                    audiosource.Play();
                    Quaternion targetRotation = Quaternion.Euler(0, 90, 0);
                    obj.transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, 90);
                    open2 = true;

                }
                else if (open2 == true)
                {
                    audiosource.Play();
                    Quaternion targetRotation = Quaternion.Euler(0, 0, 0);
                    obj.transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, 90);
                    open2 = true;

                }
            }
        }
        else
        {
            if (open == true)
            {
                if (open2 == false)
                {
                    audiosource.Play();
                    Quaternion targetRotation = Quaternion.Euler(0, 90, 0);
                    obj.transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, 90);
                    open2 = true;
                }
                else if (open2 == true)
                {
                    audiosource.Play();
                    Quaternion targetRotation = Quaternion.Euler(0, 0, 0);
                    obj.transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, 90);
                    open2 = false;
                }
            }
        }//Ű�� �̹� ���� ���� ������ ��
    }







}
