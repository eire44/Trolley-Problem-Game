using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class IntersectionToVictim
{
    public int trailID;
    public NodesPath nextNode;
    //public string nextDir = "";
    public Transform trailOption;
    public int trackVictims;

    //public List<Dir_To_Node> multipleNodesIntersection = new List<Dir_To_Node>();
    //public int requiredOrigin = 0;
    //public NodesPath_Intersections nextIntersection = null;
}
