using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSet : MonoBehaviour
{
    public GameObject board;

    float x; 
    float y;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 target = new Vector2(board.transform.position.x, board.transform.position.y);

        transform.position = Vector2.MoveTowards(transform.position, target, 0.05f);
    }
}
