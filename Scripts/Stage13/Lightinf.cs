using UnityEngine;

public class Lightinf : MonoBehaviour
{
    private float speed = 3f;//����

     public GameObject light; // ������ ������ ��.
    public bool GetPollenOfLight; //���� �ɰ��縦 ������ġ�� �־����� ����.

 



private void Awake()
    {
        light.SetActive(false);

    }


    private void OnEnable()
    {
        light.SetActive(true);
    }

}



/*   public float RotationSpeed = 5f;


   private void OnMouseDrag()
   {
       float rotX = Input.GetAxis("Mouse X") * RotationSpeed * Mathf.Deg2Rad;
       float roty = Input.GetAxis("Mouse Y") * RotationSpeed * Mathf.Deg2Rad;

       transform.Rotate(Vector3.up, -rotX);
       transform.Rotate(Vector3.right, roty);
   }

*/
