using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Card : MonoBehaviour
{
    public Animator anim;
    private GameObject front;
    private GameObject back;
    BoxCollider2D collider2D;
    private SpriteRenderer sp;

    public bool isFlipped = false;

    public int idx;

    private void Awake()
    {
        collider2D = GetComponent<BoxCollider2D>();
        front = transform.Find("Front").gameObject;
        back = transform.Find("Back").gameObject;

        sp = front.GetComponent<SpriteRenderer>();

        front.SetActive(false);
        back.SetActive(true);
    }

    public void Flip()
    {
        if (GameManager.Instance.isCanFlip == false) return;
        if (GameManager.Instance.inputBlocked) return;

        isFlipped = !isFlipped;
        // front.SetActive(isFlipped);
        //   back.SetActive(!isFlipped);

        anim.SetBool("IsOpen", true);
        anim.SetBool("Idlemode", false);
        collider2D.enabled = false;
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
        Invoke("CloseCardInvoke", 0.8f);
      //  front.SetActive(false);
      //  back.SetActive(true);
    }
    void CloseCardInvoke()
    {
        collider2D.enabled = true;
        anim.SetBool("IsOpen", false);
    }
    public void Idlemode()
    {
        anim.SetBool("Idlemode", true);
    }
}

