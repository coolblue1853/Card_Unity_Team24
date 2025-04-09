using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Card : MonoBehaviour
{
    private GameObject front;
    private GameObject back;

    private SpriteRenderer sp;

    public bool isFlipped = false;

    public int idx;

    private void Awake()
    {
        front = transform.Find("Front").gameObject;
        back = transform.Find("Back").gameObject;

        sp = front.GetComponent<SpriteRenderer>();

        front.SetActive(false);
        back.SetActive(true);
    }

    public void Flip()
    {
        if (GameManager.Instance.inputBlocked) return;

        isFlipped = !isFlipped;
        front.SetActive(isFlipped);
        back.SetActive(!isFlipped);

        if (GameManager.Instance.firstCard == null)
        {
            GameManager.Instance.firstCard = this;
        }
        else
        {
            if (GameManager.Instance.firstCard == this)
            {
                GameManager.Instance.firstCard = null;
            }
            else
            {
                GameManager.Instance.secondCard = this;

                // 클릭 비활성화
                GameManager.Instance.inputBlocked = true;

                //GameManager.Instance.Matched(); (오류나는거)

                GameManager.Instance.StartCoroutine(GameManager.Instance.MatchedCoroutine());
            }
        }
    }

    public void Setting(int number)
    {
        idx = number;
        sp.sprite = Resources.Load<Sprite>($"{idx}");
    }

    public void DestroyCard()
    {
        Destroy(gameObject);
    }

    public void CloseCard()
    {
        front.SetActive(false);
        back.SetActive(true);
    }
}

