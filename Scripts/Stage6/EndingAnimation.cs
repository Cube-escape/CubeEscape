using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingAnimation : MonoBehaviour
{
    [SerializeField]
    private Camera animationCam;

    [SerializeField]
    private GameObject scaryman;

    [SerializeField]
    private GameObject explosion;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject canvas;

    private float timer = 3.0f;
    private bool timerStart = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timerStart)
        {
            if(timer < 0)
            {
                player.SetActive(true);
                canvas.SetActive(true);
                animationCam.gameObject.SetActive(false);
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
    }

    public void StartAnimation()
    {
        player.SetActive(false);
        canvas.SetActive(false);
        animationCam.gameObject.SetActive(true);
        // 폭발 이펙트 켜기
        explosion.SetActive(true);
        // scaryman 사라지기
        scaryman.SetActive(false);
        timerStart = true;
    }
}
