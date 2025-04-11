using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    // 1. 숫자 직업 때려박지 않기.
    public static BulletManager instance;
    public GameObject bulletPrefab;
    public GameObject[] bullets;
    public Transform player;

    public GameObject pivotLD;
    public GameObject pivotRU;
    int minX;
    int minY;
    int maxX;
    int maxY;


    int pivot = 0;
    float startTime;

     void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        minX = (int)pivotLD.transform.position.x;
        minY = (int)pivotLD.transform.position.y;
        maxX = (int)pivotRU.transform.position.x;
        maxY = (int)pivotRU.transform.position.y;

    }
    private void OnEnable()
    {
        startTime = Time.time;
        bullets = new GameObject[30];
        for (int i = 0; i < bullets.Length; i++)
        {
            GameObject gameObject = Instantiate(bulletPrefab);
            bullets[i] = gameObject;
            gameObject.SetActive(false);
        }
        StartCoroutine(Shoot());

    }
    void Start()
    {

    }

    IEnumerator Shoot()
    {
        float elapsed = Time.time - startTime;
        float speed = Mathf.Clamp(3f + elapsed * 0.1f, 3f, 10f);
        float cycle = Mathf.Lerp(1.5f, 0.2f, elapsed / 30f);

        yield return new WaitForSeconds(cycle);
        bullets[pivot].SetActive(true);

        Vector2 spawn = GetRandomPosition();
        bullets[pivot].transform.position = spawn;

        Vector2 direction;

        if(Random.value < 0.5f)
        {
            Vector2 targetPos = player.transform.position;
            direction = (targetPos - spawn).normalized;
        }
        else
        {
            Vector2 targetPos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            direction = (targetPos - spawn).normalized;
        }

        bullets[pivot].GetComponent<Bullet>().Direction(direction, speed);

        Vector2 GetRandomPosition()
        {
            int num = Random.Range(1,5);

            Vector2 pos = new Vector2(0,0);

                switch (num)
                {
                case 1:
                    pos = new Vector2(Random.Range(-3, 3), Random.Range(5, 6));
                    break;
                case 2:
                    pos = new Vector2(Random.Range(-3, 3), Random.Range(-6, -5));
                    break ;
                case 3:
                    pos = new Vector2(Random.Range(-4, -3), Random.Range(-5, 5));
                    break ;
                case 4:
                    pos = new Vector2(Random.Range(3, 4), Random.Range(-5, 5));
                    break ;
                }
            return pos;
        }
            pivot++;
        if(pivot == bullets.Length)
            pivot = 0;
        StartCoroutine(Shoot());
    }

    public void DisableAllBullets(GameObject exception)
    {
        for (int i = 0; i < bullets.Length; i++)
        {
            if (bullets[i] != exception)
            {
                bullets[i].SetActive(false);
            }
        }
    }
}
