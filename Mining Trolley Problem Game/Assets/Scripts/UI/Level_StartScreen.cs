using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level_StartScreen : MonoBehaviour
{
    public GameObject levelStartScreen;
    public TMP_Text levelNumber;
    public TMP_Text destination;
    public Button btnPreviousLevel;
    public TMP_Text startMessage;

    GameManager gameManager;
    Messages_Controller msgController;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        msgController = FindObjectOfType<Messages_Controller>();

        btnPreviousLevel.interactable = gameManager.levelNumber > 1;
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    //public void setStartMessage()
    //{
    //    startMessage.text = msgController.finalMessage;
    //}

    public void setLevelScreen(int levelIndex, string message)
    {
        levelNumber.text = "Nivel " + levelIndex.ToString();
        //destination.text = "Destination: " + stationName;
        startMessage.text = message;
    }

    public void startLevel()
    {
        Time.timeScale = 1.0f;
        levelStartScreen.SetActive(false);
    }

    public void goToPreviousLevel()
    {
        SceneManager.LoadScene(gameManager.levelNumber - 1);
        
    }
}
