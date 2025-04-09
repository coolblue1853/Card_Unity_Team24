using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Card : MonoBehaviour
{
    public int idx = 0;

    public GameObject front;
    public GameObject back;

    public Animator anim;

    AudioSource audioSource;
    public AudioClip clip;

    float x;
    float y;

    bool canclick = true;
    public SpriteRenderer frontImage;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 target = new Vector2(x, y);

        transform.position = Vector2.MoveTowards(transform.position, target, 0.1f);
    }

    public void Setting(int number)
    {
        idx = number;
        frontImage.sprite = Resources.Load<Sprite>($"rtan{idx}");
    }

    public void OpenCard()
    {
        if (GameManager.Instance.Two_card_Open == false)
        {
            if (canclick)
            {
                canclick = false;
                audioSource.PlayOneShot(clip);
                anim.SetBool("IsOpen", true);
                anim.SetBool("Idlemode", false);

                if (GameManager.Instance.firstCard == null)
                {
                    GameManager.Instance.firstCard = this;
                }
                else
                {
                    GameManager.Instance.secondCard = this;
                    GameManager.Instance.Matched();
                }
            }
        }
    }
    public void CardMove(int card_number)
    {
        x = (card_number % 4) * 1.4f - 2.1f;
        y = (card_number / 4) * 1.4f - 3.0f;
    }

    public void DestroyCard()
    {
        Invoke("DestroyCardInvoke", 1.0f);
    }

    void DestroyCardInvoke()
    {
        Destroy(gameObject);
    }
    public void CloseCard()
    {
        Invoke("CloseCardInvoke", 1.0f);
        canclick = true;
    }

    void CloseCardInvoke()
    {
        anim.SetBool("IsOpen", false);
    }

    public void Idlemode()
    {
        anim.SetBool("Idlemode", true);
    }
}
