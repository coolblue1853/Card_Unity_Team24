using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject[] bullets;
    public Transform player;

    int pivot = 0;
    void Start()
    {
        bullets = new GameObject[30];
        for(int i = 0; i < bullets.Length; i++)
        {
            GameObject gameObject = Instantiate(bulletPrefab);
            bullets[i] = gameObject;
            gameObject.SetActive(false);
        }
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(0.5f);
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
            Vector2 targetPos = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1));
            direction = (targetPos - spawn).normalized;
        }

        bullets[pivot].GetComponent<bullet>().Direction(direction);

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
}
