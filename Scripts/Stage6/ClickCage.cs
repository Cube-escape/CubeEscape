using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickCage : MonoBehaviour
{
    [SerializeField]
    private GameObject lockedCage;

    [SerializeField]
    private GameObject cageLock;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenCage()
    {
        lockedCage.SetActive(false);
        cageLock.SetActive(false);
    }
}
