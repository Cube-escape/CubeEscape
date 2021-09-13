using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer10 : MonoBehaviour
{
    // move player
    public float speed;

    [SerializeField] InteractionController10 ic10;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    // rotate camera
    public float sensitivity = 2f;
    public float yRotationLimit = 80f;

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
            if (ic10.isonchair == true)
            {
                // transform.position = new Vector3((float)122.77, (float)53.04, (float)14.318);
                // rotate camera
                rotation.x += Input.GetAxis("Mouse X") * sensitivity;
                rotation.y += Input.GetAxis("Mouse Y") * sensitivity;
                rotation.y = Mathf.Clamp(rotation.y, -yRotationLimit, yRotationLimit);
                var xQuat = Quaternion.AngleAxis(rotation.x, Vector3.up);
                var yQuat = Quaternion.AngleAxis(rotation.y, Vector3.left);

                transform.localRotation = xQuat;
                cam.transform.localRotation = yQuat;
            }
            else
            {
                // move player
                moveDirection = new Vector3(Input.GetAxis("Horizontal"), -0.73f, Input.GetAxis("Vertical"));
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
            }
        }
    }
       

}
