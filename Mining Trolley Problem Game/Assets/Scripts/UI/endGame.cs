using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class endGame : MonoBehaviour
{
    public GameObject endGameScreen;
    public TMP_Text endGameMessage;
    
    public void showEndGameScreen(string finalMessage)
    {
        Time.timeScale = 0f;
        endGameScreen.SetActive(true);
        FindObjectOfType<GameManager>().nextLevelScreen.SetActive(false);
        endGameMessage.text = finalMessage;
    }
}
