using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class TrainController : MonoBehaviour
{
    public NodesPath currentNode;
    private NodesPath targetNode; 

    public float speed = 2f;
    private float t = 0f;
    GameManager gameManager;

    void Start()
    {
        targetNode = currentNode.GetNextNode();
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (targetNode == null) return;

        t += Time.deltaTime * speed;
        transform.position = Vector3.Lerp(currentNode.transform.position, targetNode.transform.position, t);

        //Vector3 direction = (targetNode.transform.position - currentNode.transform.position).normalized;
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0, 0, angle);

        if (t >= 1f)
        {
            currentNode = targetNode;
            targetNode = currentNode.GetNextNode();
            t = 0f;
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
                Debug.Log("NEXT LEVEL");
            }
        }
    }
}
