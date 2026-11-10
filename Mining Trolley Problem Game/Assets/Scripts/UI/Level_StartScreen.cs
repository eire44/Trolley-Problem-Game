using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level_StartScreen : MonoBehaviour
{
    public GameObject levelStartScreen;
    public GameObject seleccionGeneroScreen;
    public TMP_Dropdown generoDropdown;
    public TMP_Text levelNumber;
    public TMP_Text destination;
    public Button btnPreviousLevel;
    public TMP_Text startMessage;

    GameManager gameManager;
    Messages_Controller msgController;

    RecopilarData recopilarData;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        msgController = FindObjectOfType<Messages_Controller>();
        recopilarData = FindObjectOfType<RecopilarData>();

        btnPreviousLevel.interactable = gameManager.levelNumber > 1;
        
    }

    public void seleccionGeneroLista()
    {
        recopilarData.RegistrarJugador(generoDropdown.options[generoDropdown.value].text);
        seleccionGeneroScreen.SetActive(false);
        levelStartScreen.SetActive(true);
    }

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
