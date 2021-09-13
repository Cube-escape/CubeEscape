using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{

    public static int completedStage; //이변수에 stage clear에 관한 정보를 담기. 
    //문에 적용할 스크립트에서  문이 열리고 stage1을 클리어했다면 반드시 SceneManagement.completedStage=1;로 바꿔주어야함.
    public static int currentStage;

   
    public void Start()
    {
        


    }

    public void Update()
    {

    }
   

    public void chaneSceneBtn() //메인화면
    {

        switch (this.gameObject.name)
        {
            case "Newgame":
                {
               
                    currentStage = 1;
                    PlayerPrefs.DeleteAll(); //모든 키를 지운다.
                    PlayerPrefs.Save(); //레지스트리에 값 저장

                    SceneManager.LoadScene("Stage1");


                }
                break;

            case "Continue":

                {     //가장 맨처음에는 저장된 정보가 없어서 null오류가 뜨는것 고려하기

                    if (!PlayerPrefs.HasKey("currentStageNum"))// 레지스트리에 저장된 값이 없다면 

                    {  //아직 아무 스테이지도 못깬 상태이므로 stage1을 실행시킨다.

                        currentStage = 1;
                        SceneManager.LoadScene(currentStage);
                    }


                    else //저장된 값이 있다면

                    {
                        int n = PlayerPrefs.GetInt("currentStageNum"); //저장된 스테이지값을 불러와서 
                        SceneManager.LoadScene(n);//씬을 로드시킨다. 

                    }

                }
                break;


            case "Exit":

                //저장하는기능필요. 
                Application.Quit();
                break;

        }
    }

    //다음스테이지로 이동했을때 자동저장되도록 함.

    public void movetoNextStage() //다음스테이지로 이동. 문이 열렸을때  이 클래스의 이 메소드 호출하시면 될듯. 
    {
        currentStage = completedStage + 1; //전역변수에 현재 스테이지 값 저장.

        PlayerPrefs.SetInt("currentStageNum", currentStage);
        PlayerPrefs.Save(); //레지스트리에 값 저장

        Scene scene = SceneManager.GetActiveScene();

        Debug.Log("movetoStage" + (scene.buildIndex+1));

        SceneManager.LoadScene(currentStage);


    }


    public void movetoMainmenu() //esc상태에서 mainmenu버튼을 눌렀을때.
    {
        

        SceneManager.LoadScene("Mainmenu");

    }


    public void gameover(int CurrentStageNum) //gameover시에 이 메소드 호출시키기. gameover 인자로 스테이지번호 굳이 줄필요x 나중에 수정하기.
    {
        currentStage = CurrentStageNum;
        SceneManager.LoadScene("gameover");


    }

    public void restartStage() //게임오버하고 스테이지를 재시작할때.
    {

        SceneManager.LoadScene(currentStage);


    }

    public void gameSave()
    {


        PlayerPrefs.SetInt("currentStage", currentStage);//저장


    }


    public void stageBtn()
    {
        

        switch (name)
        {
            case "Stage1Btn":
                SceneManager.LoadScene(1);
                break;


            case "Stage2Btn":
                SceneManager.LoadScene(2);
                break;

            case "Stage3Btn":
                SceneManager.LoadScene(3);
                break;

            case "Stage4Btn":
                SceneManager.LoadScene(4);
                break;

            case "Stage5Btn":
                SceneManager.LoadScene(5);
                break;

            case "Stage6Btn":
                SceneManager.LoadScene(6);
                break;

            case "Stage7Btn":
                SceneManager.LoadScene(7);
                break;

            case "Stage8Btn":
                SceneManager.LoadScene(8);
                break;

            case "Stage9Btn":
                SceneManager.LoadScene(9);
                break;

            case "Stage10Btn":
                SceneManager.LoadScene(10);
                break;

            case "Stage11Btn":
                SceneManager.LoadScene(11);
                break;

            case "Stage12Btn":
                SceneManager.LoadScene(12);
                break;

            case "Stage13Btn":
                SceneManager.LoadScene(13);
                break;

        }



    }
}