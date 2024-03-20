using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public GameObject player;
    public GameObject pauseMenu;
    public GameObject loadingScreen;
    public Slider loadingBar;
    public void Sceneloader(int levelIndex)
    {
       StartCoroutine(LoadSceneAsynchronously(levelIndex));
    }

    IEnumerator LoadSceneAsynchronously(int levelIndex)
    {
         AsyncOperation operation = SceneManager.LoadSceneAsync(levelIndex);
         loadingScreen.SetActive(true);
         while (!operation.isDone)
         {
            loadingBar.value = operation.progress;
            yield return null;
         }
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
