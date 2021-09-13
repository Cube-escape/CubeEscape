using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionController2 : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    RaycastHit hitInfo;

    [SerializeField]
    private int sizeofLazer;

    [SerializeField]
    private GameObject[] interactionUI;

    [SerializeField]
    private Transform arm;

    [SerializeField]
    private GameObject ElectricBoxUI;

    [SerializeField]
    private GameObject EnglishKeypadUI;

    [SerializeField]
    private GameObject[] PaintsUI;

    [SerializeField]
    private GameObject[] spotLights;

    [SerializeField]
    private GameObject KeypadUI;

    [SerializeField]
    private Stage2GameManager gameManager;

    [SerializeField]
    private SceneManagement sceneManagement;

    [SerializeField]
    private GameObject fadeOutPanel;

    [SerializeField]
    private GameObject dialogUI;

    private int state;
    private bool is_electricbox_open = false;

    // Update is called once per frame
    void Update()
    {
        CheckObject();

        if(arm.transform.childCount == 1 && Input.GetMouseButtonDown(1))
        {
            arm.transform.GetComponentInChildren<Rigidbody>().useGravity = true;
            arm.transform.GetComponentInChildren<Rigidbody>().isKinematic = false;
            arm.GetChild(0).parent = null;
        }

        state = gameManager.GetState();
        if(state == 3)
        {
            spotLights[0].GetComponent<ChangeSpotlight>().SetChangePaints();
        }
        else if(state == 4)
        {
            interactionUI[0].GetComponent<Text>().color = new Color32(200, 0, 0, 255);
            for (int i = 1; i < 5; i++)
            {
                spotLights[i].GetComponent<ChangeSpotlight>().SetChangePaints();
            }
        }
    }

    void CheckObject()
    {
        int x = Screen.width / 2;
        int y = Screen.height / 2;
        Ray ray = cam.ScreenPointToRay(new Vector3(x, y));   

        if (Physics.Raycast(ray, out hitInfo, sizeofLazer) && hitInfo.transform.CompareTag("interaction")) 
        {
            Contact();
            //Debug.Log(hitInfo.transform.name);
        }
        else
        {
            notContact();
        }
    }

    void Contact()
    {
        showEvent();
    }


    void notContact()
    {
        for (int i = 0; i < interactionUI.Length; i++)
        {
            interactionUI[0].GetComponent<Text>().text = "";
        }
    }

    void showEvent()
    {
        // 조명 
        if (hitInfo.transform.name == "spotlight_death")
        {
            if(state == 1 || state == 2)
            {
                interactionUI[0].GetComponent<Text>().text = "불을 켠다.";

                if (Input.GetMouseButtonDown(0))
                {
                    StartCoroutine("Dialog", "불이 켜지지 않아.. 전원을 먼저 켜야 할 것 같아.");
                }
            }
            if (state == 3 || state == 4)
            {
                if (spotLights[0].GetComponent<ChangeSpotlight>().GetCount() == 2)
                {
                    interactionUI[0].GetComponent<Text>().text = "불을 끈다.";
                }
                else
                {
                    interactionUI[0].GetComponent<Text>().text = "불을 켠다.";
                }

                if (Input.GetMouseButtonDown(0))
                {
                    spotLights[0].GetComponent<ChangeSpotlight>().UpCount();
                    interactionUI[0].GetComponent<Text>().text = "";
                    Debug.Log("click spotlight_death");
                }
            }
        }

        else if (hitInfo.transform.name == "spotlight_crack")
        {
            if (state == 1 || state == 2)
            {
                interactionUI[0].GetComponent<Text>().text = "불을 켠다.";

                if (Input.GetMouseButtonDown(0))
                {
                    StartCoroutine("Dialog", "불이 켜지지 않아.. 전원을 먼저 켜야 할 것 같아.");
                }
            }
            if (state == 3 || state == 4)
            {
                if (spotLights[1].GetComponent<ChangeSpotlight>().GetCount() == 2)
                {
                    interactionUI[0].GetComponent<Text>().text = "불을 끈다.";
                }
                else
                {
                    interactionUI[0].GetComponent<Text>().text = "불을 켠다.";
                }

                if (Input.GetMouseButtonDown(0))
                {
                    spotLights[1].GetComponent<ChangeSpotlight>().UpCount();
                    interactionUI[0].GetComponent<Text>().text = "";
                    Debug.Log("click spotlight_crack");
                }
            }
        }

        else if (hitInfo.transform.name == "spotlight_gaze")
        {
            if (state == 1 || state == 2)
            {
                interactionUI[0].GetComponent<Text>().text = "불을 켠다.";

                if (Input.GetMouseButtonDown(0))
                {
                    StartCoroutine("Dialog", "불이 켜지지 않아.. 전원을 먼저 켜야 할 것 같아.");
                }
            }
            if (state == 3 || state == 4)
            {
                if (spotLights[2].GetComponent<ChangeSpotlight>().GetCount() == 2)
                {
                    interactionUI[0].GetComponent<Text>().text = "불을 끈다.";
                }
                else
                {
                    interactionUI[0].GetComponent<Text>().text = "불을 켠다.";
                }

                if (Input.GetMouseButtonDown(0))
                {
                    spotLights[2].GetComponent<ChangeSpotlight>().UpCount();
                    interactionUI[0].GetComponent<Text>().text = "";
                    Debug.Log("click spotlight_gaze");
                }
            }
        }

        else if (hitInfo.transform.name == "spotlight_illusion")
        {
            if (state == 1 || state == 2)
            {
                interactionUI[0].GetComponent<Text>().text = "불을 켠다.";

                if (Input.GetMouseButtonDown(0))
                {
                    StartCoroutine("Dialog", "불이 켜지지 않아.. 전원을 먼저 켜야 할 것 같아.");
                }
            }
            if (state == 3 || state == 4)
            {
                if (spotLights[3].GetComponent<ChangeSpotlight>().GetCount() == 2)
                {
                    interactionUI[0].GetComponent<Text>().text = "불을 끈다.";
                }
                else
                {
                    interactionUI[0].GetComponent<Text>().text = "불을 켠다.";
                }

                if (Input.GetMouseButtonDown(0))
                {
                    spotLights[3].GetComponent<ChangeSpotlight>().UpCount();
                    interactionUI[0].GetComponent<Text>().text = "";
                    Debug.Log("click spotlight_illusion");
                }
            }
        }

        else if (hitInfo.transform.name == "spotlight_peace")
        {
            if (state == 1 || state == 2)
            {
                interactionUI[0].GetComponent<Text>().text = "불을 켠다.";

                if (Input.GetMouseButtonDown(0))
                {
                    StartCoroutine("Dialog", "불이 켜지지 않아.. 전원을 먼저 켜야 할 것 같아.");
                }
            }
            if (state == 3 || state == 4)
            {
                if (spotLights[4].GetComponent<ChangeSpotlight>().GetCount() == 2)
                {
                    interactionUI[0].GetComponent<Text>().text = "불을 끈다.";
                }
                else
                {
                    interactionUI[0].GetComponent<Text>().text = "불을 켠다.";
                }

                if (Input.GetMouseButtonDown(0))
                {
                    spotLights[4].GetComponent<ChangeSpotlight>().UpCount();
                    interactionUI[0].GetComponent<Text>().text = "";
                    Debug.Log("click spotlight_peace");
                }
            }
        }

        // 이름표
        else if (hitInfo.transform.name == "name_tag_crack" && state == 1 && arm.transform.childCount == 0)
        {
            interactionUI[0].GetComponent<Text>().text = "이름표를 든다.";

            if (Input.GetMouseButtonDown(0))
            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click name_tag_crack");

                // 클릭하면 든다.
                if(arm.transform.childCount == 0)
                {
                    hitInfo.transform.GetComponent<Rigidbody>().useGravity = false; // gravity를 끈다.
                    hitInfo.transform.GetComponent<Rigidbody>().isKinematic = true; // kinematic을 켜면 스크립트에 의해서만 움직인다. 물건을 손에 집었을 때 공기 저항에 의해 빙글빙글 돌지 않도록 하기 위해 필요하다. 
                    hitInfo.transform.position = arm.position; // 팔로 지정해둔 위치로 이동시킨다.
                    hitInfo.transform.parent = GameObject.Find("Arm").transform; // 팔의 child로 넣어준다.
                    hitInfo.transform.GetComponent<Transform>().localRotation = Quaternion.Euler(0f, 0f, 0f); // 앞면이 보이도록 회전 각도를 전부 0으로 맞춰준다.
                    hitInfo.transform.GetComponent<Transform>().localScale = new Vector3(2f, 1.5f, 1f);
                }
            }
        }

        else if (hitInfo.transform.name == "name_tag_gaze" && state == 1 && arm.transform.childCount == 0)
        {
            interactionUI[0].GetComponent<Text>().text = "이름표를 든다.";

            if (Input.GetMouseButtonDown(0))
            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click name_tag_gaze");

                if (arm.transform.childCount == 0)
                {
                    hitInfo.transform.GetComponent<Rigidbody>().useGravity = false;
                    hitInfo.transform.GetComponent<Rigidbody>().isKinematic = true;
                    hitInfo.transform.position = arm.position;
                    hitInfo.transform.parent = GameObject.Find("Arm").transform;
                    hitInfo.transform.GetComponent<Transform>().localRotation = Quaternion.Euler(0f, 0f, 0f);
                    hitInfo.transform.GetComponent<Transform>().localScale = new Vector3(2f, 1.5f, 1f);
                }
            }
        }

        else if (hitInfo.transform.name == "name_tag_illusion" && state == 1 && arm.transform.childCount == 0)
        {
            interactionUI[0].GetComponent<Text>().text = "이름표를 든다.";

            if (Input.GetMouseButtonDown(0))
            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click name_tag_illusion");

                if (arm.transform.childCount == 0)
                {
                    hitInfo.transform.GetComponent<Rigidbody>().useGravity = false;
                    hitInfo.transform.GetComponent<Rigidbody>().isKinematic = true;
                    hitInfo.transform.position = arm.position;
                    hitInfo.transform.parent = GameObject.Find("Arm").transform;
                    hitInfo.transform.GetComponent<Transform>().localRotation = Quaternion.Euler(0f, 0f, 0f);
                    hitInfo.transform.GetComponent<Transform>().localScale = new Vector3(2f, 1.5f, 1f);
                }
            }
        }

        else if (hitInfo.transform.name == "name_tag_peace" && state == 1 && arm.transform.childCount == 0)
        {
            interactionUI[0].GetComponent<Text>().text = "이름표를 든다.";

            if (Input.GetMouseButtonDown(0))
            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click name_tag_peace");

                if (arm.transform.childCount == 0)
                {
                    hitInfo.transform.GetComponent<Rigidbody>().useGravity = false;
                    hitInfo.transform.GetComponent<Rigidbody>().isKinematic = true;
                    hitInfo.transform.position = arm.position;
                    hitInfo.transform.parent = GameObject.Find("Arm").transform;
                    hitInfo.transform.GetComponent<Transform>().localRotation = Quaternion.Euler(0f, 0f, 0f);
                    hitInfo.transform.GetComponent<Transform>().localScale = new Vector3(2f, 1.5f, 1f);
                }
            }
        }

        /*
        else if (hitInfo.transform.name == "name_tag_death" && state == 1 && arm.transform.childCount == 0)
        {
            interactionUI[0].GetComponent<Text>().text = "이름표를 든다.";

            if (Input.GetMouseButtonDown(0))
            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click name_tag_death");

                if (arm.transform.childCount == 0)
                {
                    hitInfo.transform.GetComponent<Rigidbody>().useGravity = false;
                    hitInfo.transform.GetComponent<Rigidbody>().isKinematic = true;
                    hitInfo.transform.position = arm.position;
                    hitInfo.transform.parent = GameObject.Find("Arm").transform;
                    hitInfo.transform.GetComponent<Transform>().localRotation = Quaternion.Euler(0f, 0f, 0f);
                    hitInfo.transform.GetComponent<Transform>().localScale = new Vector3(2.5f, 1.33f, 1f);
                }
            }
        }
        */

        // 이름판 
        else if (hitInfo.transform.name == "Name_Plate_gaze" && state == 1)
        {
            if (arm.transform.childCount == 1 && hitInfo.transform.childCount == 0)
            {
                interactionUI[0].GetComponent<Text>().text = "이름표를 붙인다.";

                if (Input.GetMouseButtonDown(0))
                {
                    Transform nametag = arm.GetChild(0);
                    nametag.parent = null;
                    nametag.localRotation = Quaternion.Euler(0f, -90f, 0f);
                    nametag.localPosition = new Vector3(-49.63f, 17.1f, 20f);
                    nametag.localScale = new Vector3(2f, 2f, 1f);
                    nametag.parent = hitInfo.transform;
                }
            }
        }

        else if (hitInfo.transform.name == "Name_Plate_crack" && state == 1)
        {
            if (arm.transform.childCount == 1 && hitInfo.transform.childCount == 0)
            {
                interactionUI[0].GetComponent<Text>().text = "이름표를 붙인다.";

                if (Input.GetMouseButtonDown(0))
                {
                    Transform nametag = arm.GetChild(0);
                    nametag.parent = null;
                    nametag.localRotation = Quaternion.Euler(0f, -90f, 0f);
                    nametag.localPosition = new Vector3(-49.6f, 17.1f, -6f);
                    nametag.localScale = new Vector3(2f, 2f, 1f);
                    nametag.parent = hitInfo.transform;
                }
            }
        }

        else if (hitInfo.transform.name == "Name_Plate_illusion" && state == 1)
        {
            if (arm.transform.childCount == 1 && hitInfo.transform.childCount == 0)
            {
                interactionUI[0].GetComponent<Text>().text = "이름표를 붙인다.";

                if (Input.GetMouseButtonDown(0))
                {
                    Transform nametag = arm.GetChild(0);
                    nametag.parent = null;
                    nametag.localRotation = Quaternion.Euler(0f, 90f, 0f);
                    nametag.localPosition = new Vector3(49.6f, 17.1f, -34.2f);
                    nametag.localScale = new Vector3(2f, 2f, 1f);
                    nametag.parent = hitInfo.transform;
                }
            }
        }

        else if (hitInfo.transform.name == "Name_Plate_peace" && state == 1)
        {
            if (arm.transform.childCount == 1 && hitInfo.transform.childCount == 0)
            {
                interactionUI[0].GetComponent<Text>().text = "이름표를 붙인다.";

                if (Input.GetMouseButtonDown(0))
                {
                    Transform nametag = arm.GetChild(0);
                    nametag.parent = null;
                    nametag.localRotation = Quaternion.Euler(0f, 90f, 0f);
                    nametag.localPosition = new Vector3(49.6f, 17.1f, 5.8f);
                    nametag.localScale = new Vector3(2f, 2f, 1f);
                    nametag.parent = hitInfo.transform;
                }
            }
        }

        /*
        else if (hitInfo.transform.name == "Name_Plate_death" && state == 1)
        {
            if (arm.transform.childCount == 1 && hitInfo.transform.childCount == 0)
            {
                interactionUI[0].GetComponent<Text>().text = "이름표를 붙인다.";

                if (Input.GetMouseButtonDown(0))
                {
                    Transform nametag = arm.GetChild(0);
                    nametag.parent = null;
                    nametag.localRotation = Quaternion.Euler(0f, 0f, 0f);
                    nametag.localPosition = new Vector3(17.2f, 17.1f, 49.6f);
                    nametag.localScale = new Vector3(2f, 2f, 1f);
                    nametag.parent = hitInfo.transform;
                }
            }
        }
        */

        // Key and KeyHole
        else if (hitInfo.transform.name == "Key" && state == 2 && arm.transform.childCount == 0)
        {
            interactionUI[0].GetComponent<Text>().text = "열쇠를 든다.";

            if (Input.GetMouseButtonDown(0))
            {
                interactionUI[0].GetComponent<Text>().text = "";
                Debug.Log("click Key");

                if (arm.transform.childCount == 0)
                {
                    hitInfo.transform.GetComponent<Rigidbody>().useGravity = false;
                    hitInfo.transform.GetComponent<Rigidbody>().isKinematic = true;
                    hitInfo.transform.position = arm.position;
                    hitInfo.transform.parent = GameObject.Find("Arm").transform;
                    hitInfo.transform.GetComponent<Transform>().localRotation = Quaternion.Euler(90f, 90f, 0f);
                    hitInfo.transform.GetComponent<Transform>().localScale = new Vector3(20f, 20f, 20f);
                }
            }
        }

        else if(hitInfo.transform.name == "Key_Hole" || hitInfo.transform.name == "Electric_Box")
        {
            if(state == 1)
            {
                interactionUI[0].GetComponent<Text>().text = "전선함을 연다.";

                if (Input.GetMouseButtonDown(0))
                {
                    StartCoroutine("Dialog", "잠겨있어.. 열쇠가 있어야 할 것 같아.");
                }
            }
            if (state == 2 && !is_electricbox_open)
            {
                if(arm.transform.childCount == 0)
                {
                    interactionUI[0].GetComponent<Text>().text = "전선함을 연다.";

                    if (Input.GetMouseButtonDown(0))
                    {
                        StartCoroutine("Dialog", "잠겨있어.. 열쇠가 있어야 할 것 같아.");
                    }
                }
                else if (arm.transform.childCount == 1)
                {
                    interactionUI[0].GetComponent<Text>().text = "전선함을 연다.";

                    if (Input.GetMouseButtonDown(0))
                    {
                        is_electricbox_open = true;
                        arm.GetChild(0).parent = null;
                        GameObject.Find("Key").SetActive(false);
                        GameObject.Find("Electric_Box_Case").SetActive(false);
                        GameObject.Find("Key_Hole").SetActive(false);
                        //hitInfo.transform.GetComponent<Collider>().enabled = false;
                    }
                }
            }
            else if(state == 2 && is_electricbox_open)
            {
                interactionUI[0].GetComponent<Text>().text = "확대한다.";

                if (Input.GetMouseButtonDown(0))
                {
                    ElectricBoxUI.SetActive(true);
                    GameObject.Find("Player").GetComponent<MovePlayer2>().enabled = false;
                    Cursor.lockState = CursorLockMode.None;
                }
            }
        }

        // 전선함
        /*
        else if (hitInfo.transform.name == "electricbox")
        {
            if (state == 2 && is_electricbox_open)
            {
                interactionUI[0].GetComponent<Text>().text = "확대한다.";

                if (Input.GetMouseButtonDown(0))
                {
                    ElectricBoxUI.SetActive(true);
                    GameObject.Find("Player").GetComponent<MovePlayer2>().enabled = false;
                    Cursor.lockState = CursorLockMode.None;
                }
            }
        }
        */

        // 영어 자판
        else if (hitInfo.transform.name == "Keypad_Monitor")
        {
            if(state == 3)
            {
                interactionUI[0].GetComponent<Text>().text = "확대한다.";

                if (Input.GetMouseButtonDown(0))
                {
                    EnglishKeypadUI.SetActive(true);
                    GameObject.Find("Player").GetComponent<MovePlayer2>().enabled = false;
                    Cursor.lockState = CursorLockMode.None;
                }
            }
            else if(state == 4 || state == 5)
            {
                interactionUI[0].GetComponent<Text>().text = "DEATH";
            }
            else
            {
                interactionUI[0].GetComponent<Text>().text = "꺼져있다.";
            }
        }

        // 그림
        else if(hitInfo.transform.name == "Death")
        {
            if (state == 4)
            {
                interactionUI[0].GetComponent<Text>().text = "확대한다.";

                if (Input.GetMouseButtonDown(0))
                {
                    GameObject.Find("Player").GetComponent<MovePlayer2>().enabled = false;
                    if (spotLights[0].GetComponent<ChangeSpotlight>().GetCount() == 2)
                    {
                        PaintsUI[1].SetActive(true);
                    }
                    else
                    {
                        PaintsUI[0].SetActive(true);
                    }
                }
            }
        }

        else if (hitInfo.transform.name == "Crack")
        {
            if (state == 4)
            {
                interactionUI[0].GetComponent<Text>().text = "확대한다.";

                if (Input.GetMouseButtonDown(0))
                {
                    GameObject.Find("Player").GetComponent<MovePlayer2>().enabled = false;
                    if (spotLights[1].GetComponent<ChangeSpotlight>().GetCount() == 2)
                    {
                        PaintsUI[3].SetActive(true);
                    }
                    else
                    {
                        PaintsUI[2].SetActive(true);
                    }
                }
            }
        }

        else if (hitInfo.transform.name == "Gaze")
        {
            if (state == 4)
            {
                interactionUI[0].GetComponent<Text>().text = "확대한다.";

                if (Input.GetMouseButtonDown(0))
                {
                    GameObject.Find("Player").GetComponent<MovePlayer2>().enabled = false;
                    if (spotLights[2].GetComponent<ChangeSpotlight>().GetCount() == 2)
                    {
                        PaintsUI[5].SetActive(true);
                    }
                    else
                    {
                        PaintsUI[4].SetActive(true);
                    }
                }
            }
        }

        else if (hitInfo.transform.name == "Illusion")
        {
            if (state == 4)
            {
                interactionUI[0].GetComponent<Text>().text = "확대한다.";

                if (Input.GetMouseButtonDown(0))
                {
                    GameObject.Find("Player").GetComponent<MovePlayer2>().enabled = false;
                    if (spotLights[3].GetComponent<ChangeSpotlight>().GetCount() == 2)
                    {
                        PaintsUI[7].SetActive(true);
                    }
                    else
                    {
                        PaintsUI[6].SetActive(true);
                    }
                }
            }
        }

        else if (hitInfo.transform.name == "Peace")
        {
            if (state == 4)
            {
                interactionUI[0].GetComponent<Text>().text = "확대한다.";

                if (Input.GetMouseButtonDown(0))
                {
                    GameObject.Find("Player").GetComponent<MovePlayer2>().enabled = false;
                    if (spotLights[4].GetComponent<ChangeSpotlight>().GetCount() == 2)
                    {
                        PaintsUI[9].SetActive(true);
                    }
                    else
                    {
                        PaintsUI[8].SetActive(true);
                    }
                }
            }
        }

        // 숫자 키패드
        else if (hitInfo.transform.name == "Keypad")
        {
            if (state == 4)
            {
                interactionUI[0].GetComponent<Text>().text = "확대한다.";
                if (Input.GetMouseButtonDown(0))
                {
                    KeypadUI.SetActive(true);
                    GameObject.Find("Player").GetComponent<MovePlayer2>().enabled = false;
                    Cursor.lockState = CursorLockMode.None;
                }
            }
            else if(state == 5)
            {
                interactionUI[0].GetComponent<Text>().text = "3558";
            }
            else
            {
                interactionUI[0].GetComponent<Text>().text = "꺼져있다.";
            }
        }

        // 출구
        else if (hitInfo.transform.name == "Door")
        {
            if (state == 5)
            {
                interactionUI[0].GetComponent<Text>().text = "밖으로 나간다.";

                if (Input.GetMouseButtonDown(0))
                {
                    StartCoroutine("Stage2Outro");
                    
                }
            }
            else
            {
                interactionUI[0].GetComponent<Text>().text = "잠겨있다.";
            }
        }
    }

    IEnumerator Stage2Outro()
    {
        fadeOutPanel.SetActive(true);
        yield return new WaitForSeconds(5f);
        SceneManagement.completedStage = 2;
        sceneManagement.movetoNextStage();
    }

    IEnumerator Dialog(string txt)
    {
        dialogUI.SetActive(true);
        dialogUI.GetComponentInChildren<Text>().text = txt;
        yield return new WaitForSeconds(2f);
        dialogUI.SetActive(false);
    }
}