using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject TeamsFaces;
    public GameObject gameOverText;

    public Card firstCard;
    public Card secondCard;

    public int cardCount = 1; // 남은 카드

    //bool flipCount = false; // 뒤집어 놓은 카드가 있냐 없냐

    public bool isGameEnded = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        isGameEnded = false;
        Time.timeScale = 1.0f;
    }

    public void GameClear()
    {
        int[] arr = { 0, 1, 2, 3, 4 };

        for (int i = 0; i < 5; ++i)
        {
            GameObject go = Instantiate(TeamsFaces, this.transform);

            float x = (i % 5) + (i * 0.1f) - 2.2f;

            go.transform.position = new Vector2(x, 0);
            //go.GetComponent<FinishCard>().Setting(arr[i]); 이거 하면 오류걸림(이미지넣기)
        }

        isGameEnded = true;
        Time.timeScale = 0.0f;
    }

    public void GameOver()
    {
        gameOverText.SetActive(true);
        isGameEnded = true;
        Time.timeScale = 0.0f;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10f; // or -Camera.main.transform.position.z;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            Vector2 clickPos = new Vector2(worldPos.x, worldPos.y);

            RaycastHit2D hit = Physics2D.Raycast(clickPos, Vector2.zero);

            if (hit.collider != null)
            {
                var handler = hit.collider.GetComponent<Card>();
                if (handler != null)
                {
                    handler.Flip();
                }
            }
        }
    }

    public void Matched()
    {
        if (firstCard.idx == secondCard.idx) // 이 부분이 더블클릭시 오류.
        {
            firstCard.DestroyCard();
            secondCard.DestroyCard();
        }
        else
        {
            firstCard.CloseCard();
            secondCard.CloseCard();
        }

        firstCard.isFlipped = false;
        secondCard.isFlipped = false;
        firstCard = null;
        secondCard = null;
    }
}