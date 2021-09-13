using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpotlight : MonoBehaviour
{
    [SerializeField]
    private GameObject[] paints;

    private int count = 0;
    private Color32[] lightColors = { new Color32(255, 255, 255, 255), new Color32(200, 0, 0, 255) };
    private bool changePaints = false;

    public void UpCount()
    {
        count = (count + 1) % 3;
    }

    public int GetCount()
    {
        return count;
    }

    public void SetChangePaints()
    {
        changePaints = true;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (count == 0)
        {
            GetComponent<Light>().enabled = false;
            if (changePaints)
            {
                paints[0].SetActive(true);
                paints[1].SetActive(false);
            }
        }
        else if (count == 1)
        {
            GetComponent<Light>().enabled = true;
            GetComponent<Light>().color = lightColors[0];
            GetComponent<Light>().intensity = 30;
        }
        else
        {
            GetComponent<Light>().enabled = true;
            GetComponent<Light>().color = lightColors[1];
            GetComponent<Light>().intensity = 30;
            if (changePaints)
            {
                paints[0].SetActive(false);
                paints[1].SetActive(true);
            }
        }

    }
}
