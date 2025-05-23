using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class YHCard : MonoBehaviour
{
    public int idx = 0;

   // public GameObject front;
    //public GameObject back;

   // public Animator anim;

//    AudioSource audioSource;
//    public AudioClip clip;

    float x;
    float y;

    bool canclick = true;
 //   public SpriteRenderer frontImage;

    // Start is called before the first frame update
    void Start()
    {
     //   audioSource = GetComponent<AudioSource>();
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
     //   frontImage.sprite = Resources.Load<Sprite>($"rtan{idx}");
    }
 
    /*
    public void OpenCard()
    {
        if (YHGameManager.Instance.Two_card_Open == false)
        {
            if (canclick)
            {
                anim.SetBool("IsOpen", true);
                anim.SetBool("Idlemode", false);

                if (YHGameManager.Instance.firstCard == null)
                {
                    YHGameManager.Instance.firstCard = this;
                }
                else
                {
                    YHGameManager.Instance.secondCard = this;
                    YHGameManager.Instance.Matched();
                }
            }
        }
    }
    */

    public void CardMove(int card_number, int GameMode)
    {
        if(GameMode == 0)
        {
            x = (card_number % 5) * 1.1f - 2.15f;
            y = (card_number / 5) * 1.35f - 2.14f;
        }
        else
        {
            x = (card_number % 5) * 1.1f - 2.15f;
            y = (card_number / 5) * 1.5f - 3.9f;
        }

    }

    public void DestroyCard()
    {
        Invoke("DestroyCardInvoke", 1.0f);
    }

    void DestroyCardInvoke()
    {
        Destroy(gameObject);
    }
   

}
