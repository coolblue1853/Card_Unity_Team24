using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector2 direction;
    float speed;
    public Transform rat;
    private void Start()
    {

    }
    void Update()
    {
        transform.Translate(direction * speed *  Time.deltaTime);
    }

    public void Direction(Vector2 dir , float spd)
    {
        direction = dir.normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rat.rotation = Quaternion.Euler(0, 0, angle);  // 자식만 회전
        speed = spd;
        StartCoroutine(Disable());
    }

    IEnumerator Disable()
    {
        yield return new WaitForSeconds(4f);
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
