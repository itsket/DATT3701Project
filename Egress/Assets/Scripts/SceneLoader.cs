using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public GameObject player;
    public GameObject pauseMenu;
    public void Sceneloader(string SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
         
          PauseGame();
        }
    }
    public void PauseGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        player.GetComponent<InputManager>().enabled = false;
        Debug.Log("Pause");
        pauseMenu.SetActive(true);
    }

     public void ResumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        player.GetComponent<InputManager>().enabled = true;
        pauseMenu.SetActive(false);
    }
}
