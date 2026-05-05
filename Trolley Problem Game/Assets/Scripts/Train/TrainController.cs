using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class TrainController : MonoBehaviour
{
    public NodesPath currentNode;
    private NodesPath targetNode; 

    public float speed = 2f;
    GameManager gameManager;

    void Start()
    {
        targetNode = currentNode.GetNextNode();
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (targetNode == null) return;

        transform.position = Vector3.MoveTowards(transform.position, targetNode.transform.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetNode.transform.position) < 0.01f)
        {
            currentNode = targetNode;
            targetNode = currentNode.GetNextNode();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Victim"))
        {
            gameManager.addToVictimsCount();
            collision.gameObject.SetActive(false);
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            //GAME OVER
            Debug.Log("GAME OVER");
        }
        else if (collision.gameObject.CompareTag("Station"))
        {
            Station_Controller station = collision.gameObject.GetComponent<Station_Controller>();
            if (station != null && station.isGoal) //station.name == gameManager.destinyName
            {
                gameManager.openNextLevelScreen(false);
            }
        }
    }
}
