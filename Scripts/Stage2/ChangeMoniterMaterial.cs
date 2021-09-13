using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMoniterMaterial : MonoBehaviour
{
    [SerializeField]
    private Material turnOnMoniter;

    [SerializeField]
    private int goalState;

    [SerializeField]
    private Stage2GameManager gameManager;

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
        if(state == goalState && b)
        {
            Material[] mat = GetComponent<MeshRenderer>().materials;
            mat[2] = turnOnMoniter;
            GetComponent<MeshRenderer>().materials = mat;
            b = false;
        }
    }
}
