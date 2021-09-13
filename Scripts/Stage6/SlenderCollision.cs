using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlenderCollision : MonoBehaviour
{
    [SerializeField]
    private SceneManagement sceneManagement;

    private CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        controller.detectCollisions = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        if (other.transform.name == "Slender")
        {
            sceneManagement.gameover(6);
        }
    }
}
