using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager12 : MonoBehaviour
{
    [SerializeField]
    private GameObject fadeInPanel;

    private int state;

    public void IncreaseState()
    {
        state++;
    }

    public int GetState()
    {
        return state;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("FadeIn12");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FadeIn12()
    {
        fadeInPanel.SetActive(true);
        yield return new WaitForSeconds(6f);
        fadeInPanel.SetActive(false);
    }
}
