using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Card firstCard;
    public Card secondCard;

    public Text timeTxt;
    public GameObject endTxt;

    AudioSource audioSource;
    public AudioClip clip;

    public GameObject TimeTxt;
    public GameObject ReadyTxt;
    public GameObject StartTxt;

    public Animator Readyanim;
    bool time_on = false;

    public bool Two_card_Open = false;
    public int cardCount = 0;
    float time = 20.0f;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Invoke("ReadyAnimInvoke", 4.5f);

        Time.timeScale = 1.0f;
        audioSource = GetComponent<AudioSource>();
    }
    void ReadyAnimInvoke()
    {
        ReadyTxt.SetActive(true);
        Readyanim.SetBool("isReady", true);
        Invoke("StartAnimInvoke", 2.5f);
    }

    void StartAnimInvoke()
    {
        StartTxt.SetActive(true);
        ReadyTxt.SetActive(false);
        Readyanim.SetBool("isStart", true);
        Invoke("Time_on_Delay", 1.5f);
    }

    void Time_on_Delay()
    {   
        StartTxt.SetActive(false);
        TimeTxt.SetActive(true);
        time_on = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (time_on)
        {
            time -= Time.deltaTime;
        }
        timeTxt.text = time.ToString("N2");

        if(time < 0.0f)
        {
            time = 0.0f;
            Time.timeScale = 0.0f;
            endTxt.SetActive(true);
        }
    }
    public void ClipInvoke()
    {
        audioSource.PlayOneShot(clip);
    }
    public void Matched()
    {
        Two_card_Open = true;
        if(firstCard.idx == secondCard.idx)
        {
            Invoke("ClipInvoke", 1.0f);
            firstCard.DestroyCard();
            secondCard.DestroyCard();
            cardCount -= 2;
            if(cardCount == 0)
            {
                Time.timeScale = 0.0f;
                endTxt.SetActive(true);
            }
        }
        else
        {
            firstCard.CloseCard();
            secondCard.CloseCard();
        }

        Invoke("Card_null_Invoke", 1.0f);       
    }

    void Card_null_Invoke()
    {
        firstCard = null;
        secondCard = null;
        Two_card_Open = false;
    }
}
