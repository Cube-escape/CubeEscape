using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{

    public static int completedStage; //�̺����� stage clear�� ���� ������ ���. 
    //���� ������ ��ũ��Ʈ����  ���� ������ stage1�� Ŭ�����ߴٸ� �ݵ�� SceneManagement.completedStage=1;�� �ٲ��־����.
    public static int currentStage;

   
    public void Start()
    {
        


    }

    public void Update()
    {

    }
   

    public void chaneSceneBtn() //����ȭ��
    {

        switch (this.gameObject.name)
        {
            case "Newgame":
                {
               
                    currentStage = 1;
                    PlayerPrefs.DeleteAll(); //��� Ű�� �����.
                    PlayerPrefs.Save(); //������Ʈ���� �� ����

                    SceneManager.LoadScene("Stage1");


                }
                break;

            case "Continue":

                {     //���� ��ó������ ����� ������ ��� null������ �ߴ°� ����ϱ�

                    if (!PlayerPrefs.HasKey("currentStageNum"))// ������Ʈ���� ����� ���� ���ٸ� 

                    {  //���� �ƹ� ���������� ���� �����̹Ƿ� stage1�� �����Ų��.

                        currentStage = 1;
                        SceneManager.LoadScene(currentStage);
                    }


                    else //����� ���� �ִٸ�

                    {
                        int n = PlayerPrefs.GetInt("currentStageNum"); //����� ������������ �ҷ��ͼ� 
                        SceneManager.LoadScene(n);//���� �ε��Ų��. 

                    }

                }
                break;


            case "Exit":

                //�����ϴ±���ʿ�. 
                Application.Quit();
                break;

        }
    }

    //�������������� �̵������� �ڵ�����ǵ��� ��.

    public void movetoNextStage() //�������������� �̵�. ���� ��������  �� Ŭ������ �� �޼ҵ� ȣ���Ͻø� �ɵ�. 
    {
        currentStage = completedStage + 1; //���������� ���� �������� �� ����.

        PlayerPrefs.SetInt("currentStageNum", currentStage);
        PlayerPrefs.Save(); //������Ʈ���� �� ����

        Scene scene = SceneManager.GetActiveScene();

        Debug.Log("movetoStage" + (scene.buildIndex+1));

        SceneManager.LoadScene(currentStage);


    }


    public void movetoMainmenu() //esc���¿��� mainmenu��ư�� ��������.
    {
        

        SceneManager.LoadScene("Mainmenu");

    }


    public void gameover(int CurrentStageNum) //gameover�ÿ� �� �޼ҵ� ȣ���Ű��. gameover ���ڷ� ����������ȣ ���� ���ʿ�x ���߿� �����ϱ�.
    {
        currentStage = CurrentStageNum;
        SceneManager.LoadScene("gameover");


    }

    public void restartStage() //���ӿ����ϰ� ���������� ������Ҷ�.
    {

        SceneManager.LoadScene(currentStage);


    }

    public void gameSave()
    {


        PlayerPrefs.SetInt("currentStage", currentStage);//����


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