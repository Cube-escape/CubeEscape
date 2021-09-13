using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionController12 : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    RaycastHit hitInfo;

    [SerializeField]
    private int sizeofLazer;

    [SerializeField]
    private GameObject interactionUI;

    [SerializeField]
    private Transform arm;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject chip;

    [SerializeField]
    private GameObject mainCamera;

    [SerializeField]
    private Camera scaleCamera;

    [SerializeField]
    private GameObject dialogUI;

    [SerializeField]
    private GameObject wallpaperUI;

    [SerializeField]
    private GameObject menuUI;

    [SerializeField]
    private GameObject bookUI;

    [SerializeField]
    private GameObject keypadUI;

    [SerializeField]
    private RotateScale rotateScale;

    [SerializeField]
    private GameManager12 gameManager;

    [SerializeField]
    private SceneManagement sceneManagement;

    [SerializeField]
    private AudioSource audioSourceEffect;

    // 0: 물건 클릭 소리, 1: 저울에 물건 놓는 소리, 2: 저울 수평일 때 나는 소리
    [SerializeField]
    private AudioClip[] clips;

    [SerializeField]
    private GameObject fadeOutPanel;

    // Update is called once per frame
    void Update()
    {
        CheckObject();

        if (arm.transform.childCount == 1 && Input.GetMouseButtonDown(1))
        {
            arm.transform.GetComponentInChildren<Rigidbody>().useGravity = true;
            arm.transform.GetComponentInChildren<Rigidbody>().isKinematic = false;
            arm.GetChild(0).parent = null;
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
        interactionUI.GetComponent<Text>().text = "";
    }

    void showEvent()
    {
        // 무게 잴 수 있는 물건들
        if((hitInfo.transform.name == "PokerChips" || hitInfo.transform.name == "Chip_1") && arm.childCount == 0)
        {
            interactionUI.GetComponent<Text>().text = "물건을 든다.";

            if (Input.GetMouseButtonDown(0))
            {
                PickUpItem(chip);
                audioSourceEffect.clip = clips[0];
                audioSourceEffect.Play();
            }
        }

        else if (hitInfo.transform.name == "Bat" && arm.childCount == 0)
        {
            interactionUI.GetComponent<Text>().text = "물건을 든다.";

            if (Input.GetMouseButtonDown(0))
            {
                PickUpItem(hitInfo);
                audioSourceEffect.clip = clips[0];
                audioSourceEffect.Play();
            }
        }

        else if (hitInfo.transform.name == "Knife" && arm.childCount == 0)
        {
            interactionUI.GetComponent<Text>().text = "물건을 든다.";

            if (Input.GetMouseButtonDown(0))
            {
                PickUpItem(hitInfo);
                audioSourceEffect.clip = clips[0];
                audioSourceEffect.Play();
            }
        }

        else if (hitInfo.transform.name == "Sack" && arm.childCount == 0)
        {
            interactionUI.GetComponent<Text>().text = "물건을 든다.";

            if (Input.GetMouseButtonDown(0))
            {
                PickUpItem(hitInfo);
                audioSourceEffect.clip = clips[0];
                audioSourceEffect.Play();
            }
        }

        else if (hitInfo.transform.name == "Drug" && arm.childCount == 0)
        {
            interactionUI.GetComponent<Text>().text = "물건을 든다.";

            if (Input.GetMouseButtonDown(0))
            {
                PickUpItem(hitInfo);
                audioSourceEffect.clip = clips[0];
                audioSourceEffect.Play();
            }
        }

        else if (hitInfo.transform.name == "Lips" && arm.childCount == 0)
        {
            interactionUI.GetComponent<Text>().text = "물건을 든다.";

            if (Input.GetMouseButtonDown(0))
            {
                PickUpItem(hitInfo);
                audioSourceEffect.clip = clips[0];
                audioSourceEffect.Play();
            }
        }

        else if ((hitInfo.transform.name == "Gold1" || hitInfo.transform.name == "Gold2") && arm.childCount == 0)
        {
            interactionUI.GetComponent<Text>().text = "물건을 든다.";

            if (Input.GetMouseButtonDown(0))
            {
                PickUpItem(hitInfo);
                audioSourceEffect.clip = clips[0];
                audioSourceEffect.Play();
            }
        }

        else if ((hitInfo.transform.name == "Silver1" || hitInfo.transform.name == "Silver2" || hitInfo.transform.name == "Silver3") && arm.childCount == 0)
        {
            interactionUI.GetComponent<Text>().text = "물건을 든다.";

            if (Input.GetMouseButtonDown(0))
            {
                PickUpItem(hitInfo);
                audioSourceEffect.clip = clips[0];
                audioSourceEffect.Play();
            }
        }

        // 확대 가능한 물건들
        else if(hitInfo.transform.name == "Wallpaper")
        {
            interactionUI.GetComponent<Text>().text = "자세히 본다.";

            if (Input.GetMouseButtonDown(0))
            {
                wallpaperUI.SetActive(true);
                player.GetComponent<MovePlayer12>().enabled = false;
            }
        }

        else if (hitInfo.transform.name == "Menu")
        {
            interactionUI.GetComponent<Text>().text = "자세히 본다.";

            if (Input.GetMouseButtonDown(0))
            {
                menuUI.SetActive(true);
                player.GetComponent<MovePlayer12>().enabled = false;
            }
        }

        else if (hitInfo.transform.name == "Book")
        {
            interactionUI.GetComponent<Text>().text = "자세히 본다.";

            if (Input.GetMouseButtonDown(0))
            {
                bookUI.SetActive(true);
                player.GetComponent<MovePlayer12>().enabled = false;
            }
        }

        // 저울
        else if(hitInfo.transform.name == "Left_plate")
        {
            if(arm.childCount == 1)
            {
                interactionUI.GetComponent<Text>().text = "물건을 놓는다.";

                if (Input.GetMouseButtonDown(0))
                {
                    Transform obj = arm.GetChild(0);
                    obj.parent = null;
                    obj.transform.GetComponent<Rigidbody>().useGravity = true;
                    obj.transform.GetComponent<Rigidbody>().isKinematic = false;
                    Vector3 pos;
                    if (obj.name == "Bat")
                    {
                        pos = new Vector3(hitInfo.transform.position.x, hitInfo.transform.position.y + 0.5f, hitInfo.transform.position.z);
                    }
                    else
                    {
                        pos = new Vector3(hitInfo.transform.position.x + Random.Range(-0.3f, 0.3f), hitInfo.transform.position.y + 0.5f, hitInfo.transform.position.z + Random.Range(-0.3f, 0.3f));
                    }
                    obj.transform.position = pos;
                    audioSourceEffect.clip = clips[1];
                    audioSourceEffect.Play();
                }
            }
            else
            {
                interactionUI.GetComponent<Text>().text = "올라간다.";

                if (Input.GetMouseButtonDown(0))
                {
                    interactionUI.SetActive(false);
                    player.GetComponent<MovePlayer12>().enabled = false;
                    mainCamera.SetActive(false);
                    scaleCamera.enabled = true;
                    if(rotateScale.GetGap() == 0)
                    {
                        audioSourceEffect.clip = clips[2];
                        audioSourceEffect.Play();
                        StartCoroutine("Dialog", "음... 내 무게는 0이었군..");
                    }
                    else
                    {
                        StartCoroutine("Dialog", "음... 양쪽 수평이 맞지 않아. 다시 재야겠군..");
                    }
                }
            }
        }

        else if (hitInfo.transform.name == "Right_plate")
        {
            if (arm.childCount == 1)
            {
                interactionUI.GetComponent<Text>().text = "물건을 놓는다.";

                if (Input.GetMouseButtonDown(0))
                {
                    Transform obj = arm.GetChild(0);
                    obj.parent = null;
                    obj.transform.GetComponent<Rigidbody>().useGravity = true;
                    obj.transform.GetComponent<Rigidbody>().isKinematic = false;
                    Vector3 pos;
                    if (obj.name == "Bat")
                    {
                        pos = new Vector3(hitInfo.transform.position.x, hitInfo.transform.position.y + 0.5f, hitInfo.transform.position.z);
                    }
                    else
                    {
                        pos = new Vector3(hitInfo.transform.position.x + Random.Range(-0.3f, 0.3f), hitInfo.transform.position.y + 0.5f, hitInfo.transform.position.z + Random.Range(-0.3f, 0.3f));
                    }
                    obj.transform.position = pos;
                    audioSourceEffect.clip = clips[1];
                    audioSourceEffect.Play();
                }
            }
            else
            {
                interactionUI.GetComponent<Text>().text = "올라간다.";

                if (Input.GetMouseButtonDown(0))
                {
                    interactionUI.SetActive(false);
                    player.GetComponent<MovePlayer12>().enabled = false;
                    mainCamera.SetActive(false);
                    scaleCamera.enabled = true;
                    if (rotateScale.GetGap() == 0)
                    {
                        audioSourceEffect.clip = clips[2];
                        audioSourceEffect.Play();
                        StartCoroutine("Dialog", "음... 내 무게는 0이었군..");
                    }
                    else
                    {
                        StartCoroutine("Dialog", "음... 양쪽 수평이 맞지 않아. 다시 재야겠군..");
                    }
                }
            }
        }

        // 키패드
        else if(hitInfo.transform.name == "Keypad")
        {
            if (gameManager.GetState() == 0)
            {
                interactionUI.GetComponent<Text>().text = "자세히 본다.";

                if (Input.GetMouseButtonDown(0))
                {
                    player.GetComponent<MovePlayer12>().enabled = false;
                    Cursor.lockState = CursorLockMode.None;
                    keypadUI.SetActive(true);
                }
            }
        }

        // 철문
        else if(hitInfo.transform.name == "Locked_door")
        {
            if(gameManager.GetState() == 0)
            {
                interactionUI.GetComponent<Text>().text = "잠겨있다.";

                if (Input.GetMouseButtonDown(0))
                {
                    StartCoroutine("Dialog", "비밀번호를 먼저 알아내야 할 것 같아.");
                }
            }
        }

        // 문
        else if(hitInfo.transform.name == "Door")
        {
            if (gameManager.GetState() == 1)
            {
                interactionUI.GetComponent<Text>().text = "밖으로 나간다.";

                if (Input.GetMouseButtonDown(0))
                {
                    StartCoroutine("FadeOut12");
                }
            }
        }
    }

    private void PickUpItem(RaycastHit hitInfo)
    {
        hitInfo.transform.GetComponent<Rigidbody>().useGravity = false;
        hitInfo.transform.GetComponent<Rigidbody>().isKinematic = true;
        hitInfo.transform.position = arm.position;
        hitInfo.transform.parent = arm;
    }

    private void PickUpItem(GameObject hitInfo)
    {
        hitInfo.transform.GetComponent<Rigidbody>().useGravity = false;
        hitInfo.transform.GetComponent<Rigidbody>().isKinematic = true;
        hitInfo.transform.position = arm.position;
        hitInfo.transform.parent = arm;
    }

    IEnumerator Dialog(string txt)
    {
        dialogUI.SetActive(true);
        dialogUI.GetComponentInChildren<Text>().text = txt;
        yield return new WaitForSeconds(2f);
        dialogUI.SetActive(false);
    }

    IEnumerator FadeOut12()
    {
        fadeOutPanel.SetActive(true);
        yield return new WaitForSeconds(5f);
        SceneManagement.completedStage = 12;
        sceneManagement.movetoNextStage();
    }
}
