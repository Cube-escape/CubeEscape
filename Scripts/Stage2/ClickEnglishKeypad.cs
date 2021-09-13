using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickEnglishKeypad : MonoBehaviour
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
            CloseEnglichKeypadUI();
            GetComponent<Text>().text = "";
        }
    }

    public void ClickQ()
    {
        GetComponent<Text>().text += "Q";
    }

    public void ClickW()
    {
        GetComponent<Text>().text += "W";
    }

    public void ClickE()
    {
        GetComponent<Text>().text += "E";
    }

    public void ClickR()
    {
        GetComponent<Text>().text += "R";
    }

    public void ClickT()
    {
        GetComponent<Text>().text += "T";
    }

    public void ClickY()
    {
        GetComponent<Text>().text += "Y";
    }

    public void ClickU()
    {
        GetComponent<Text>().text += "U";
    }

    public void ClickI()
    {
        GetComponent<Text>().text += "I";
    }

    public void ClickO()
    {
        GetComponent<Text>().text += "O";
    }

    public void ClickP()
    {
        GetComponent<Text>().text += "P";
    }

    public void ClickA()
    {
        GetComponent<Text>().text += "A";
    }

    public void ClickS()
    {
        GetComponent<Text>().text += "S";
    }

    public void ClickD()
    {
        GetComponent<Text>().text += "D";
    }

    public void ClickF()
    {
        GetComponent<Text>().text += "F";
    }

    public void ClickG()
    {
        GetComponent<Text>().text += "G";
    }

    public void ClickH()
    {
        GetComponent<Text>().text += "H";
    }

    public void ClickJ()
    {
        GetComponent<Text>().text += "J";
    }

    public void ClickK()
    {
        GetComponent<Text>().text += "K";
    }

    public void ClickL()
    {
        GetComponent<Text>().text += "L";
    }

    public void ClickZ()
    {
        GetComponent<Text>().text += "Z";
    }

    public void ClickX()
    {
        GetComponent<Text>().text += "X";
    }

    public void ClickC()
    {
        GetComponent<Text>().text += "C";
    }

    public void ClickV()
    {
        GetComponent<Text>().text += "V";
    }

    public void ClickB()
    {
        GetComponent<Text>().text += "B";
    }

    public void ClickN()
    {
        GetComponent<Text>().text += "N";
    }

    public void ClickM()
    {
        GetComponent<Text>().text += "M";
    }

    public void ClickBakcspace()
    {
        if(GetComponent<Text>().text.Length > 0)
        {
            string txt = GetComponent<Text>().text.Remove(GetComponent<Text>().text.Length - 1);
            GetComponent<Text>().text = txt;
        }
    }

    public void ClickDone()
    {
        if (GetComponent<Text>().text == "DEATH")
        {
            gameManager.IncreaseState();
            Debug.Log("State 4");
            CloseEnglichKeypadUI();
        }
        else
        {
            GetComponent<Text>().text = "";
        }
    }

    private void CloseEnglichKeypadUI()
    {
        player.GetComponent<MovePlayer2>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        GameObject.Find("English_Keypad_UI").SetActive(false);
    }
}
