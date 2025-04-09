using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector2 direction;
    float speed;

    private void Start()
    {
        speed = Random.Range(4, 6);
    }
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

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            BulletManager.instance.DisableAllBullets(this.gameObject);
            HiddenGameManager.Instance.GameEnd();
        }
        
    }

}
