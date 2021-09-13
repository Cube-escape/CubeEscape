using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionController6 : MonoBehaviour
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
    private GameObject dreamCatcherPaperUI;

    [SerializeField]
    private GameObject[] cabinets;

    [SerializeField]
    private GameObject table;

    [SerializeField]
    private GameObject cage;

    [SerializeField]
    private GameObject[] feathers;

    private int featherCount = 0;

    [SerializeField]
    private GameObject dreamcatcher;

    [SerializeField]
    private GameObject door;

    [SerializeField]
    private SceneManagement sceneManagement;

    [SerializeField]
    private Stage6GameManager gameManager;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private GameObject fadeOutPanel;

    // 0: open_drawer, 1: close_drawer, 2: cabinet_door, 3: key, 4: item pickup, 5: item put, 6: unfold paper
    [SerializeField]
    private AudioClip[] clips;

    [SerializeField]
    private GameObject dialogUI;

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
        // 드림캐쳐 도안
        if (hitInfo.transform.name == "dream_catcher_paper")
        {
            interactionUI.GetComponent<Text>().text = "종이를 펼쳐본다.";

            if (Input.GetMouseButton(0))
            {
                audioSource.clip = clips[6];
                audioSource.Play();
                dreamCatcherPaperUI.SetActive(true);
                player.GetComponent<MovePlayer6>().enabled = false;
                Cursor.lockState = CursorLockMode.None;
            }
        }

        // 캐비닛1
        else if (hitInfo.transform.name == "cabinet_door_101")
        {
            if (cabinets[0].GetComponent<ClickCabinet>().isULDoorOpen == false) {
                interactionUI.GetComponent<Text>().text = "문을 연다";

                if (Input.GetMouseButtonDown(0))
                {
                    audioSource.clip = clips[2];
                    audioSource.Play();
                    cabinets[0].GetComponent<ClickCabinet>().OpenULDoor();
                    cabinets[0].GetComponent<ClickCabinet>().isULDoorOpen = true;
                }
            }
            else
            {
                interactionUI.GetComponent<Text>().text = "문을 닫는다.";

                if (Input.GetMouseButtonDown(0))
                {
                    audioSource.clip = clips[2];
                    audioSource.Play();
                    cabinets[0].GetComponent<ClickCabinet>().CloseULDoor();
                    cabinets[0].GetComponent<ClickCabinet>().isULDoorOpen = false;
                }
            }
        }

        else if (hitInfo.transform.name == "cabinet_door_102")
        {
            if (cabinets[0].GetComponent<ClickCabinet>().isURDoorOpen == false)
            {
                interactionUI.GetComponent<Text>().text = "문을 연다";

                if (Input.GetMouseButtonDown(0))
                {
                    audioSource.clip = clips[2];
                    audioSource.Play();
                    cabinets[0].GetComponent<ClickCabinet>().OpenURDoor();
                    cabinets[0].GetComponent<ClickCabinet>().isURDoorOpen = true;
                }
            }
            else
            {
                interactionUI.GetComponent<Text>().text = "문을 닫는다.";

                if (Input.GetMouseButtonDown(0))
                {
                    audioSource.clip = clips[2];
                    audioSource.Play();
                    cabinets[0].GetComponent<ClickCabinet>().CloseURDoor();
                    cabinets[0].GetComponent<ClickCabinet>().isURDoorOpen = false;
                }
            }
        }

        else if (hitInfo.transform.name == "cabinet_door_103")
        {
            if (cabinets[0].GetComponent<ClickCabinet>().isDLDoorOpen == false)
            {
                interactionUI.GetComponent<Text>().text = "문을 연다";

                if (Input.GetMouseButtonDown(0))
                {
                    audioSource.clip = clips[2];
                    audioSource.Play();
                    cabinets[0].GetComponent<ClickCabinet>().OpenDLDoor();
                    cabinets[0].GetComponent<ClickCabinet>().isDLDoorOpen = true;
                }
            }
            else
            {
                interactionUI.GetComponent<Text>().text = "문을 닫는다.";

                if (Input.GetMouseButtonDown(0))
                {
                    audioSource.clip = clips[2];
                    audioSource.Play();
                    cabinets[0].GetComponent<ClickCabinet>().CloseDLDoor();
                    cabinets[0].GetComponent<ClickCabinet>().isDLDoorOpen = false;
                }
            }
        }

        else if (hitInfo.transform.name == "cabinet_door_104")
        {
            if (cabinets[0].GetComponent<ClickCabinet>().isDRDoorOpen == false)
            {
                interactionUI.GetComponent<Text>().text = "문을 연다";

                if (Input.GetMouseButtonDown(0))
                {
                    audioSource.clip = clips[2];
                    audioSource.Play();
                    cabinets[0].GetComponent<ClickCabinet>().OpenDRDoor();
                    cabinets[0].GetComponent<ClickCabinet>().isDRDoorOpen = true;
                }
            }
            else
            {
                interactionUI.GetComponent<Text>().text = "문을 닫는다.";

                if (Input.GetMouseButtonDown(0))
                {
                    audioSource.clip = clips[2];
                    audioSource.Play();
                    cabinets[0].GetComponent<ClickCabinet>().CloseDRDoor();
                    cabinets[0].GetComponent<ClickCabinet>().isDRDoorOpen = false;
                }
            }
        }

        else if (hitInfo.transform.name == "cabinet_drawer_101")
        {
            if (cabinets[0].GetComponent<ClickCabinet>().isLDrawerOpen == false)
            {
                interactionUI.GetComponent<Text>().text = "서랍을 연다";

                if (Input.GetMouseButtonDown(0))
                {
                    audioSource.clip = clips[0];
                    audioSource.Play();
                    cabinets[0].GetComponent<ClickCabinet>().OpenLDrawer();
                    cabinets[0].GetComponent<ClickCabinet>().isLDrawerOpen = true;
                }
            }
            else
            {
                interactionUI.GetComponent<Text>().text = "서랍을 닫는다.";

                if (Input.GetMouseButtonDown(0))
                {
                    audioSource.clip = clips[1];
                    audioSource.Play();
                    cabinets[0].GetComponent<ClickCabinet>().CloseLDrawer();
                    cabinets[0].GetComponent<ClickCabinet>().isLDrawerOpen = false;
                }
            }
        }

        else if (hitInfo.transform.name == "cabinet_drawer_102")
        {
            if (cabinets[0].GetComponent<ClickCabinet>().isRDrawerOpen == false)
            {
                interactionUI.GetComponent<Text>().text = "서랍을 연다";

                if (Input.GetMouseButtonDown(0))
                {
                    audioSource.clip = clips[0];
                    audioSource.Play();
                    cabinets[0].GetComponent<ClickCabinet>().OpenRDrawer();
                    cabinets[0].GetComponent<ClickCabinet>().isRDrawerOpen = true;
                }
            }
            else
            {
                interactionUI.GetComponent<Text>().text = "서랍을 닫는다.";

                if (Input.GetMouseButtonDown(0))
                {
                    audioSource.clip = clips[1];
                    audioSource.Play();
                    cabinets[0].GetComponent<ClickCabinet>().CloseRDrawer();
                    cabinets[0].GetComponent<ClickCabinet>().isRDrawerOpen = false;
                }
            }
        }

        // 캐비닛2
        else if (hitInfo.transform.name == "cabinet_door_201")
        {
            if (cabinets[1].GetComponent<ClickCabinet>().isULDoorOpen == false)
            {
                interactionUI.GetComponent<Text>().text = "문을 연다";

                if (Input.GetMouseButtonDown(0))
                {
                    audioSource.clip = clips[2];
                    audioSource.Play();
                    cabinets[1].GetComponent<ClickCabinet>().OpenULDoor();
                    cabinets[1].GetComponent<ClickCabinet>().isULDoorOpen = true;
                }
            }
            else
            {
                interactionUI.GetComponent<Text>().text = "문을 닫는다.";

                if (Input.GetMouseButtonDown(0))
                {
                    audioSource.clip = clips[2];
                    audioSource.Play();
                    cabinets[1].GetComponent<ClickCabinet>().CloseULDoor();
                    cabinets[1].GetComponent<ClickCabinet>().isULDoorOpen = false;
                }
            }
        }

        else if (hitInfo.transform.name == "cabinet_door_202")
        {
            if (cabinets[1].GetComponent<ClickCabinet>().isURDoorOpen == false)
            {
                interactionUI.GetComponent<Text>().text = "문을 연다";

                if (Input.GetMouseButtonDown(0))
                {
                    audioSource.clip = clips[2];
                    audioSource.Play();
                    cabinets[1].GetComponent<ClickCabinet>().OpenURDoor();
                    cabinets[1].GetComponent<ClickCabinet>().isURDoorOpen = true;
                }
            }
            else
            {
                interactionUI.GetComponent<Text>().text = "문을 닫는다.";

                if (Input.GetMouseButtonDown(0))
                {
                    audioSource.clip = clips[2];
                    audioSource.Play();
                    cabinets[1].GetComponent<ClickCabinet>().CloseURDoor();
                    cabinets[1].GetComponent<ClickCabinet>().isURDoorOpen = false;
                }
            }
        }

        else if (hitInfo.transform.name == "cabinet_door_203")
        {
            if (cabinets[1].GetComponent<ClickCabinet>().isDLDoorOpen == false)
            {
                interactionUI.GetComponent<Text>().text = "문을 연다";

                if (Input.GetMouseButtonDown(0))
                {
                    audioSource.clip = clips[2];
                    audioSource.Play();
                    cabinets[1].GetComponent<ClickCabinet>().OpenDLDoor();
                    cabinets[1].GetComponent<ClickCabinet>().isDLDoorOpen = true;
                }
            }
            else
            {
                interactionUI.GetComponent<Text>().text = "문을 닫는다.";

                if (Input.GetMouseButtonDown(0))
                {
                    audioSource.clip = clips[2];
                    audioSource.Play();
                    cabinets[1].GetComponent<ClickCabinet>().CloseDLDoor();
                    cabinets[1].GetComponent<ClickCabinet>().isDLDoorOpen = false;
                }
            }
        }

        else if (hitInfo.transform.name == "cabinet_door_204")
        {
            if (cabinets[1].GetComponent<ClickCabinet>().isDRDoorOpen == false)
            {
                interactionUI.GetComponent<Text>().text = "문을 연다";

                if (Input.GetMouseButtonDown(0))
                {
                    audioSource.clip = clips[2];
                    audioSource.Play();
                    cabinets[1].GetComponent<ClickCabinet>().OpenDRDoor();
                    cabinets[1].GetComponent<ClickCabinet>().isDRDoorOpen = true;
                }
            }
            else
            {
                interactionUI.GetComponent<Text>().text = "문을 닫는다.";

                if (Input.GetMouseButtonDown(0))
                {
                    audioSource.clip = clips[2];
                    audioSource.Play();
                    cabinets[1].GetComponent<ClickCabinet>().CloseDRDoor();
                    cabinets[1].GetComponent<ClickCabinet>().isDRDoorOpen = false;
                }
            }
        }

        else if (hitInfo.transform.name == "cabinet_drawer_201")
        {
            if (cabinets[1].GetComponent<ClickCabinet>().isLDrawerOpen == false)
            {
                interactionUI.GetComponent<Text>().text = "서랍을 연다";

                if (Input.GetMouseButtonDown(0))
                {
                    audioSource.clip = clips[0];
                    audioSource.Play();
                    cabinets[1].GetComponent<ClickCabinet>().OpenLDrawer();
                    cabinets[1].GetComponent<ClickCabinet>().isLDrawerOpen = true;
                }
            }
            else
            {
                interactionUI.GetComponent<Text>().text = "서랍을 닫는다.";

                if (Input.GetMouseButtonDown(0))
                {
                    audioSource.clip = clips[1];
                    audioSource.Play();
                    cabinets[1].GetComponent<ClickCabinet>().CloseLDrawer();
                    cabinets[1].GetComponent<ClickCabinet>().isLDrawerOpen = false;
                }
            }
        }

        else if (hitInfo.transform.name == "cabinet_drawer_202")
        {
            if (cabinets[1].GetComponent<ClickCabinet>().isRDrawerOpen == false)
            {
                interactionUI.GetComponent<Text>().text = "서랍을 연다";

                if (Input.GetMouseButtonDown(0))
                {
                    audioSource.clip = clips[0];
                    audioSource.Play();
                    cabinets[1].GetComponent<ClickCabinet>().OpenRDrawer();
                    cabinets[1].GetComponent<ClickCabinet>().isRDrawerOpen = true;
                }
            }
            else
            {
                interactionUI.GetComponent<Text>().text = "서랍을 닫는다.";

                if (Input.GetMouseButtonDown(0))
                {
                    audioSource.clip = clips[1];
                    audioSource.Play();
                    cabinets[1].GetComponent<ClickCabinet>().CloseRDrawer();
                    cabinets[1].GetComponent<ClickCabinet>().isRDrawerOpen = false;
                }
            }
        }

        // 테이블
        else if (hitInfo.transform.name == "table_drawer_l")
        {
            if (table.GetComponent<ClickTable>().isLDrawerOpen == false)
            {
                interactionUI.GetComponent<Text>().text = "서랍을 연다.";

                if (Input.GetMouseButtonDown(0))
                {
                    audioSource.clip = clips[0];
                    audioSource.Play();
                    table.GetComponent<ClickTable>().OpenLDrawer();
                    table.GetComponent<ClickTable>().isLDrawerOpen = true;
                }
            }
            else
            {
                interactionUI.GetComponent<Text>().text = "서랍을 닫는다.";

                if (Input.GetMouseButtonDown(0))
                {
                    audioSource.clip = clips[1];
                    audioSource.Play();
                    table.GetComponent<ClickTable>().CloseLDrawer();
                    table.GetComponent<ClickTable>().isLDrawerOpen = false;
                }
            }
        }

        else if (hitInfo.transform.name == "table_drawer_m")
        {
            if (table.GetComponent<ClickTable>().isMDrawerOpen == false)
            {
                interactionUI.GetComponent<Text>().text = "서랍을 연다.";

                if (Input.GetMouseButtonDown(0))
                {
                    audioSource.clip = clips[0];
                    audioSource.Play();
                    table.GetComponent<ClickTable>().OpenMDrawer();
                    table.GetComponent<ClickTable>().isMDrawerOpen = true;
                }
            }
            else
            {
                interactionUI.GetComponent<Text>().text = "서랍을 닫는다.";

                if (Input.GetMouseButtonDown(0))
                {
                    audioSource.clip = clips[1];
                    audioSource.Play();
                    table.GetComponent<ClickTable>().CloseMDrawer();
                    table.GetComponent<ClickTable>().isMDrawerOpen = false;
                }
            }
        }

        else if (hitInfo.transform.name == "table_drawer_r")
        {
            if (table.GetComponent<ClickTable>().isRDrawerOpen == false)
            {
                interactionUI.GetComponent<Text>().text = "서랍을 연다.";

                if (Input.GetMouseButtonDown(0))
                {
                    audioSource.clip = clips[0];
                    audioSource.Play();
                    table.GetComponent<ClickTable>().OpenRDrawer();
                    table.GetComponent<ClickTable>().isRDrawerOpen = true;
                }
            }
            else
            {
                interactionUI.GetComponent<Text>().text = "서랍을 닫는다.";

                if (Input.GetMouseButtonDown(0))
                {
                    audioSource.clip = clips[1];
                    audioSource.Play();
                    table.GetComponent<ClickTable>().CloseRDrawer();
                    table.GetComponent<ClickTable>().isRDrawerOpen = false;
                }
            }
        }

        // 실타래
        else if(hitInfo.transform.name == "red_thread" && arm.childCount == 0)
        {
            interactionUI.GetComponent<Text>().text = "물건을 든다.";

            if (Input.GetMouseButtonDown(0))
            {
                audioSource.clip = clips[4];
                audioSource.Play();
                PickUpItem(hitInfo);
            }
        }

        else if (hitInfo.transform.name == "orange_thread" && arm.childCount == 0)
        {
            interactionUI.GetComponent<Text>().text = "물건을 든다.";

            if (Input.GetMouseButtonDown(0))
            {
                audioSource.clip = clips[4];
                audioSource.Play();
                PickUpItem(hitInfo);
            }
        }

        else if (hitInfo.transform.name == "yellow_thread" && arm.childCount == 0)
        {
            interactionUI.GetComponent<Text>().text = "물건을 든다.";

            if (Input.GetMouseButtonDown(0))
            {
                audioSource.clip = clips[4];
                audioSource.Play();
                PickUpItem(hitInfo);
            }
        }

        else if (hitInfo.transform.name == "green_thread" && arm.childCount == 0)
        {
            interactionUI.GetComponent<Text>().text = "물건을 든다.";

            if (Input.GetMouseButtonDown(0))
            {
                audioSource.clip = clips[4];
                audioSource.Play();
                PickUpItem(hitInfo);
            }
        }

        else if (hitInfo.transform.name == "blue_thread" && arm.childCount == 0)
        {
            interactionUI.GetComponent<Text>().text = "물건을 든다.";

            if (Input.GetMouseButtonDown(0))
            {
                audioSource.clip = clips[4];
                audioSource.Play();
                PickUpItem(hitInfo);
            }
        }

        else if (hitInfo.transform.name == "purple_thread" && arm.childCount == 0)
        {
            interactionUI.GetComponent<Text>().text = "물건을 든다.";

            if (Input.GetMouseButtonDown(0))
            {
                audioSource.clip = clips[4];
                audioSource.Play();
                PickUpItem(hitInfo);
            }
        }

        else if (hitInfo.transform.name == "white_thread" && arm.childCount == 0)
        {
            interactionUI.GetComponent<Text>().text = "물건을 든다.";

            if (Input.GetMouseButtonDown(0))
            {
                audioSource.clip = clips[4];
                audioSource.Play();
                PickUpItem(hitInfo);
            }
        }

        else if (hitInfo.transform.name == "black_thread" && arm.childCount == 0)
        {
            interactionUI.GetComponent<Text>().text = "물건을 든다.";

            if (Input.GetMouseButtonDown(0))
            {
                audioSource.clip = clips[4];
                audioSource.Play();
                PickUpItem(hitInfo);
            }
        }

        // 새장 열쇠
        else if(hitInfo.transform.name == "rust_key" && arm.childCount == 0)
        {
            interactionUI.GetComponent<Text>().text = "열쇠를 든다.";

            if (Input.GetMouseButtonDown(0))
            {
                audioSource.clip = clips[4];
                audioSource.Play();
                PickUpItem(hitInfo);
            }
        }

        // 새장
        else if(hitInfo.transform.name == "cage")
        {
            if (arm.childCount == 1)
            {
                if (arm.GetChild(0).name == "rust_key")
                {
                    interactionUI.GetComponent<Text>().text = "새장을 연다.";
                    if (Input.GetMouseButtonDown(0))
                    {
                        audioSource.clip = clips[3];
                        audioSource.Play();
                        cage.GetComponent<ClickCage>().OpenCage();
                        cage.GetComponent<MeshCollider>().enabled = false;
                        Transform usedKey = arm.GetChild(0);
                        usedKey.parent = null;
                        usedKey.gameObject.SetActive(false);
                    }
                }
            }
            else
            {
                interactionUI.GetComponent<Text>().text = "새장이 잠겨있다.";
                if (Input.GetMouseButtonDown(0))
                {
                    StartCoroutine("Dialog", "잠겨있어. 열쇠를 먼저 찾아야 할 것 같아...");
                }
            } 
        }

        // 눈알
        else if(hitInfo.transform.name == "eyeball_yellow" && arm.childCount == 0)
        {
            interactionUI.GetComponent<Text>().text = "물건을 든다.";

            if (Input.GetMouseButtonDown(0))
            {
                audioSource.clip = clips[4];
                audioSource.Play();
                PickUpItem(hitInfo);
            }
        }

        else if (hitInfo.transform.name == "eyeball_lightgreen" && arm.childCount == 0)
        {
            interactionUI.GetComponent<Text>().text = "물건을 든다.";

            if (Input.GetMouseButtonDown(0))
            {
                audioSource.clip = clips[4];
                audioSource.Play();
                PickUpItem(hitInfo);
            }
        }

        else if (hitInfo.transform.name == "eyeball_green" && arm.childCount == 0)
        {
            interactionUI.GetComponent<Text>().text = "물건을 든다.";

            if (Input.GetMouseButtonDown(0))
            {
                audioSource.clip = clips[4];
                audioSource.Play();
                PickUpItem(hitInfo);
            }
        }

        else if (hitInfo.transform.name == "eyeball_greenblue" && arm.childCount == 0)
        {
            interactionUI.GetComponent<Text>().text = "물건을 든다.";

            if (Input.GetMouseButtonDown(0))
            {
                audioSource.clip = clips[4];
                audioSource.Play();
                PickUpItem(hitInfo);
            }
        }

        else if (hitInfo.transform.name == "eyeball_blue" && arm.childCount == 0)
        {
            interactionUI.GetComponent<Text>().text = "물건을 든다.";

            if (Input.GetMouseButtonDown(0))
            {
                audioSource.clip = clips[4];
                audioSource.Play();
                PickUpItem(hitInfo);
            }
        }

        else if (hitInfo.transform.name == "eyeball_purple" && arm.childCount == 0)
        {
            interactionUI.GetComponent<Text>().text = "물건을 든다.";

            if (Input.GetMouseButtonDown(0))
            {
                audioSource.clip = clips[4];
                audioSource.Play();
                PickUpItem(hitInfo);
            }
        }

        // 파란새
        else if(hitInfo.transform.name == "bluejay" && arm.childCount == 0)
        {
            interactionUI.GetComponent<Text>().text = "깃털을 뽑는다.";

            if (featherCount < 3 && Input.GetMouseButtonDown(0))
            {
                audioSource.clip = clips[4];
                audioSource.Play();
                feathers[featherCount].SetActive(true);
                feathers[featherCount].transform.GetComponent<Rigidbody>().useGravity = false;
                feathers[featherCount].transform.GetComponent<Rigidbody>().isKinematic = true;
                feathers[featherCount].transform.position = arm.position;
                feathers[featherCount].transform.parent = arm;
                featherCount++;
            }
        }

        // 깃털
        else if((hitInfo.transform.name == "feather1" || hitInfo.transform.name == "feather2" || hitInfo.transform.name == "feather3") && arm.childCount == 0)
        {
            interactionUI.GetComponent<Text>().text = "물건을 든다.";

            if (Input.GetMouseButtonDown(0))
            {
                audioSource.clip = clips[4];
                audioSource.Play();
                PickUpItem(hitInfo);
            }
        }

        // 박스
        else if(hitInfo.transform.name == "box")
        {
            interactionUI.GetComponent<Text>().text = "물건을 넣는다.";

            if (arm.childCount == 1)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    audioSource.clip = clips[5];
                    audioSource.Play();
                    Transform obj = arm.GetChild(0);
                    obj.parent = null;
                    obj.transform.GetComponent<Rigidbody>().useGravity = true;
                    obj.transform.GetComponent<Rigidbody>().isKinematic = false;
                    Vector3 pos = new Vector3(hitInfo.transform.position.x + Random.Range(1.5f, 2.5f), hitInfo.transform.position.y + Random.Range(0.5f, 1.5f), hitInfo.transform.position.z);
                    obj.transform.position = pos;
                }
            }
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    StartCoroutine("Dialog", "여기에 뭔가를 넣어야 하는 건가..?");
                }
            }
        }

        // 드림캐쳐
        else if(hitInfo.transform.name == "Dreamcatcher" && arm.childCount == 0)
        {
            interactionUI.GetComponent<Text>().text = "드림캐쳐를 든다.";

            if (Input.GetMouseButtonDown(0))
            {
                audioSource.clip = clips[4];
                audioSource.Play();
                interactionUI.GetComponent<Text>().text = "";
                PickUpItem(hitInfo);
                StartCoroutine("Dialog", "드림캐쳐를 걸만한 곳을 찾아야 해...");
            }
        }

        // 못
        else if(hitInfo.transform.name == "nail" && arm.childCount == 1)
        {
            if (arm.GetChild(0).name == "Dreamcatcher")
            {
                interactionUI.GetComponent<Text>().text = "드림캐쳐를 건다.";

                if (Input.GetMouseButtonDown(0))
                {
                    Transform obj = arm.GetChild(0);
                    obj.parent = null;
                    obj.gameObject.SetActive(false);
                    dreamcatcher.SetActive(true);
                    door.SetActive(true);
                    gameManager.IncreaseState();
                }
            }
        }

        // 문
        else if(hitInfo.transform.name == "Door")
        {
            interactionUI.GetComponent<Text>().text = "밖으로 나간다.";

            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine("FadeOut6");
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

    IEnumerator Dialog(string txt)
    {
        dialogUI.SetActive(true);
        dialogUI.GetComponentInChildren<Text>().text = txt;
        yield return new WaitForSeconds(2f);
        dialogUI.SetActive(false);
    }

    IEnumerator FadeOut6()
    {
        fadeOutPanel.SetActive(true);
        yield return new WaitForSeconds(5f);
        SceneManagement.completedStage = 6;
        sceneManagement.movetoNextStage();
    }
}
