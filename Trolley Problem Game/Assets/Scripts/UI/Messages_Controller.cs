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

    static bool killedTooManyPeople = false;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

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
            return null; //FALTAN LOS START MESSAGE DEL 4 Y DEL 5
        }
        else
        {
            return null;
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
            case 5:

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
    }
}
