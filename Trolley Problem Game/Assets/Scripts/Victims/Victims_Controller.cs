using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victims_Controller : MonoBehaviour
{
    Messages_Controller msgController;
    public string victimsMessage = "";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            msgController.finalMessage = victimsMessage;
        }
    }
}
