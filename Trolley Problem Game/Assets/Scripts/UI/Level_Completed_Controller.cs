using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Level_Completed_Controller : MonoBehaviour
{
    Scene currentScene;
    static int totalVictims = 0;
    static int totalSaved = 0;

    public TMP_Text txtVictims;
    public TMP_Text txtSaved;
    public TMP_Text finalMessage;

    public GameObject pauseMenu;
    Messages_Controller messages_Controller;
    //SaveSystem saveSystem;

    //static bool firstRound = true;
    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        messages_Controller = FindObjectOfType<Messages_Controller>();
        //saveSystem = FindObjectOfType<SaveSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenuController();
        }
    }

    public void setFinalMessage()
    {
        finalMessage.text = messages_Controller.finalMessage;
        messages_Controller.checkForFinalMessage();
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
        //firstRound = false;
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    public void goToNextLevel()
    {
        ///audioSource_Click.Play();
        if (checkIfNextLevel())
        {
            if(totalVictims < 50)
            {
                SceneManager.LoadScene(currentScene.buildIndex + 1);
            }
            else
            {
                messages_Controller.endGameMessage = "You killed 50 people already, people are starting to suspect you’re doing this on purpose. I´ll look for another driver.";
                FindObjectOfType<endGame>().showEndGameScreen(messages_Controller.endGameMessage);
            }
        }
        else
        {
            FindObjectOfType<endGame>().showEndGameScreen(messages_Controller.endGameMessage);
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
