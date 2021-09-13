using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    //arm은 player의 팔 부분 (옮길 아이템을 붙이는 부분)
    public Transform arm;
    AudioSource audiosource;
    void OnMouseDown()
    {
        audiosource.Play();
        if (arm.transform.childCount == 0) // 만약에 아이템을 왼쪽 마우스로 누르고 arm의 자식오브젝트의 개수가 0이면
        {
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().isKinematic = true;
            //선택된 아이템에 중력을 없애서

            this.transform.parent = GameObject.Find("Arm").transform; //그리고 그 아이템을 팔 오브젝트에 상속시킨다.
            this.transform.localPosition = this.transform.parent.position; //팔에다 붙인다.
        }
    }
    // Update is called once per frame
    void Update()
    {
       
        
        if (Input.GetMouseButtonDown(1)) { //오른쪽 마우스를 누르면
            GetComponent<Rigidbody>().useGravity = true;

            GetComponent<Rigidbody>().isKinematic = false;
            this.transform.parent = null; // 부모를 없앰
            
            
             
        }
        
    }
    private void Start()
    {
        audiosource = arm.GetComponent<AudioSource>();        
    }

} 
