using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickCabinet : MonoBehaviour
{
    [SerializeField]
    private GameObject[] doorAndDrawers;

    private float drawersOriginalLocalZ;
    public bool isULDoorOpen;
    public bool isURDoorOpen;
    public bool isDLDoorOpen;
    public bool isDRDoorOpen;
    public bool isLDrawerOpen;
    public bool isRDrawerOpen;

    // Start is called before the first frame update
    void Start()
    {
        drawersOriginalLocalZ = doorAndDrawers[4].transform.localPosition.z;
        isULDoorOpen = false;
        isURDoorOpen = false;
        isDLDoorOpen = false;
        isDRDoorOpen = false;
        isLDrawerOpen = false;
        isRDrawerOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ¿­±â
    public void OpenULDoor()
    {
        doorAndDrawers[0].transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
    }

    public void OpenURDoor()
    {
        doorAndDrawers[1].transform.localRotation = Quaternion.Euler(0f, -90f, 0f);
    }

    public void OpenDLDoor()
    {
        doorAndDrawers[2].transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
    }

    public void OpenDRDoor()
    {
        doorAndDrawers[3].transform.localRotation = Quaternion.Euler(0f, -90f, 0f);
    }

    public void OpenLDrawer()
    {
        float localX = doorAndDrawers[4].transform.localPosition.x;
        float localY = doorAndDrawers[4].transform.localPosition.y;
        doorAndDrawers[4].transform.localPosition = new Vector3(localX, localY, 0.5f);
    }

    public void OpenRDrawer()
    {
        float localX = doorAndDrawers[5].transform.localPosition.x;
        float localY = doorAndDrawers[5].transform.localPosition.y;
        doorAndDrawers[5].transform.localPosition = new Vector3(localX, localY, 0.5f);
    }

    // ´Ý±â
    public void CloseULDoor()
    {
        doorAndDrawers[0].transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
    }

    public void CloseURDoor()
    {
        doorAndDrawers[1].transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
    }

    public void CloseDLDoor()
    {
        doorAndDrawers[2].transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
    }

    public void CloseDRDoor()
    {
        doorAndDrawers[3].transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
    }

    public void CloseLDrawer()
    {
        float localX = doorAndDrawers[4].transform.localPosition.x;
        float localY = doorAndDrawers[4].transform.localPosition.y;
        doorAndDrawers[4].transform.localPosition = new Vector3(localX, localY, drawersOriginalLocalZ);
    }

    public void CloseRDrawer()
    {
        float localX = doorAndDrawers[5].transform.localPosition.x;
        float localY = doorAndDrawers[5].transform.localPosition.y;
        doorAndDrawers[5].transform.localPosition = new Vector3(localX, localY, drawersOriginalLocalZ);
    }
}
