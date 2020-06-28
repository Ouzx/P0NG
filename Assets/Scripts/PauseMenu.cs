using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public static bool IsGamePaused = false;
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape) )
        {
            if (IsGamePaused) Resume();
            else Pause();
        }

    }

    public void Resume()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        pauseMenuUI.SetActive(false);
        IsGamePaused = false;
        Time.timeScale = 1f;
    }
    public void Pause()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        pauseMenuUI.SetActive(true);
        IsGamePaused = true;
        Time.timeScale = 0f;
    }

    public void Restart()
    {
        Resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Mainmenu()
    {
        Resume();
        SceneManager.LoadScene("Main Menu");
    }
}
