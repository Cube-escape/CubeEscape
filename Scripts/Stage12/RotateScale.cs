using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScale : MonoBehaviour
{
    [SerializeField]
    private int state;

    [SerializeField]
    private GameObject head;

    [SerializeField]
    private GameObject left;

    [SerializeField]
    private GameObject right;

    [SerializeField]
    private GameObject leftPlate;

    [SerializeField]
    private GameObject rightPlate;

    [SerializeField]
    private AudioSource audioSourceEffect;

    [SerializeField]
    private AudioClip clip;

    private Quaternion headRotation;
    private Vector3 leftPosition;
    private Vector3 rightPosition;
    private int gap;
    private bool first = true;

    // Start is called before the first frame update
    void Start()
    {
        headRotation = head.transform.localRotation;
        leftPosition = left.transform.localPosition;
        rightPosition = right.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        gap = leftPlate.GetComponent<MeasureWeight>().GetTotalWeight() - rightPlate.GetComponent<MeasureWeight>().GetTotalWeight();
        if(gap < -10)
        {
            state = 1;
            first = false;
        }
        else if(gap < 0)
        {
            state = 2;
            first = false;
        }
        else if(gap == 0)
        {
            if (state != 3 && !first)
            {
                audioSourceEffect.clip = clip;
                audioSourceEffect.Play();
            }
            state = 3;
        }
        else if(gap > 10)
        {
            state = 5;
            first = false;
        }
        else if(gap > 0)
        {
            state = 4;
            first = false;
        }

        if(state == 1)
        {
            head.transform.localRotation = Quaternion.Euler(headRotation.x, headRotation.y, -15f);
            Vector3 newLeft = new Vector3(leftPosition.x, 0.69f, leftPosition.z);
            left.transform.localPosition = Vector3.Lerp(left.transform.localPosition, newLeft, Time.deltaTime * 0.7f);
            Vector3 newRight = new Vector3(rightPosition.x, 0.51f, rightPosition.z);
            right.transform.localPosition = Vector3.Lerp(right.transform.localPosition, newRight, Time.deltaTime * 0.7f);
        }
        else if (state == 2)
        {
            head.transform.localRotation = Quaternion.Euler(headRotation.x, headRotation.y, -10f);
            Vector3 newLeft = new Vector3(leftPosition.x, 0.66f, leftPosition.z);
            left.transform.localPosition = Vector3.Lerp(left.transform.localPosition, newLeft, Time.deltaTime * 0.7f);
            Vector3 newRight = new Vector3(rightPosition.x, 0.54f, rightPosition.z);
            right.transform.localPosition = Vector3.Lerp(right.transform.localPosition, newRight, Time.deltaTime * 0.7f);
        }
        else if (state == 3)
        {
            head.transform.localRotation = Quaternion.Euler(headRotation.x, headRotation.y, 0f);
            Vector3 newLeft = new Vector3(leftPosition.x, 0.60f, leftPosition.z);
            left.transform.localPosition = Vector3.Lerp(left.transform.localPosition, newLeft, Time.deltaTime * 0.7f);
            Vector3 newRight = new Vector3(rightPosition.x, 0.60f, rightPosition.z);
            right.transform.localPosition = Vector3.Lerp(right.transform.localPosition, newRight, Time.deltaTime * 0.7f);
        }
        else if (state == 4)
        {
            head.transform.localRotation = Quaternion.Euler(headRotation.x, headRotation.y, 10f);
            Vector3 newLeft = new Vector3(leftPosition.x, 0.54f, leftPosition.z);
            left.transform.localPosition = Vector3.Lerp(left.transform.localPosition, newLeft, Time.deltaTime * 0.7f);
            Vector3 newRight = new Vector3(rightPosition.x, 0.66f, rightPosition.z);
            right.transform.localPosition = Vector3.Lerp(right.transform.localPosition, newRight, Time.deltaTime * 0.7f);
        }
        else if (state == 5)
        {
            head.transform.localRotation = Quaternion.Euler(headRotation.x, headRotation.y, 15f);
            Vector3 newLeft = new Vector3(leftPosition.x, 0.51f, leftPosition.z);
            left.transform.localPosition = Vector3.Lerp(left.transform.localPosition, newLeft, Time.deltaTime * 0.7f);
            Vector3 newRight = new Vector3(rightPosition.x, 0.69f, rightPosition.z);
            right.transform.localPosition = Vector3.Lerp(right.transform.localPosition, newRight, Time.deltaTime * 0.7f);
        }
    }

    public int GetGap()
    {
        return gap;
    }

}
