using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using static UnityEngine.GraphicsBuffer;

public class Board : MonoBehaviour
{
    public GameObject card;

    GameObject go;
    int i;

    // Start is called before the first frame update
    void Start()
    {
        int[] arr = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };
        arr = arr.OrderBy(x => Random.Range(0f, 7f)).ToArray();

        StartCoroutine(SetCard(arr));

        YHGameManager.Instance.cardCount = arr.Length;
    }




    IEnumerator SetCard(int[] Array)
    {
        for (i = 0; i < 16; i++)
        {
            go = Instantiate(card, this.transform);

            go.GetComponent<YHCard>().CardMove(i);
            
            go.GetComponent<YHCard>().Setting(Array[i]);
            yield return new WaitForSeconds(0.2f);
        }
    }
}
