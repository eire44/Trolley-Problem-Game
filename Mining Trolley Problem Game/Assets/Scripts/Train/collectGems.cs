using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class collectGems : MonoBehaviour
{
    GameManager gameManager;
    public TMP_Text monedas;
    public TMP_Text minerales;

    [HideInInspector] public static int mineralesAmount = 0;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        mineralsManager mM = collision.gameObject.GetComponent<mineralsManager>();
        if (mM != null)
        {
            mineralesAmount += mM.mineralAmount;
            minerales.text = "Minerales recolectados: " + mineralesAmount;
        }
    }
}
