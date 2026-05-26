using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Messages_Controller : MonoBehaviour
{
    List<Dictionary<int, string>> firstMessage = new List<Dictionary<int, string>>();
    List<Dictionary<int, string>> lastMessage = new List<Dictionary<int, string>>();

    public List<string> levelMessages = new List<string>();

    public string finalMessage = "";
    GameManager gameManager;
    Level_Completed_Controller level_Completed_Controller;

    static bool killedTooManyPeople = false;
    static bool killedTheDoctors = false;

    [HideInInspector] public string endGameMessage = "";
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        level_Completed_Controller = FindObjectOfType<Level_Completed_Controller>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public string checkForStartMessage(int levelIndex)
    {
        if(levelIndex == 3)
        {
            if (killedTooManyPeople)
            {
                return "Please consider not to slaughter people unnecessarily";
            }
            else
            {
                return "I gave these people some variety, but you can still ignore who they are and treat them as just a number";
            }
        } else if(levelIndex == 4)
        {
            if(killedTheDoctors)
            {
                return "I’m not forgetting that you killed the doctors last time";
            }
            else
            {
                return "It would be great for my research if you actually used critical thinking when deciding";
            }
        }
        else
        {
            return "";
        }
        
    }

    public void checkForFinalMessage()
    {
        int levelIndex = gameManager.levelNumber;

        switch (levelIndex)
        {
            case 2:
                checkLevel2Condition();
                break;
            case 4:
                checkLevel4Condition();
                break;
            default:
                break;
        }
    }

    void checkLevel2Condition()
    {
        int maxVictims;

        if(gameManager.destinationName == "Woods St")
        {
            maxVictims = 4;
        } 
        else
        {
            maxVictims = 3;
        }

        if (gameManager.amountOfVictims <= maxVictims)
        {
            finalMessage = "You are doing great! Let´s make it more interesting";
            killedTooManyPeople = false;
        }
        else
        {
            finalMessage = "You seem to like massacres. Let’s see what you do next.";
            killedTooManyPeople = true;
        }
        level_Completed_Controller.finalMessage.text = finalMessage;
    }

    void checkLevel4Condition()
    {
        if (gameManager.destinationName == "Corn St")
        {
            if (FindObjectOfType<lvl4_checkDoctors>().checkIfDoctorsKilled())
            {
                killedTheDoctors = true;
                finalMessage = "You went for the two doctors? Do you hate humanity?";
                level_Completed_Controller.finalMessage.text = finalMessage;
            }
            else
            {
                killedTheDoctors = false;
            }
        }
        else
        {
            killedTheDoctors = false;
        }
    }
}
