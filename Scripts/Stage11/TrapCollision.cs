using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapCollision : MonoBehaviour
{
    private SceneManagement sm11;

    void Start()
    {
        sm11 = new SceneManagement();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Obstacle")
        {
            sm11.gameover(11); //게임 오버 씬으로 전환
        }
    }

}
