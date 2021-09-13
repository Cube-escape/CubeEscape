using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    Animation ani;
    AudioSource elevator;
    bool b1;
    bool b2;
    public GameObject player;


    void Start()
    {
        ani = this.GetComponent<Animation>();
        elevator = this.GetComponent<AudioSource>();
        b1 = true;
        b2 = true;
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(UnityEngine.Collider other)
    {

        if (other.name == "Player" && !elevator.isPlaying && b1)
        {
            player.transform.parent = this.gameObject.transform; //�÷��̾ ���������Ϳ� ���

            player.transform.localPosition = new Vector3(0, 3, 0);//�÷��̾ ���������� �� ����� �̵�

            player.GetComponent<MovePlayer>().enabled = false; //�÷��̾� ������ ����
            Debug.Log("�÷��̾ ���������Ϳ� �浹");
            ani.Play("elevator");
            elevator.Play();
            b1 = false; //�ѹ��� ����ϵ���


        }


    }

    private void OnTriggerStay(UnityEngine.Collider other)
    {
        if (other.name == "Player" && !elevator.isPlaying && b2) //���������� �ִϸ��̼� ����� ��ġ��
        {
            Debug.Log("���������� ����");
            player.GetComponent<MovePlayer>().enabled = true; //�÷��̾� ������ Ǯ��
            player.transform.parent = null; //�������
            b2 = false; //����ȭ ����
        }



    }
}
