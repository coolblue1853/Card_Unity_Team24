using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        Timer.time = 50;
        Score.standardScore = 150;

        GameManager.Instance.cardCount = 10;
        int[] arr = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4 };
        arr = arr.OrderBy(x => Random.Range(0f, 5f)).ToArray();

        StartCoroutine(SetCard(arr, GameMode));

    }

    public void HardMode()
    {
        Timer.time = 100;
        Score.standardScore = 550;

        GameManager.Instance.cardCount = 20;
        int[] arr = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9 };
        arr = arr.OrderBy(x => Random.Range(0f, 10f)).ToArray();

        StartCoroutine(SetCard(arr, GameMode));
    }
    IEnumerator SetCard(int[] Array, int GameMode)
    {
        int idx = 0;
        for (int i = 0; i < Array.Length; i++)
        {
            GameObject go = Instantiate(cardPrefab, this.transform);

            go.GetComponent<YHCard>().CardMove(i, GameMode);
            go.GetComponent<YHCard>().Setting(Array[i]);
            go.GetComponent<Card>().Setting(Array[idx++]);
            yield return new WaitForSeconds(0.2f);
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
