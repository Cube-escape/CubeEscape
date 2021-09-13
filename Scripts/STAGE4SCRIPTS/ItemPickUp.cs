using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    //arm�� player�� �� �κ� (�ű� �������� ���̴� �κ�)
    public Transform arm;
    AudioSource audiosource;
    void OnMouseDown()
    {
        audiosource.Play();
        if (arm.transform.childCount == 0) // ���࿡ �������� ���� ���콺�� ������ arm�� �ڽĿ�����Ʈ�� ������ 0�̸�
        {
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().isKinematic = true;
            //���õ� �����ۿ� �߷��� ���ּ�

            this.transform.parent = GameObject.Find("Arm").transform; //�׸��� �� �������� �� ������Ʈ�� ��ӽ�Ų��.
            this.transform.localPosition = this.transform.parent.position; //�ȿ��� ���δ�.
        }
    }
    // Update is called once per frame
    void Update()
    {
       
        
        if (Input.GetMouseButtonDown(1)) { //������ ���콺�� ������
            GetComponent<Rigidbody>().useGravity = true;

            GetComponent<Rigidbody>().isKinematic = false;
            this.transform.parent = null; // �θ� ����
            
            
             
        }
        
    }
    private void Start()
    {
        audiosource = arm.GetComponent<AudioSource>();        
    }

} 
