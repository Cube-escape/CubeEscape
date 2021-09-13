using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage10GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject TableSet;
    public GameObject Dice;
    public static bool DoseDartGameEnd;
    public static bool DoseDiceGameEnd;
    public static bool DoesCardGameEnd;

    public AudioSource audioEffect;
    public AudioClip[] effects;
    public GameObject light;
    public GameObject pointlight;
    public GameObject DiceNumText;

    private SceneManagement sm10;

    bool b1;
    bool b2;
    bool b3;

    [SerializeField] Text explainTxt;

    void Start()
    {
         DoesCardGameEnd=false;

    DoseDartGameEnd = false;
        DoseDiceGameEnd = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        sm10 = new SceneManagement();
        b1 = true;
        b2 = true;
        b3 = true;


    }

    // Update is called once per frame
    void Update()
    {

        if (DoesCardGameEnd && b1)
        {
            

            audioEffect.clip = effects[0];
            audioEffect.Play();
           
            b1 = false;

        }
        if (DoseDartGameEnd&& b2)
        {
            TableSet.SetActive(false);
            Dice.SetActive(true);
            light.SetActive(false);
            pointlight.SetActive(true);
            DiceNumText.SetActive(true);
            audioEffect.clip = effects[0];
            audioEffect.Play();



            StartCoroutine("explain", "운명의 주사위게임~");
            b2 = false;

        }

        if (DoseDiceGameEnd && b3)

        {
            StartCoroutine("explain", "주사위게임 성공");
            audioEffect.clip = effects[1];
            audioEffect.Play();
            StartCoroutine("nextStage");
            b3 = false;

        }
       



    }

    IEnumerator nextStage() //설명 및 명언(상단 출력)
    {
        yield return new WaitForSeconds(10f);
        SceneManagement.completedStage = 10;
        sm10.movetoNextStage();

    }

    IEnumerator explain(string txt) //설명 및 명언(상단 출력)
    {
        explainTxt.text = txt;

        yield return new WaitForSeconds(3f);
        explainTxt.text = "";

    }
}
