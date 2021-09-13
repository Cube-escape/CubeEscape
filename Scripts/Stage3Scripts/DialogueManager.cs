using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour, IPointerClickHandler

{
    public Text dialogueText;
    public GameObject nextText;
    public CanvasGroup dialoguegroup;

    public Queue<string> sentences;
    private bool isTyping;

    private string currentSentence;

    public static DialogueManager instance;
    private void Awake()
    {
        instance = this;
    }

    public float typingspeed = 01;

    // Start is called before the first frame update
    void Start()
    {

        sentences = new Queue<string>();
        
    }

    public void Ondialogue(string[] lines)
    {
        sentences.Clear();
        foreach(string line in lines)
        {
            sentences.Enqueue(line);
        }
        dialoguegroup.alpha = 1;
        dialoguegroup.blocksRaycasts = true;

        NextSentence();
    }

    public void NextSentence()
    {
        if(sentences.Count != 0)
        {
            currentSentence = sentences.Dequeue();
            // 큐에서 해당 데이터 기억
            isTyping = true;
            nextText.SetActive(false);
            StartCoroutine(Typing(currentSentence));
        }
        else
        {
            dialoguegroup.alpha = 0;
            dialoguegroup.blocksRaycasts = false;
        }
    }

    IEnumerator Typing(string line)
    {
        dialogueText.text = "";
        foreach(char letter in line.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingspeed);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueText.text.Equals(currentSentence))
        {
            nextText.SetActive(true);
            isTyping = false;
        }
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(!isTyping)
        NextSentence();
    }
}
