using UnityEngine;

public class ObjectRotater : MonoBehaviour
{
    private float speed = 3f;//°¨µµ

    

   

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            transform.Rotate(0f, -Input.GetAxis("Mouse X") * speed, 0f, Space.World);
            transform.Rotate(-Input.GetAxis("Mouse Y") * speed, 0f, 0f);
            
        }
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
