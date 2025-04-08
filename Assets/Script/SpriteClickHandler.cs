using UnityEngine;

public class SpriteClickHandler : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ��Ŭ��
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                OnSpriteClicked();
            }
        }
    }

    private void OnSpriteClicked()
    {
        Debug.Log("Sprite clicked!");
        // ���ϴ� �Լ� ȣ��
    }
}
