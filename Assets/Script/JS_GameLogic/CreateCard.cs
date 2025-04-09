using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCard : MonoBehaviour
{
    public static int GameMode = 0; // 0 == Eazy, 1 == Hard

    public GameObject cardPrefab;

    void Shuffle(int[] array)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1); // i + 1 Æ÷ÇÔ
            // swap
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }

    public void EazyMode()
    {
        GameManager.Instance.cardCount = 10;
        int[] arr = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4 };
        Shuffle(arr);

        int idx = 0;

        for (int i = 0; i < 2; ++i)
        {
            for (int j = 0; j < 5; ++j)
            {
                GameObject go = Instantiate(cardPrefab, this.transform);

                float x = (j % 5) + (j * 0.1f) - 2.2f;
                float y = i * 1.5f - 3.575f;

                go.transform.position = new Vector2(x, y);
                go.GetComponent<Card>().Setting(arr[idx++]);
            }
        }
    }

    public void HardMode()
    {
        GameManager.Instance.cardCount = 20;
        int[] arr = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9 };
        Shuffle(arr);

        int idx = 0;

        for (int i = 0; i < 4; ++i)
        {
            for (int j = 0; j < 5; ++j)
            {
                GameObject go = Instantiate(cardPrefab, this.transform);

                float x = (j % 5) + (j * 0.1f) - 2.2f;
                float y = i * 1.25f - 4.2f;

                go.transform.position = new Vector2(x, y);
                go.GetComponent<Card>().Setting(arr[idx++]);
            }
        }
    }

    void Start()
    {
        if (GameMode == 0)
        {
            EazyMode();
        }
        else
        {
            HardMode();
        }
    }
}
