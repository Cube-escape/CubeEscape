using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickTable : MonoBehaviour
{
    [SerializeField]
    private GameObject[] drawers;

    private float drawersOriginalLocalZ;
    public bool isLDrawerOpen;
    public bool isMDrawerOpen;
    public bool isRDrawerOpen;

    // Start is called before the first frame update
    void Start()
    {
        drawersOriginalLocalZ = drawers[0].transform.localPosition.z;
        isLDrawerOpen = false;
        isMDrawerOpen = false;
        isRDrawerOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ¿­±â
    public void OpenLDrawer()
    {
        float localX = drawers[0].transform.localPosition.x;
        float localY = drawers[0].transform.localPosition.y;
        drawers[0].transform.localPosition = new Vector3(localX, localY, 0.25f);
    }

    public void OpenMDrawer()
    {
        float localX = drawers[1].transform.localPosition.x;
        float localY = drawers[1].transform.localPosition.y;
        drawers[1].transform.localPosition = new Vector3(localX, localY, 0.25f);
    }

    public void OpenRDrawer()
    {
        float localX = drawers[2].transform.localPosition.x;
        float localY = drawers[2].transform.localPosition.y;
        drawers[2].transform.localPosition = new Vector3(localX, localY, 0.25f);
    }

    // ´Ý±â
    public void CloseLDrawer()
    {
        float localX = drawers[0].transform.localPosition.x;
        float localY = drawers[0].transform.localPosition.y;
        drawers[0].transform.localPosition = new Vector3(localX, localY, drawersOriginalLocalZ);
    }

    public void CloseMDrawer()
    {
        float localX = drawers[1].transform.localPosition.x;
        float localY = drawers[1].transform.localPosition.y;
        drawers[1].transform.localPosition = new Vector3(localX, localY, drawersOriginalLocalZ);
    }

    public void CloseRDrawer()
    {
        float localX = drawers[2].transform.localPosition.x;
        float localY = drawers[2].transform.localPosition.y;
        drawers[2].transform.localPosition = new Vector3(localX, localY, drawersOriginalLocalZ);
    }
}
