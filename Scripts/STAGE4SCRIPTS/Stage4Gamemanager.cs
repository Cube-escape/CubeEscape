using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage4Gamemanager : MonoBehaviour
{
    /*
     * [state1]
     * �׸� �ݰ� ���� ���� ����.
     * ���������� �۵�X
     * ������ �ִ� �����Է±� �������� ����.
     * �ǳ�Ű�����������ذ�x ->��������x
     * 
     * [state2]
     * �׸��ݰ� ������.
     * ���������� �۵�O
     * ������ �ִ� �����Է±� �������� ����.
     * �ǳ�Ű�����������ذ�x ->��������x
     * 
     * [state3] 
     * �׸��ݰ� ������.
     * ���������� �۵�O
     * ������ �ִ� �����Է±� ������. ->�������ٰ���.
     * �ǳ�Ű�����������ذ�x ->��������x
     * 
     *
     * [state4]
     * �׸��ݰ� ������.
     * ���������� �۵�O
     * ������ �ִ� �����Է±� ������. ���踦 ����ִٸ� ���� ��� ���� ����.
     * �ǳ�Ű�����������ذ�O ->������.
     * 
     * 
     * 
     */


   public static bool isbookdropped1 = false;
    public static bool isbookdropped2 = false;
    public static bool isbookdropped3 = false;
    public static bool isbooktouch = false;
    public static bool issafeboxunlocked = false; //�׸��ݰ� ��й�ȣ �����ߴ��� ����. 
    public static bool isWhalepadUnlocked = false; //����й�ȣ �Է±� �����ߴ��� ����
    public static bool isliarQuizSolved = false; // ������ ���ϴ� �ǳ�Ű������ ���� �༭ ������ Ǯ������ ����.
   


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }



}
