using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    float speed = 5f;
    public Transform player;
    public Camera cam;
    float minX, maxX, minY, maxY;
    float halfScale = 0.6935f / 2;
    void Start()
    {
        Vector2 screenBottomLeft = cam.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 screenUpRight = cam.ViewportToWorldPoint(new Vector2(1, 1));
        minX = screenBottomLeft.x;
        maxX = screenUpRight.x;
        minY = screenBottomLeft.y;
        maxY = screenUpRight.y;
    }
    // Update is called once per frame
    void Update()
    {
            Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            Vector2 dir = input.normalized;

            transform.Translate(dir * speed * Time.deltaTime);


        Vector2 pos = player.transform.position;
        pos.x = Mathf.Clamp(pos.x, minX + halfScale, maxX - halfScale);
        pos.y = Mathf.Clamp(pos.y, minY + halfScale , maxY - halfScale);
        player.transform.position = pos;
    }
}
