using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    #region Singelton
    public static EndMenu Instance;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    #endregion
    public GameObject endMenu;

    public void EndGame()
    {
        Time.timeScale = 1f;
        FindObjectOfType<AudioManager>().Play("Click");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ContinueGame()
    {
        endMenu.SetActive(false);
        Time.timeScale = 1f;
        FindObjectOfType<AudioManager>().Play("Click");
    }
    public void PopEndMenu()
    {
        endMenu.SetActive(true);
        Time.timeScale = 0f;
    }

}
