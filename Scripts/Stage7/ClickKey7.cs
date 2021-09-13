using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickKey7 : MonoBehaviour
{

    [SerializeField] GameManager7 gm7;
    [SerializeField] SceneManagement sm7;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            GetComponent<Text>().text = "";
            GameObject.Find("Player").GetComponent<MovePlayer>().enabled = true;
            GameObject.Find("Main Camera").GetComponent<MoveCamera>().enabled = true;
            GameObject.Find("keypadUI").SetActive(false);
        }
    }

    public void Click1()
    {
        GetComponent<Text>().text += "1";
    }

    public void Click2()
    {
        GetComponent<Text>().text += "2";
    }

    public void Click3()
    {
        GetComponent<Text>().text += "3";
    }

    public void Click4()
    {
        GetComponent<Text>().text += "4";
    }

    public void Click5()
    {
        GetComponent<Text>().text += "5";
    }

    public void Click6()
    {
        GetComponent<Text>().text += "6";
    }

    public void Click7()
    {
        GetComponent<Text>().text += "7";
    }

    public void Click8()
    {
        GetComponent<Text>().text += "8";
    }

    public void Click9()
    {
        GetComponent<Text>().text += "9";
    }

    public void Click0()
    {
        GetComponent<Text>().text += "0";
    }

    public void Clear()
    {
        GetComponent<Text>().text = "";
    }

    public void Done()
    {
        if (GetComponent<Text>().text == "1968")
        {
            
            GameManager7.isPasswordright = true;
            SceneManagement.completedStage = 7;
            Debug.Log("Scene complete 7");
            sm7.movetoNextStage();

        }
        else
        {
            GetComponent<Text>().text = "";
        }
    }

}
