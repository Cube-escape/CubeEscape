using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WhaleMaterial : MonoBehaviour
{
    public Image preImage;
    public Sprite FirstImage;
    public Sprite SecondImage;
    public Sprite ThirdImage;
    public Sprite FourthImage;
    public GameObject Shape;
    public GameObject drawer;
    AudioSource audiosource;
    AudioSource audiosource2;
    int num = 1;
    int num2 = 2;
    bool state = true;
    int[] arr = new int[5];

    [SerializeField] GameObject Key;




    void Start() {
        Shape = GameObject.FindGameObjectsWithTag("shape")[0];
        for (int i = 0; i < 5; i++) arr[i] = 1;
        audiosource = GetComponent<AudioSource>();
        audiosource2 = drawer.GetComponent<AudioSource>();
        

    }


    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            
            gameObject.SetActive(false);
            audiosource.Play();
            Stage4Gamemanager.isWhalepadUnlocked = false;
        }
        if (Input.GetKeyDown(KeyCode.Return)) {
            
            num = 1;
            if (num2 == 1)
            {
                Shape = GameObject.FindGameObjectsWithTag("shape")[0];

                num2++;
            }
            else if (num2 == 2)
            {
                Shape = GameObject.FindGameObjectsWithTag("shape")[4];

                num2++;
            }
            else if (num2 == 3)
            {
                Shape = GameObject.FindGameObjectsWithTag("shape")[2];

                num2++;
            }
            else if (num2 == 4)
            {
                Shape = GameObject.FindGameObjectsWithTag("shape")[1];

                num2++;
            }
            else if (num2 == 5)
            {
                Shape = GameObject.FindGameObjectsWithTag("shape")[3];
                num2 ++;

            }
            else if (num2 == 6) {
                if (arr[0] == 2 && arr[1] == 3 && arr[2] == 4 && arr[3] == 2 && arr[4] == 1)
                {
                    GameObject.Find("WhalePanel").SetActive(false);
                    audiosource2.Play();
                    if (state)
                    {
                        drawer.transform.Translate(0.4f, 0, 0);
                        Key.SetActive(true);
                        state = false;
                    }

                }
                else
                {
                    num2 = 2;
                    Shape = GameObject.FindGameObjectsWithTag("shape")[0];
                    for (int i = 0; i < 5; i++) arr[i] = 1;
                    GameObject.FindGameObjectsWithTag("shape")[0].GetComponent<Image>().sprite = FourthImage;
                    GameObject.FindGameObjectsWithTag("shape")[1].GetComponent<Image>().sprite = FourthImage;
                    GameObject.FindGameObjectsWithTag("shape")[2].GetComponent<Image>().sprite = FourthImage;
                    GameObject.FindGameObjectsWithTag("shape")[3].GetComponent<Image>().sprite = FourthImage;
                    GameObject.FindGameObjectsWithTag("shape")[4].GetComponent<Image>().sprite = FourthImage;
                    
                }

            }
            
           


        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeImage(Shape, arr);
            Debug.Log(num2-1+" "+arr[num2-2]);

        }
    }
    
    public void ChangeImage(GameObject obj, int[] arr) {
        if (num == 1)
        {
            obj.GetComponent<Image>().sprite = FirstImage;
            num++;
            arr[num2-2] =2;
            


        }
        else if (num == 2) {
            obj.GetComponent<Image>().sprite  = SecondImage;
            num++;
            arr[num2-2] = 3;

        }
        else if (num == 3)
        {
            obj.GetComponent<Image>().sprite = ThirdImage;
            
            num++;
            arr[num2-2] = 4;
        }
        else if (num == 4)
        {
            obj.GetComponent<Image>().sprite = FourthImage;
            num=1;
            arr[num2-2] = 1;
        }

    }
  

    // Update is called once per frame
    
}
