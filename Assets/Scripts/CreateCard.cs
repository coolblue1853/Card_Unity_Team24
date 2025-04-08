using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CreateCard : MonoBehaviour
{
    public static int GameMode = 0; // 0 == Eazy, 1 == Hard

    public GameObject Card;

    public void EazyMode()
    {
        int[] arr = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4 };

        arr = arr.OrderBy(x => Random.Range(0f, 4f)).ToArray();

        for (int i = 0; i < 2; ++i)
        {
            for (int j = 0; j < 5; ++j)
            {
                GameObject go = Instantiate(Card, this.transform);

                float x = (j % 5) + (j * 0.1f) - 2.2f;
                float y = i * 1.5f - 3.575f;

                go.transform.position = new Vector2(x, y);

                // go.GetComponent<Card>().Setting(arr[i]);
                // 해석: Card라는 스크립트 컴포넌트에있는 Setting함수 쓰기
            }
        }
    }

    public void HardMode()
    {
        int[] arr = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9 };

        arr = arr.OrderBy(x => Random.Range(0f, 9f)).ToArray();

        for (int i = 0; i < 4; ++i)
        {
            for (int j = 0; j < 5; ++j)
            {
                GameObject go = Instantiate(Card, this.transform);

                float x = (j % 5) + (j * 0.1f) - 2.2f;
                float y = i * 1.25f - 4.2f;

                go.transform.position = new Vector2(x, y);

                // go.GetComponent<Card>().Setting(arr[i]);
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

        //GameManager.Instance.CardCount = arr.Length;
    }

    void Update()
    {
        
    }
}
