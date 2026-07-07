using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class timer : MonoBehaviour
{
    TMP_Text timerText;

    public float remainingTime = 40f;

    private void Start()
    {
        timerText = GetComponent<TMP_Text>();
    }

    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;

            if (remainingTime < 0)
                remainingTime = 0;

            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);

            timerText.text = $"{minutes:00}:{seconds:00}";
        }
    }
}
