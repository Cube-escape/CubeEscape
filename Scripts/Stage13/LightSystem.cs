using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSystem : MonoBehaviour
{

   public bool GetPollenOfLight; //���� �ɰ��縦 ������ġ�� �־����� ����.

    
   public GameObject [] light; // ������ ������ ��.





    // Update is called once per frame
    void Update()
    {
        checkStar();
       
    }


    void checkStar() //light �ý����� ��������� Ȯ��
    {

        if (light[0].activeInHierarchy && light[1].activeInHierarchy && light[2].activeInHierarchy && light[3].activeInHierarchy && light[0].activeInHierarchy)
            Stage13Gamemanager.isLightingSystemSetRightly = true;
    }
}
