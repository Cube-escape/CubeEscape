using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckInBox : MonoBehaviour
{
    [SerializeField]
    private Stage6GameManager gameManager;

    [SerializeField]
    private GameObject dreamCatcher1;

    [SerializeField]
    private GameObject dreamCatcher2;

    [SerializeField]
    private ParticleSystem explosion;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip[] clips;

    [SerializeField]
    private GameObject dialogUI;

    [SerializeField]
    private MoveSlenderAI moveSlenderAI;

    [SerializeField]
    private SlenderScreaming slenderScreaming;

    private List<string> inboxNames = new List<string>();
    private int index = 0;
    private int state;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        state = gameManager.GetState();

        if (state == 0)
        {
            if (index >= 2)
            {
                CheckObjects1();
            }
        }
        else if (state == 1)
        {
            if(index >= 3)
            {
                CheckObjects2();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.transform.name + " is in!");
        if (!inboxNames.Contains(collision.transform.name))
        {
            collision.transform.tag = "Untagged";
            inboxNames.Add(collision.transform.name);
            index++;
        }
    }

    private void CheckObjects1()
    {
        index = 0;
        if (inboxNames.Contains("eyeball_yellow") && inboxNames.Contains("white_thread"))
        {
            audioSource.clip = clips[1];
            audioSource.Play();
            Debug.Log("find right things");
            gameManager.IncreaseState();
            GameObject.Find(inboxNames[0]).SetActive(false);
            GameObject.Find(inboxNames[1]).SetActive(false);
            dreamCatcher1.SetActive(true);
        }
        else
        {
            explosion.Play();
            audioSource.clip = clips[0];
            audioSource.Play();
            Debug.Log("Wrong");
            GameObject obj1 = GameObject.Find(inboxNames[0]);
            GameObject obj2 = GameObject.Find(inboxNames[1]);
            obj1.transform.position = new Vector3(16.0f, 6.0f, -20.0f);
            obj2.transform.position = new Vector3(18.0f, 6.0f, -20.0f);
            obj1.tag = "interaction";
            obj2.tag = "interaction";
            moveSlenderAI.IncreaseSlender();
            slenderScreaming.Screaming();
            gameManager.IncreaseBGMPitch();
            StartCoroutine("dialog", "틀렸어. 방 안에 뭔가 변화가 생긴 것 같기도..?");
        }
        inboxNames.Clear();
    }

    private void CheckObjects2()
    {
        index = 0;
        if (inboxNames.Contains("feather1") && inboxNames.Contains("feather2") && inboxNames.Contains("feather3"))
        {
            audioSource.clip = clips[1];
            audioSource.Play();
            Debug.Log("find right things");
            GameObject.Find("feather1").SetActive(false);
            GameObject.Find("feather2").SetActive(false);
            GameObject.Find("feather3").SetActive(false);
            dreamCatcher1.SetActive(false);
            dreamCatcher2.SetActive(true);
        }
        else
        {
            explosion.Play();
            audioSource.clip = clips[0];
            audioSource.Play();
            Debug.Log("Wrong");
            GameObject obj1 = GameObject.Find(inboxNames[0]);
            GameObject obj2 = GameObject.Find(inboxNames[1]);
            GameObject obj3 = GameObject.Find(inboxNames[2]);
            obj1.transform.position = new Vector3(16.0f, 6.0f, -20.0f);
            obj2.transform.position = new Vector3(17.0f, 6.0f, -20.0f);
            obj3.transform.position = new Vector3(18.0f, 6.0f, -20.0f);
            obj1.tag = "interaction";
            obj2.tag = "interaction";
            obj3.tag = "interaction";
            moveSlenderAI.IncreaseSlender();
            slenderScreaming.Screaming();
            gameManager.IncreaseBGMPitch();
            StartCoroutine("dialog", "틀렸어. 방 안에 뭔가 변화가 생긴 것 같기도..?");
        }
        inboxNames.Clear();
    }

    IEnumerator dialog(string txt)
    {
        dialogUI.SetActive(true);
        dialogUI.GetComponentInChildren<Text>().text = txt;
        yield return new WaitForSeconds(2f);
        dialogUI.SetActive(false);
    }
}
