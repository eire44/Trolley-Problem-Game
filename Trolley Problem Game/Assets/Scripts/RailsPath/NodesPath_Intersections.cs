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
    private void Start()
    {
        showSelectedTrail();

        gameManager = FindObjectOfType<GameManager>();
    }

    public override NodesPath GetNextNode()
    {
        if (intersectionToVictims.Count == 0) return null;
        gameManager.currentNode = intersectionToVictims[selectedIndex].nextNode;
        return intersectionToVictims[selectedIndex].nextNode;
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
        //if(gameManager.currentNode == this)
        //{
            ToggleDirection();
        //}
        //else
        //{
        //    gameManager.showTooLateAlert();
        //}
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //changeTrack = false;
            gameManager.addToSavedCount(amountSaved);
            //selectNextIntersection();

            //SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();

            //Color c = sr.color;
            //c.a = 0f;
            //sr.color = c;
        }
    }
}
