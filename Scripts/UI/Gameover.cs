using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour
{
    SceneManagement sm;
    // Start is called before the first frame update
    void Start()
    {
        sm = new SceneManagement();
    }

    
    // Update is called once per frame
    void Update()
    {
      
        if (Input.GetKeyDown("r"))
            sm.restartStage();
    }
}
