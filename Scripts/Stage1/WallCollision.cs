using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollision : MonoBehaviour
{
    private SceneManagement sm1;

    void Start()
    {
        sm1 = new SceneManagement();
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name == "Container" || col.gameObject.name == "Player(2)")
        {
            sm1.gameover(1); //게임 오버 씬으로 전환
        }
    }   
}
