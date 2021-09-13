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

            if (arm.GetChild(0).gameObject.name == "clock" || arm.GetChild(0).gameObject.name == "sock" || arm.GetChild(0).gameObject.name == "가족액자")
            {
                //태우기 효과음 재생.
                fire.Play();
                arm.GetChild(0).transform.gameObject.SetActive(false);//태운물체 비활성화
                arm.GetChild(0).parent = null; //상속관계 해제
                FirecheckUI.SetActive(false);//UI끄기
                Cursor.lockState = CursorLockMode.Locked; //커서잠금.
                Player.GetComponent<MovePlayer>().enabled = true; //카메라움직이기 활성화.
                cam.GetComponent<MoveCamera>().enabled = true; //플레이어 움직이기 활성화.
                Debug.Log("올바른거 태움.");
            }

            else
            {
                Debug.Log("이상한거 태움.");


                sm3.gameover(3);
            }
           
        }

        else
        {
            FirecheckUI.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked; //커서잠금.
            Player.GetComponent<MovePlayer>().enabled = true; //카메라움직이기 활성화.
            cam.GetComponent<MoveCamera>().enabled = true; //플레이어 움직이기 활성화.

        }

    }

    public void YesBtn()
    {
        if (arm.GetChild(0).gameObject.name == "clock" || arm.GetChild(0).gameObject.name == "sock" || arm.GetChild(0).gameObject.name == "가족액자")
        {
            //태우기 효과음 재생.
            fire.Play();
            arm.GetChild(0).transform.gameObject.SetActive(false);//태운물체 비활성화
            arm.GetChild(0).parent = null; //상속관계 해제
            FirecheckUI.SetActive(false);//UI끄기
            Cursor.lockState = CursorLockMode.Locked; //커서잠금.
            Player.GetComponent<MovePlayer>().enabled = true; //카메라움직이기 활성화.
            cam.GetComponent<MoveCamera>().enabled = true; //플레이어 움직이기 활성화.
            Debug.Log("올바른거 태움.");
        }

        else
        {
            Debug.Log("이상한거 태움.");


            sm3.gameover(3);
        }
    }
    
    public void NoBtn()
    {
        FirecheckUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked; //커서잠금.
        Player.GetComponent<MovePlayer>().enabled = true; //카메라움직이기 활성화.
        cam.GetComponent<MoveCamera>().enabled = true; //플레이어 움직이기 활성화.
    }
}


