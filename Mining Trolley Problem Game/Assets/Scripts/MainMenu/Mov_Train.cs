using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov_Train : MonoBehaviour
{
    Vector2 initialPos;
    Vector2 newPos;
    public float speed = 2f;
    float t = 0f;
    // Start is called before the first frame update
    void Start()
    {
        initialPos = new Vector2(transform.position.x, transform.position.y);
        newPos = new Vector2(transform.position.x + 20, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime * speed;
        transform.position = Vector3.Lerp(initialPos, newPos, t);

        if(transform.position.x >= newPos.x)
        {
            transform.position = initialPos;
            t = 0f;
        }
    }
}
