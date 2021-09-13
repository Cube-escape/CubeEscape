using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDreamCatcherPaper : MonoBehaviour
{
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
            Cursor.lockState = CursorLockMode.Locked;
            player.GetComponent<MovePlayer6>().enabled = true;
            gameObject.SetActive(false);
        }
    }
}
