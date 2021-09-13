using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class givingFlower : MonoBehaviour
{
    public GameObject arm;
    SceneManagement sm4 = new SceneManagement();
    [SerializeField] GameObject noticeUI;
 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    void OnMouseDown()
    {
        if (arm.transform.childCount == 1) {
            if (this.name == "vase_A_S5" && arm.transform.GetChild(0).name == "flower01")
            {
                GameObject.Find("flower01").transform.position = this.transform.position; //팔에다 붙인다.
                GameObject.Find("flower01").transform.parent = this.transform;
                Stage4Gamemanager.isliarQuizSolved = true;
                StartCoroutine("canGo");

            }
            else if (this.name != "vase_A_S5" && arm.transform.GetChild(0).name == "flower01")
            {
                Debug.Log("Gameover");

                sm4.gameover(4);
            }
        } 
     
        


    }
    IEnumerator canGo()
    {

        noticeUI.SetActive(true);
        noticeUI.GetComponentInChildren<Text>().text = "문이 열리는 소리가 들렸다.";
        yield return new WaitForSeconds(2f);
        noticeUI.SetActive(false);

    }

}
