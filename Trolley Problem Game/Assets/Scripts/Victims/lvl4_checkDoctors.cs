using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl4_checkDoctors : MonoBehaviour
{
    public GameObject[] doctorsArray;
    

    public bool checkIfDoctorsKilled()
    {
        foreach (GameObject doctor in doctorsArray)
        {
            if(doctor.activeInHierarchy)
            {
                return false;
            }
        }

        return true;
    }
}
