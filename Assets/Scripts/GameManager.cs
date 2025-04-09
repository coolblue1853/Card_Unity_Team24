using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject gameOverText;

    public Card firstCard;
    public Card secondCard;

    public Text timerText;
    public Text timer;
    public Text scoreText;
    public Text score;

    public Image img0;  public Text name0;
    public Image img1;  public Text name1;
    public Image img2;  public Text name2;
    public Image img3;  public Text name3;
    public Image img4;  public Text name4;

    public int cardCount = 0; // 남은 카드

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
        gameOverText.SetActive(false);
        isGameEnded = false;
        Time.timeScale = 1.0f;
    }

    public void GameClear()
    {
        //클리어하면 팀원 사진5개 + 소개
        timerText.gameObject.SetActive(false);
        timer.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
        score.gameObject.SetActive(false);

        img0.gameObject.SetActive(true);
        img1.gameObject.SetActive(true);
        img2.gameObject.SetActive(true);
        img3.gameObject.SetActive(true);
        img4.gameObject.SetActive(true);

        name0.gameObject.SetActive(true);
        name1.gameObject.SetActive(true);
        name2.gameObject.SetActive(true);
        name3.gameObject.SetActive(true);
        name4.gameObject.SetActive(true);

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
        if (firstCard.idx == secondCard.idx) // 이 부분이 더블클릭시 오류(인보크 이용할경우).
        {
            firstCard.DestroyCard();
            secondCard.DestroyCard();
            Score.PlusScore((int)Timer.time);
            cardCount -= 2;
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