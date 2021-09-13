using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndGravity : MonoBehaviour
{

    [SerializeField]
    private float speed; //ĳ���� �̵� �ӵ�
    private float gravity; //ĳ������ �߷�

    private CharacterController cc;
    private Vector3 MoveDir; //ĳ������ �̵� ����

    private Camera cam; //ī�޶� 
    private float sensitivity=1f; //ȸ�� �ΰ���
    private float yRotationLimit = 80f; 
    private Vector2 rotation = Vector2.zero;
    void Start()
    {
      
        gravity = 30.1f;

        MoveDir = Vector3.zero;
        cc = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        cam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.deltaTime != 0)
        {
            if (cc.isGrounded)
            {
                //�� �Ʒ� ������ ����
                MoveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                //���͸� ���� ��ǥ�� ���ؿ��� ���� ��ǥ�� �������� ��ȯ
                MoveDir = transform.TransformDirection(MoveDir);
                MoveDir *= speed;//���ǵ� ����

            }
            MoveDir.y -= gravity * Time.deltaTime; //�߷� ����
            cc.Move(MoveDir * Time.deltaTime); //ĳ���� ������

            //ī�޶� ȸ��
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
