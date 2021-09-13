using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickKeypad : MonoBehaviour
{
    [SerializeField]
    private Stage2GameManager gameManager;

    [SerializeField]
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            CloseKeypadUI();
            GetComponent<Text>().text = "";
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
        if(GetComponent<Text>().text == "3558")
        {
            gameManager.IncreaseState();
            Debug.Log("State 5");
            CloseKeypadUI();
        }
        else
        {
            GetComponent<Text>().text = "";
        }
    }

    private void CloseKeypadUI()
    {
        player.GetComponent<MovePlayer2>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        GameObject.Find("Keypad_UI").SetActive(false);
    }
}
