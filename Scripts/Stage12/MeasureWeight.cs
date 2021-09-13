using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeasureWeight : MonoBehaviour
{
    private int totalWeight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        totalWeight += collision.gameObject.GetComponent<Weight>().GetWeight();
        Debug.Log("total: " + totalWeight);
    }

    private void OnCollisionExit(Collision collision)
    {
        totalWeight -= collision.gameObject.GetComponent<Weight>().GetWeight();
        Debug.Log("total: " + totalWeight);
    }

    public int GetTotalWeight()
    {
        return totalWeight;
    }

}
