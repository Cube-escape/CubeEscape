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
            player.transform.parent = this.gameObject.transform; //플레이어를 엘리베이터에 상속

            player.transform.localPosition = new Vector3(0, 3, 0);//플레이어를 엘리베이터 한 가운데로 이동

            player.GetComponent<MovePlayer>().enabled = false; //플레이어 움직임 막기
            Debug.Log("플레이어가 엘리베이터와 충돌");
            ani.Play("elevator");
            elevator.Play();
            b1 = false; //한번만 재생하도록


        }


    }

    private void OnTriggerStay(UnityEngine.Collider other)
    {
        if (other.name == "Player" && !elevator.isPlaying && b2) //엘리베이터 애니메이션 재생을 마치면
        {
            Debug.Log("엘리베이터 도착");
            player.GetComponent<MovePlayer>().enabled = true; //플레이어 움직임 풀기
            player.transform.parent = null; //상속해제
            b2 = false; //최적화 변수
        }



    }
}
