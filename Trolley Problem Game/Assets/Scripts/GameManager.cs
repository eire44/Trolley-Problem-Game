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
    int amountOfVictims = 0;
    int amountSaved = 0;
    [HideInInspector] public string destinyName = "";

    public GameObject nextLevelScreen;
    public Button btnNextLevel;
    // Start is called before the first frame update
    void Start()
    {
        Station_Controller[] stations = FindObjectsOfType<Station_Controller>();
        int index = Random.Range(0, stations.Length);
        stations[index].isGoal = true;
        destinyName = stations[index].stationName;

        stationName.text = "Next Station is: " + destinyName;
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void openNextLevelScreen(bool trainCrashed)
    {
        FindObjectOfType<Level_Completed_Controller>().sumAmounts(amountOfVictims, amountSaved);

        if (trainCrashed)
        {
            btnNextLevel.interactable = false;
        } 
        else
        {
            btnNextLevel.interactable = true;
        }
        nextLevelScreen.SetActive(true);
    }
}
