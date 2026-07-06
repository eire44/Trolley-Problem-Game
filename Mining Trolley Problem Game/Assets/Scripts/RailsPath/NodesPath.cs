using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodesPath : MonoBehaviour
{
    public NodesPath nextNode;

    [HideInInspector] public int selectedIndex = 0;

    public virtual NodesPath GetNextNode()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.currentNode = nextNode;
        return nextNode;
    }
}
