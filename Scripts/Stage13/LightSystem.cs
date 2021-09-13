using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSystem : MonoBehaviour
{

   public bool GetPollenOfLight; //빛의 꽃가루를 조명장치에 넣었는지 여부.

    
   public GameObject [] light; // 조명에서 나오는 빛.





    // Update is called once per frame
    void Update()
    {
        checkStar();
       
    }


    void checkStar() //light 시스템이 별모양인지 확인
    {

        if (light[0].activeInHierarchy && light[1].activeInHierarchy && light[2].activeInHierarchy && light[3].activeInHierarchy && light[0].activeInHierarchy)
            Stage13Gamemanager.isLightingSystemSetRightly = true;
    }
}
