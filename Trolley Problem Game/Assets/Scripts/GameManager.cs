using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class GameManager : MonoBehaviour
{
    public TMP_Text stationName;
    public TMP_Text victimsCount;
    public TMP_Text savedCount;
    [HideInInspector] public int amountOfVictims = 0;
    int amountSaved = 0;
    [HideInInspector] public string destinationName = "";

    public GameObject nextLevelScreen;
    public Button btnNextLevel;
    public GameObject tooLateAlert;

    public TMP_Text finalScreenTitle;

    [HideInInspector] public NodesPath currentNode;
    public int levelNumber;

    List<string> crashMessage = new List<string>();
    static int crashIndex = 0;
    void Start()
    {
        Time.timeScale = 0f;

        Station_Controller[] stations = FindObjectsOfType<Station_Controller>();
        int index = Random.Range(0, stations.Length);
        stations[index].isGoal = true;
        destinationName = stations[index].stationName;

        stationName.text = "Next Station is: " + destinationName;

        if(FindObjectOfType<Messages_Controller>().checkForStartMessage(levelNumber) != null)
        {
            stations[index].levelStartMessage = FindObjectOfType<Messages_Controller>().checkForStartMessage(levelNumber);
        }

        FindObjectOfType<Level_StartScreen>().setLevelScreen(levelNumber, destinationName, stations[index].levelStartMessage);

        crashMessage.Add("Try not to crash, okay? Make it to the right station, the train won´t stop at the wrong one.");
        crashMessage.Add("I told you not to crash. Make sure you´re heading to the right station and through the right tracks.");
        crashMessage.Add("If you´re trying to suicide, this is not the game. Look up for Human: Fall Flat");
        crashMessage.Add("Well, this is getting annoying");
    }

    public void addToVictimsCount()
    {
        amountOfVictims++;
        victimsCount.text = "Killed: " + amountOfVictims.ToString();
    }

    public void addToSavedCount(int amountToSave)
    {
        amountSaved += amountToSave;
        savedCount.text = "Saved: " + amountSaved.ToString();
    }

    public void openNextLevelScreen(bool trainCrashed, string title)
    {
        Level_Completed_Controller lvlC = FindObjectOfType<Level_Completed_Controller>();
        lvlC.sumAmounts(amountOfVictims, amountSaved);
        finalScreenTitle.text = title;

        if (trainCrashed || !lvlC.checkIfNextLevel())
        {
            btnNextLevel.interactable = false;
        } 
        else
        {
            btnNextLevel.interactable = true;
        }

        if (trainCrashed)
        {
            lvlC.finalMessage.text = crashMessage[crashIndex];
            crashIndex++;
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
