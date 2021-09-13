using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    //public Text txtName;
    public Text txtSentence;
    public int sentenceNum = -1;
    //public int endIndex = -1;
    //public Animator anim;

    Queue<string> sentences = new Queue<string>();

    public void Begin(Dialogue info)
    {
        //anim.SetBool("isOpen", true);
        sentences.Clear();

        //txtName.text = info.name;

        foreach(var sentence in info.sentences)
        {
            sentences.Enqueue(sentence);
        }

        Next(); //ù ���� ���
    }

    public void Next()
    {
        if(sentences.Count <= 0) //���� ������ ������
        {
            End();
            return;
        }
        else //���� ������ ������ ���� ���� ���
        {
            txtSentence.text = sentences.Dequeue();
            sentenceNum++;
            //Debug.Log(sentenceNum);
         
            if (sentenceNum == 31)
            {
                Stage1Gamemanager.doesDialog1End = true;
            }
            else if (sentenceNum == 48)
            {
                Stage1Gamemanager.doesDialog2End = true;
            }

            /*txtSentence.text = string.Empty;
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentences.Dequeue()));
            */
        }

    }

    /*
    IEnumerator TypeSentence(string sentence) //�ѱ��ھ� ���
    {
        foreach (var letter in sentence)
        {
            txtSentence.text += letter;
            yield return new WaitForSeconds(0.1f);
        }
    }
    */

    private void End()
    {
        //anim.SetBool("isOpen", false);
        Debug.Log("End");
        //endIndex++;
        //txtSentence.text = string.Empty;
    }

}
