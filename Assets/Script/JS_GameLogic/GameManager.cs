using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public  bool isCanFlip = false;

    public GameObject hiddenGame;

    public Card firstCard;
    public Card secondCard;

    public Text timerText;
    public Text timer;
    public Text scoreText;
    public Text score;

    public GameObject endGamePanel;
    public GameObject gameoverPanel;

    public int cardCount = 0; // ���� ī��

    public bool isGameEnded = false;
    public bool inputBlocked = false;

    public Text endScore;
    public Text endAddScore;
    public Text endResultScore;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        isCanFlip = false;
        isGameEnded = false;
        Time.timeScale = 1.0f;
    }

    public void StartHiddenGame()
    {
        timerText.gameObject.SetActive(false);
        timer.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
        score.gameObject.SetActive(false);
        hiddenGame.SetActive(true);
    }
    public void GameClear()
    {
        //Ŭ�����ϸ� ���� ����5�� + �Ұ�
        timerText.gameObject.SetActive(false);
        timer.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
        score.gameObject.SetActive(false);

        endGamePanel.SetActive(true);

        //������ �ݿ�
        endScore.text = $"���� : {Score.instance.GetSocre()}";
        endAddScore.text = $"�߰� : {Score.instance.GetAddSocre()}";
        endResultScore.text = $"��� : {Score.instance.GetSocre() + Score.instance.GetAddSocre()}";
        isGameEnded = true;
        Time.timeScale = 0.0f;
    }

    public void GameOver()
    {
        isGameEnded = true;
        gameoverPanel.SetActive(true);
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
    public void OnGoMainButtonClicked()
    {
        SceneManager.LoadScene("Start");
    }

    //public void Matched()
    //{
    //    if (firstCard.idx == secondCard.idx) // �� �κ��� ����Ŭ���� ����(�κ�ũ �̿��Ұ��).
    //    {
    //        firstCard.DestroyCard();
    //        secondCard.DestroyCard();
    //        Score.PlusScore((int)Timer.time);
    //        cardCount -= 2;
    //    }
    //    else
    //    {
    //        firstCard.CloseCard();
    //        secondCard.CloseCard();
    //    }

    //    firstCard.isFlipped = false;
    //    secondCard.isFlipped = false;
    //    firstCard = null;
    //    secondCard = null;
    //}

    public IEnumerator MatchedCoroutine()
    {
        yield return new WaitForSeconds(0.5f); // 0.5�� ������

        if (firstCard.idx == secondCard.idx)
        {
            Invoke("Destroyd_Invoke", 0.5f);
        }
        else
        {
            firstCard.CloseCard();
            secondCard.CloseCard();
        }

        // Ŭ�� Ȱ��ȭ

        Invoke("Card_null_Invoke", 0.5f);

    }
    void Destroyd_Invoke()
    {
        firstCard.DestroyCard();
        secondCard.DestroyCard();
        Score.PlusScore((int)Timer.time);
        cardCount -= 2;
    }
    void Card_null_Invoke()
    {
        firstCard.isFlipped = false;
        secondCard.isFlipped = false;
        firstCard = null;
        secondCard = null;
        inputBlocked = false;
    }
}