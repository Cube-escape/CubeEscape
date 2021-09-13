using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSlender : MonoBehaviour
{
    // move player
    [SerializeField]
    private float speed;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    // rotate camera
    [SerializeField]
    private float sensitivity = 2f;

    private Vector2 rotation = Vector2.zero;

    [SerializeField]
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // move player
        moveDirection = new Vector3(-Input.GetAxis("Horizontal"), 0, -Input.GetAxis("Vertical"));
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;

        controller.Move(moveDirection * Time.deltaTime);

        // rotate camera
        rotation.x += Input.GetAxis("Mouse X") * sensitivity;
        var xQuat = Quaternion.AngleAxis(rotation.x, Vector3.up);

        transform.localRotation = xQuat;

        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)
            || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("move", true);
        }
        else
        {
            anim.SetBool("move", false);
        }
    }
}
