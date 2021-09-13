using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeNametagMaterial : MonoBehaviour
{
    [SerializeField]
    private Stage2GameManager gameManager;

    [SerializeField]
    private Material mat;

    private int state;
    private bool b = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        state = gameManager.GetState();

        if(state == 3 && b)
        {
            GetComponent<SpriteRenderer>().material = mat;
            b = false;
        }
    }
}
