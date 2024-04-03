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
        operation.allowSceneActivation = false;

        yield return new WaitForSeconds(1f);

         while (!operation.isDone)
         {
            //loadingBar.value = operation.progress;
            // Update loading bar value
            loadingBar.value = Mathf.Clamp01(operation.progress / 0.9f); // Clamping to 0-1 range

            // Check if loading is almost complete
            if (operation.progress >= 0.9f)
            {
                // Ensure loading bar is filled
                loadingBar.value = 1f;

                // Allow scene activation
                operation.allowSceneActivation = true;
            }

            yield return null;
         }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P) || Input.GetKey("escape"))
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
