using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Station_Controller : MonoBehaviour
{
    [HideInInspector] public bool isGoal = false;
    public string stationName = "";
    public string levelStartMessage = "";
    public mineralsManager minaRequerida;
    public float precioMultiplicar;
    public TMP_Text txtNuevoPrecio;

    private void Start()
    {
        txtNuevoPrecio.text = "x " + precioMultiplicar;
    }
}
