using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class NodesPath : MonoBehaviour
{
    public NodesPath nextNode;
    //public string nextDir = "";
    //public List<Dir_To_Node> multipleNodesIntersection = new List<Dir_To_Node>();

    [HideInInspector] public int selectedIndex = 0;

    public virtual NodesPath GetNextNode()
    {
        //GameManager gameManager = FindObjectOfType<GameManager>();
        return nextNode;
        //if (nextNode == null)
        //{
        //    //if(multipleNodesIntersection.Count > 0)
        //    //{
        //    //    foreach (Dir_To_Node d in multipleNodesIntersection)
        //    //    {
        //    //        if(d.requiredDirection == gameManager.currentDirection)
        //    //        {
        //    //            if (d.nextDirection != "")
        //    //            {
        //    //                gameManager.currentDirection = d.nextDirection;
        //    //            }
        //    //            return d.nextNode;
        //    //        }
        //    //    }
        //    //    return null;
        //    //}
        //    //else
        //    //{
        //        return null;
        //    //}
        //} 
        //else
        //{
        //    //if (nextDir != "")
        //    //{
        //    //    gameManager.currentDirection = nextDir;
        //    //}
        //    return nextNode;
        //}
    }
}
