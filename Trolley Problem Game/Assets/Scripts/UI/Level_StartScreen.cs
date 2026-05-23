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

    GameManager gameManager;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        btnPreviousLevel.interactable = gameManager.levelNumber > 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setLevelScreen(int levelIndex, string stationName)
    {
        levelNumber.text = "Level " + levelIndex.ToString();
        destination.text = "Destination: " + stationName;
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
