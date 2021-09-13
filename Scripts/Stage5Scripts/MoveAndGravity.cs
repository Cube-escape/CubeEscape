using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndGravity : MonoBehaviour
{

    [SerializeField]
    private float speed; //캐릭터 이동 속도
    private float gravity; //캐릭터의 중력

    private CharacterController cc;
    private Vector3 MoveDir; //캐릭터의 이동 방향

    private Camera cam; //카메라 
    private float sensitivity=1f; //회전 민감도
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
                //위 아래 움직임 설정
                MoveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                //벡터를 로컬 좌표계 기준에서 월드 좌표계 기준으로 변환
                MoveDir = transform.TransformDirection(MoveDir);
                MoveDir *= speed;//스피드 증가

            }
            MoveDir.y -= gravity * Time.deltaTime; //중력 적용
            cc.Move(MoveDir * Time.deltaTime); //캐릭터 움직임

            //카메라 회전
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
