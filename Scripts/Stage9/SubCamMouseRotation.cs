using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCamMouseRotation : MonoBehaviour
{

    [SerializeField]
    private float lookSensitivity;

    [SerializeField]
    private float cameraRotationLimit;
    private float currentCameraRotationX = 0;
    private float currentCameraRotationY = 0;

    [SerializeField]
    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        CameraRotation();
    }
    void CameraRotation() {

        float yRotation = Input.GetAxisRaw("Mouse X");
        float cameraRotationY = yRotation * lookSensitivity;
        currentCameraRotationY += cameraRotationY;

        float xRotation = Input.GetAxisRaw("Mouse Y");
        float cameraRotationX = xRotation * lookSensitivity;
        currentCameraRotationX += cameraRotationX;

        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -45, -20);
        currentCameraRotationY = Mathf.Clamp( currentCameraRotationY, -cameraRotationLimit, cameraRotationLimit);

        cam.transform.localEulerAngles = new Vector3(-currentCameraRotationX,currentCameraRotationY,0f);

    }
}
