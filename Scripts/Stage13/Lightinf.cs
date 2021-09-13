using UnityEngine;

public class Lightinf : MonoBehaviour
{
    private float speed = 3f;//감도

     public GameObject light; // 조명에서 나오는 빛.
    public bool GetPollenOfLight; //빛의 꽃가루를 조명장치에 넣었는지 여부.

 



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
