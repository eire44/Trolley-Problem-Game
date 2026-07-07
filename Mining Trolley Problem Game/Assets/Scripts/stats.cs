using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stats : MonoBehaviour
{
    public GameObject endLevelScreen;
    public GameObject statsScreen;
    public void abrirStats()
    {
        statsScreen.SetActive(true);
        endLevelScreen.SetActive(false);
    }

    public void cerrarStats()
    {
        statsScreen.SetActive(false);
        endLevelScreen.SetActive(true);
    }
}
