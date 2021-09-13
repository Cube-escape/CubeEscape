using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider5 : MonoBehaviour
{

    SceneManagement sn = new SceneManagement();
    
    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision!");
        if (collision.transform.name == "Cube")
        {
            Debug.Log("Collision!!");
            this.transform.position = new Vector3(211, 103, -3003);
        }
        else if (collision.transform.name == "Cube (1)")
        {
            Debug.Log("Collision!!");
            this.transform.position = new Vector3(211, 103, -5116);
        }
        else if (collision.transform.name == "Cube (2)")
        {
            Debug.Log("Collision!!");
            this.transform.position = new Vector3(867, 103, -3736);
        }
        else if (collision.transform.name == "Cube (3)")
        {
            Debug.Log("Collision!!");
            this.transform.position = new Vector3(-1155, 103, -3736);
        }
    }
    

}