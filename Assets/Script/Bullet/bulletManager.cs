using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletManager : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject[] bullets;
    int pivot = 0;
    void Start()
    {
        bullets = new GameObject[100];
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
        yield return new WaitForSeconds(0.1f);
        bullets[pivot].SetActive(true);
        pivot++;

        if(pivot == bullets.Length)
            pivot = 0;

        StartCoroutine(Shoot());
    }
}
