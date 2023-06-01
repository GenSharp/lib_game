using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{

    public GameObject pauseMenu;
    private bool isPaused = false;
    private CursorLockMode previousCursorLockMode;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }

            else
            {
                PauseGame();
            }
        }
    }

    private void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        previousCursorLockMode = Cursor.lockState;
        Cursor.lockState = CursorLockMode.None;
        pauseMenu.SetActive(true);
    }

    private void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        Cursor.lockState = previousCursorLockMode;
        pauseMenu.SetActive(false);
    }
}