using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffScaleCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject mainCamera;

    [SerializeField]
    private Camera scaleCamera;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject interactionUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(scaleCamera.enabled == true)
        {
            if (Input.GetMouseButtonDown(1))
            {
                scaleCamera.enabled = false;
                mainCamera.SetActive(true);
                interactionUI.SetActive(true);
                player.GetComponent<MovePlayer12>().enabled = true;
            }
        }
    }

}
