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
        if (arm.transform.childCount == 1) //인덱스 때문에 붙인 거
        {
            if (arm.transform.GetChild(0).name == "Key")//자식이 키일 때
            {
                if (open2 == false)//안열렸을 때 키를 들고 시도하면?
                {
                    audiosource.Play();
                    Quaternion targetRotation = Quaternion.Euler(0, 90, 0);
                    obj.transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, 90);
                    open2 = true;
                    open = true; //한 번 키로 열면 키가 없어도 열게 해주는 장치?

                }
                else if (open2 == true) //열렸을 때 키를 들고 닫는다.
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
        }//키로 이미 열고 문을 여닫을 때
    }







}
