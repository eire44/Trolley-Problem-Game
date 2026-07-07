using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //public TMP_Text stationName;
    //public TMP_Text victimsCount;
    ////public TMP_Text savedCount;
    //[HideInInspector] public int amountOfVictims = 0;
    //int amountSaved = 0;
    //[HideInInspector] public string destinationName = "";

    public GameObject nextLevelScreen;
    public Button btnNextLevel;
    public GameObject tooLateAlert;

    public TMP_Text finalScreenTitle;

    [HideInInspector] public NodesPath currentNode;
    public int levelNumber;

    List<string> crashMessage = new List<string>();
    static int crashIndex = 0;

    public int condicionNivel = 0;
    [HideInInspector] public List<string> mineralesRecolectados = new List<string>();
    [HideInInspector] public int monedasRecolectadas = 0;
    void Start()
    {
        Time.timeScale = 0f;

        Station_Controller[] stations = FindObjectsOfType<Station_Controller>();
        int index = Random.Range(0, stations.Length);
        stations[index].isGoal = true;


        collectGems carrito = FindObjectOfType<collectGems>();
        carrito.monedas.text = "Monedas: " + collectGems.coinsAmount;
        carrito.minerales.text = "Minerales recolectados: " + collectGems.mineralesAmount;

        FindObjectOfType<Level_StartScreen>().setLevelScreen(levelNumber, stations[index].levelStartMessage);

        crashMessage.Add("Try not to crash, okay? Make it to the right station, the train won´t stop at the wrong one.");
        crashMessage.Add("I told you not to crash. Make sure you´re heading to the right station and through the right tracks.");
        crashMessage.Add("If you´re trying to suicide, this is not the game. Look up for Human: Fall Flat");
        crashMessage.Add("Well, this is getting annoying");
        crashMessage.Add("Stop. Crashing. Get. To the right. Station.");
    }

    //public void addToVictimsCount(bool doubleVictim)
    //{
    //    if(doubleVictim)
    //    {
    //        amountOfVictims += 2;
    //    }
    //    else
    //    {
    //        amountOfVictims++;
    //    }
        
    //    victimsCount.text = "Killed: " + amountOfVictims.ToString();
    //}

    //public void addToSavedCount(int amountToSave)
    //{
    //    amountSaved += amountToSave;
    //    savedCount.text = "Saved: " + amountSaved.ToString();
    //}

    public void openNextLevelScreen(bool trainCrashed, string title)
    {
        Level_Completed_Controller lvlC = FindObjectOfType<Level_Completed_Controller>();

        if (trainCrashed) // || !lvlC.checkIfNextLevel()
        {
            btnNextLevel.interactable = false;
            //amountOfVictims += FindObjectOfType<TrainController>().trainPassengers;
        } 
        else
        {
            btnNextLevel.interactable = true;
        }

        //lvlC.sumAmounts(amountOfVictims, amountSaved);
        finalScreenTitle.text = title;


        if (trainCrashed)
        {
            //lvlC.finalMessage.text = crashMessage[crashIndex];
            if(crashMessage[crashIndex + 1] != null)
            {
                crashIndex++;
            }
            
        } else
        {
            lvlC.setFinalMessage();
        }

        nextLevelScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void showTooLateAlert()
    {
        StartCoroutine(showAlert());
    }

    IEnumerator showAlert()
    {
        tooLateAlert.SetActive(true);

        yield return new WaitForSeconds(2f);

        tooLateAlert.SetActive(false);
    }
}
