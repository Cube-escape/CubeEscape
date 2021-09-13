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
                pausePanel.SetActive(false); //escŰ ������ �޴� ������ ��� �߰�.
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
       
        // ���̴�! ���� �����غ��ϱ� Exit��ư�� ������ ����Ǵ°� �ƴ϶� ���� stage�� �̵��Ҷ� �ڵ�����Ǵ°� �� �����Ű��Ƽ� save��ư �߰����ϼŵ� �� �� ���ƿ�!
        Application.Quit();
    }
}
