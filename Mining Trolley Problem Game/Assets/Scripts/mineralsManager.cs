using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class mineralsManager : MonoBehaviour
{
    public int mineralAmount;
    public string mineralName;
    public SpriteRenderer spriteRenderer;
    public Sprite nuevoSprite;
    public TMP_Text mineralObtenido;
    public int equivalenteEnMonedas;
    public bool minedMine = false;
    public bool cantMineralesAleatoria = false;

    public int cantMineralesMin = 0;
    public int cantMineralesMax = 0;

    [HideInInspector] public int CantidadMineralesDef;

    private void Start()
    {
        if(spriteRenderer.sprite != null)
        {
            spriteRenderer.sprite = nuevoSprite;
        }

        if (cantMineralesAleatoria)
        {
            CantidadMineralesDef = Random.Range(cantMineralesMin, cantMineralesMax);
            mineralObtenido.text = "+ (" + cantMineralesMin + ", " + (cantMineralesMax - 1) + ")";
        }
        else
        {
            CantidadMineralesDef = mineralAmount;
            mineralObtenido.text = "+" + mineralAmount;
        }


    }
}
