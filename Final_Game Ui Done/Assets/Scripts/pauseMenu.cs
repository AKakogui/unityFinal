using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenu;
    private bool isPaused = false; // Track the pause state

    void Update()
    {
        // Check if the Escape key was pressed this frame
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true; // Update the paused state
    }

    public void Resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false; // Update the paused state
    }

    public void Home(int sceneID)
    {
        if (TimerManager.instance != null)
        {
            Destroy(TimerManager.instance.gameObject);
        }

        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneID);

    }
}
