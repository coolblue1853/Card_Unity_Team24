using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector2 direction;
    public float speed = 5f;

    void Update()
    {
        transform.Translate(direction * speed *  Time.deltaTime);
    }

    public void Direction(Vector2 dir)
    {
        direction = dir.normalized;
        StartCoroutine(Disable());
    }

    IEnumerator Disable()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }
}
