using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Level_Completed_Controller : MonoBehaviour
{
    Scene currentScene;
    int totalVictims = 0;
    int totalSaved = 0;

    public TMP_Text txtVictims;
    public TMP_Text txtSaved;

    public GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenuController();
        }
    }

    public void sumAmounts(int victims, int saved)
    {
        totalVictims += victims;
        totalSaved += saved;

        txtVictims.text = "Total Victims: " + totalVictims;
        txtSaved.text = "Total Saved: " + totalSaved;
    }

    public void backToMainMenu()
    {
        ///audioSource_Click.Play();
        SceneManager.LoadScene(0);
    }

    public void tryAgain()
    {
        ///audioSource_Click.Play();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    public void goToNextLevel()
    {
        ///audioSource_Click.Play();
        if (checkIfNextLevel())
        {
            SceneManager.LoadScene(currentScene.buildIndex + 1);
        }
    }

    public bool checkIfNextLevel()
    {
        int totalScenes = SceneManager.sceneCountInBuildSettings;
        int nextScene = currentScene.buildIndex + 1;

        if (nextScene < totalScenes)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void pauseMenuController ()
    {
        if(pauseMenu.activeInHierarchy)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
