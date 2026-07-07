using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Level_Completed_Controller : MonoBehaviour
{
    Scene currentScene;
    public TMP_Text condicionDeNivel;
    public TMP_Text listaObtenidos;
    public GameObject pauseMenu;
    GameManager gameManager;
    public TMP_Text txtMonedasTotales;
    public Button btnNextLevel;

    public List<GameObject> uiScreens = new List<GameObject>();

    public AudioSource purchaseAudio;
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        gameManager = FindObjectOfType<GameManager>();
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
        txtMonedasTotales.text = "Total: " + gameManager.monedasRecolectadas.ToString();
        condicionDeNivel.text = "Necesitas " + gameManager.condicionNivel + " monedas para comprar el acceso al siguiente nivel";
        for (int i = 0; i < gameManager.mineralesRecolectados.Count; i++)
        {
            listaObtenidos.text += gameManager.mineralesRecolectados[i] + "\n";
        }

        if(gameManager.monedasRecolectadas >= gameManager.condicionNivel)
        {
            btnNextLevel.interactable = true;
        } else
        {
            btnNextLevel.interactable = false;
        }

        //finalMessage.text = messages_Controller.finalMessage;
        //messages_Controller.checkForFinalMessage();
    }

    public void sumAmounts(int victims, int saved)
    {
        //totalVictims += victims;
        //totalSaved += saved;

        //txtVictims.text = "Total Victims: " + totalVictims;
        //txtSaved.text = "Total Saved: " + totalSaved;
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
            collectGems.coinsAmount -= gameManager.condicionNivel;
            //purchaseAudio.Play();
            StartCoroutine(CambiarNivel());
            //SceneManager.LoadScene(currentScene.buildIndex + 1);
        }
        else
        {
            FindObjectOfType<endGame>().showEndGameScreen("a revisar");
        }
    }

    private IEnumerator CambiarNivel()
    {
        purchaseAudio.Play();

        yield return new WaitForSecondsRealtime(purchaseAudio.clip.length);

        SceneManager.LoadScene(currentScene.buildIndex + 1);
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
        bool open = true;
        foreach (GameObject screen in uiScreens)
        {
            if(screen.activeInHierarchy)
            {
                open = false;
            }
        }

        if (open)
        {
            if (pauseMenu.activeInHierarchy)
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
}
