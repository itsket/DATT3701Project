using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public GameObject pauseMenu;
    public void Sceneloader(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
    }

     public void ResumeGame()
    {
        pauseMenu.SetActive(false);
    }
}
