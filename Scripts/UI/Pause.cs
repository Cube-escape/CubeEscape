using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField]
    private GameObject pausePanel;

    [SerializeField]
    private SceneManagement sceneManagement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (pausePanel.activeSelf)
            {
                pausePanel.SetActive(false); //esc키 누르면 메뉴 꺼지는 기능 추가.
                Time.timeScale = 1f;
                Cursor.lockState = CursorLockMode.Locked;
            }

            else
            {
                Time.timeScale = 0f;
                pausePanel.SetActive(true);
                Cursor.lockState = CursorLockMode.None;

            }
        }

        
    }

    public void ResumeBtn()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void RestartBtn()
    {
        Time.timeScale = 1f;
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void MainMenuBtn()
    {
        Time.timeScale = 1f;
        sceneManagement.movetoMainmenu();
    }

    public void ExitBtn()
    {
        Time.timeScale = 1f;
       
        // 주이님! 제가 생각해보니까 Exit버튼을 누르면 저장되는게 아니라 다음 stage로 이동할때 자동저장되는게 더 좋을거같아서 save버튼 추가안하셔도 될 것 같아요!
        Application.Quit();
    }
}
