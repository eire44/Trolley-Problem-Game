using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.Progress;

public class NodesPath_Intersections : NodesPath
{
    public List<IntersectionToVictim> intersectionToVictims = new List<IntersectionToVictim>();
    bool changeTrack = true;
    int amountSaved = 0;
    GameManager gameManager;

    //public int intersectionID = 0;
    //[HideInInspector] public List<IntersectionToVictim> filtered_Intersection = new List<IntersectionToVictim>();
    private void Start()
    {
        showSelectedTrail();

        gameManager = FindObjectOfType<GameManager>();
    }

    public override NodesPath GetNextNode()
    {
        if (intersectionToVictims.Count == 0) return null;
        return intersectionToVictims[selectedIndex].nextNode;

        //if (intersectionToVictims[selectedIndex].nextNode != null)
        //{
        //    //if(intersectionToVictims[selectedIndex].nextDir != "")
        //    //{
        //    //    gameManager.currentDirection = intersectionToVictims[selectedIndex].nextDir;
        //    //}
        //    return intersectionToVictims[selectedIndex].nextNode;
        //}
        //else
        //{
        //    //if (intersectionToVictims[selectedIndex].multipleNodesIntersection.Count > 0)
        //    //{
        //    //    foreach (Dir_To_Node d in intersectionToVictims[selectedIndex].multipleNodesIntersection)
        //    //    {
        //    //        if (d.requiredDirection == gameManager.currentDirection)
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
    }

    public void ToggleDirection()
    {
        if (intersectionToVictims.Count <= 1) return;
        selectedIndex = (selectedIndex + 1) % intersectionToVictims.Count;


        showSelectedTrail();
    }

    void showSelectedTrail()
    {
        foreach (IntersectionToVictim item in intersectionToVictims)
        {
            float alpha = 1;
            if (item.trailID != selectedIndex)
            {
                alpha = 0.4f;
                amountSaved = item.trackVictims;
            }

            SpriteRenderer sr = item.trailOption.GetComponent<SpriteRenderer>();

            Color c = sr.color;
            c.a = alpha;
            sr.color = c;
        }
    }

    void OnMouseDown()
    {
        if(changeTrack)
        {
            ToggleDirection();
        }
        else
        {
            gameManager.showTooLateAlert();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            changeTrack = false;
            gameManager.addToSavedCount(amountSaved);
            //selectNextIntersection();

            SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();

            Color c = sr.color;
            c.a = 0f;
            sr.color = c;
        }
    }

    void selectNextIntersection()
    {
        //gameManager.currentOriginID = intersectionID;

        //if(filtered_Intersection[selectedIndex].nextIntersection != null)
        //{
        //    foreach (IntersectionToVictim iToV in filtered_Intersection[selectedIndex].nextIntersection.intersectionToVictims)
        //    {
        //        if (iToV.requiredOrigin == intersectionID)
        //        {
        //            filtered_Intersection[selectedIndex].nextIntersection.filtered_Intersection.Add(iToV);
        //        }
        //    }
        //}
    }
}
