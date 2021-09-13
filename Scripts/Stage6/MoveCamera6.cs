using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera6 : MonoBehaviour
{
    public float sensitivity = 10.0f;

    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {
            // zoom in & out
            float scroll = Input.GetAxis("Mouse ScrollWheel") * sensitivity;

            // �ִ�� zoom in �� ���
            if (cam.fieldOfView <= 20.0f && scroll < 0)
                cam.fieldOfView = 20.0f;
            // �ִ�� zoom out �� ���
            else if (cam.fieldOfView >= 60.0f && scroll > 0)
                cam.fieldOfView = 60.0f;
            else
                cam.fieldOfView += scroll;
        }
    }
}
