using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFlashlight : MonoBehaviour
{
    [SerializeField]
    private float sensitivity = 2f;

    [SerializeField]
    private float yRotationLimit = 80f;

    private Vector2 rotation = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rotation.y += Input.GetAxis("Mouse Y") * sensitivity;
        rotation.y = Mathf.Clamp(rotation.y, -yRotationLimit, yRotationLimit);
        var yQuat = Quaternion.AngleAxis(rotation.y, Vector3.left);

        transform.localRotation = yQuat;
    }
}
