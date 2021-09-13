using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager7 : MonoBehaviour
{

    
    private SceneManagement sm7 = new SceneManagement();
    [SerializeField] GameObject Keypad;
    [SerializeField] GameObject Bottom;

    [SerializeField] InteractionController_stage7 ic7;

    public static bool isPasswordright;


    private void Awake()
    {
       
    }

    // Start is called before the first frame update
    void Start()
    {
        isPasswordright = false;
       

    }

    // Update is called once per frame
    void Update()
    {

       
        if(isPasswordright == true)
        {
            SceneManagement.completedStage = 7;
            sm7.movetoNextStage();
        }

    }

   
}
