using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer6 : MonoBehaviour
{
    // move player
    [SerializeField]
    private float speed;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    // rotate camera
    [SerializeField]
    private float sensitivity = 2f;

    [SerializeField]
    private float yRotationLimit = 80f;

    /*
    [SerializeField]
    private GameObject leftHand;

    [SerializeField]
    private float flashlightSensitivity;
    */

    private Camera cam;
    private Vector2 rotation = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        cam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {
            // move player
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), -0.5f, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            controller.Move(moveDirection * Time.deltaTime);

            // rotate camera
            rotation.x += Input.GetAxis("Mouse X") * sensitivity;
            rotation.y += Input.GetAxis("Mouse Y") * sensitivity;
            rotation.y = Mathf.Clamp(rotation.y, -yRotationLimit, yRotationLimit);
            var xQuat = Quaternion.AngleAxis(rotation.x, Vector3.up);
            var yQuat = Quaternion.AngleAxis(rotation.y, Vector3.left);

            transform.localRotation = xQuat;
            cam.transform.localRotation = yQuat;
            //leftHand.transform.localRotation = Quaternion.Euler(new Vector3(-rotation.y / sensitivity * flashlightSensitivity, 0f, 0f));
        }
    }
}
