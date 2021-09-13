using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElectricButtons : MonoBehaviour
{
    [SerializeField]
    private GameObject[] electricButtons;

    [SerializeField]
    private Sprite blackButton;

    [SerializeField]
    private Stage2GameManager gameManager;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip clip;

    // 버튼 값 받아오기
    private int[] button_order = new int[6];
    private int button_count = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            CloseElectricboxUI();
            button_count = 0;
            for (int i = 0; i < 6; i++)
            {
                initElecButton(electricButtons[i]);
            }
        }

        if (button_count == 6)
        {
            if (button_order[0] == 1 && button_order[1] == 4 && button_order[2] == 5 &&
                button_order[3] == 6 && button_order[4] == 3 && button_order[5] == 2)
            {
                audioSource.clip = clip;
                audioSource.Play();
                CloseElectricboxUI();
                gameManager.IncreaseState();
                Debug.Log("go to state3");
            }
            else
            {
                button_count = 0;
                for (int i = 0; i < 6; i++)
                {
                    initElecButton(electricButtons[i]);
                }
            }
        }
    }

    private void CloseElectricboxUI()
    {
        GameObject.Find("Electric_Box_UI").SetActive(false);
        player.GetComponent<MovePlayer2>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        gameObject.SetActive(false);
    }

    public void Button1()
    {
        Debug.Log("Click Button1");
        button_order[button_count] = 1;
        button_count++;
    }

    public void Button2()
    {
        Debug.Log("Click Button2");
        button_order[button_count] = 2;
        button_count++;
    }

    public void Button3()
    {
        Debug.Log("Click Button3");
        button_order[button_count] = 3;
        button_count++;
    }

    public void Button4()
    {
        Debug.Log("Click Button4");
        button_order[button_count] = 4;
        button_count++;
    }

    public void Button5()
    {
        Debug.Log("Click Button5");
        button_order[button_count] = 5;
        button_count++;
    }

    public void Button6()
    {
        Debug.Log("Click Button6");
        button_order[button_count] = 6;
        button_count++;
    }

    private void initElecButton(GameObject elecButton)
    {
        elecButton.GetComponent<Image>().sprite = blackButton;
        elecButton.GetComponent<Button>().enabled = true;
    }
}
