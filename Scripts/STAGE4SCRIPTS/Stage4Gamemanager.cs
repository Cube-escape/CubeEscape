using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage4Gamemanager : MonoBehaviour
{
    /*
     * [state1]
     * 그림 금고 해제 되지 않음.
     * 빔프로젝터 작동X
     * 서랍에 있는 도형입력기 해제되지 않음.
     * 피노키오인형문제해결x ->문열리지x
     * 
     * [state2]
     * 그림금고 해제됨.
     * 빔프로젝터 작동O
     * 서랍에 있는 도형입력기 해제되지 않음.
     * 피노키오인형문제해결x ->문열리지x
     * 
     * [state3] 
     * 그림금고 해제됨.
     * 빔프로젝터 작동O
     * 서랍에 있는 도형입력기 해제됨. ->열쇠접근가능.
     * 피노키오인형문제해결x ->문열리지x
     * 
     *
     * [state4]
     * 그림금고 해제됨.
     * 빔프로젝터 작동O
     * 서랍에 있는 도형입력기 해제됨. 열쇠를 들고있다면 찬장 잠금 해제 가능.
     * 피노키오인형문제해결O ->문열림.
     * 
     * 
     * 
     */


   public static bool isbookdropped1 = false;
    public static bool isbookdropped2 = false;
    public static bool isbookdropped3 = false;
    public static bool isbooktouch = false;
    public static bool issafeboxunlocked = false; //그림금고 비밀번호 해제했는지 여부. 
    public static bool isWhalepadUnlocked = false; //고래비밀번호 입력기 해제했는지 여부
    public static bool isliarQuizSolved = false; // 진실을 말하는 피노키오한테 꽃을 줘서 문제를 풀었는지 여부.
   


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }



}
