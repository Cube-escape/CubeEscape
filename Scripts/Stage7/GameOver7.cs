using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class GameOver7 : MonoBehaviour
{
    [SerializeField] GameObject player;
    SceneManagement sm7;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        sm7 = new SceneManagement();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        if (other.gameObject == player)
        {
            sm7.gameover(7);
        }

    }

 

}
