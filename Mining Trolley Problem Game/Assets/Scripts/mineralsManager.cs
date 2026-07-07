using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class mineralsManager : MonoBehaviour
{
    public int mineralAmount;
    public string mineralName;
    public SpriteRenderer spriteRenderer;
    public Sprite nuevoSprite;
    public TMP_Text mineralObtenido;

    private void Start()
    {
        spriteRenderer.sprite = nuevoSprite;
        mineralObtenido.text = "+" + mineralAmount;
    }
}
