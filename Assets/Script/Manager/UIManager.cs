using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Diagnostics;

public class UIManager : MonoBehaviour
{
    int _order = 10;

    Stack<UI_Popup> _popupStack = new Stack<UI_Popup>();
    public static UIManager instance;

    public GameObject Root
    {
        get
        {
            GameObject root = GameObject.Find("PopupUI_Root");
            if (root == null)
                root = new GameObject { name = "PopupUI_Root" };
            return root;
        }
    }
    private void Awake()
    {
        // 싱글톤
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(this.gameObject);
    }
    private void Start()
    {

    }
    public void SetCanvas(GameObject go, bool sort = true) // 기존 UI 오더를 채워주는 기능
    {
        Canvas canvas = go.GetComponent<Canvas>();
        if(canvas == null)
        {
            go.AddComponent<Canvas>();
            canvas = go.GetComponent<Canvas>();
        }

        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.overrideSorting = true;
        if (sort)
        {
            canvas.sortingOrder = _order;
            _order++;
        }
        else
            canvas.sortingOrder = 0;
    }
    public GameObject ShowPopupUI(string name = null)
    {
        GameObject prefab = Resources.Load<GameObject>($"Prefabs/UI/Popup/{name}");
        GameObject ui = Instantiate(prefab); 
        if (ui == null)
            return null;

        UI_Popup popup = ui.GetComponent<UI_Popup>();
        _popupStack.Push(popup);

        ui.transform.SetParent(Root.transform);
        return ui;
    }

    //확정적으로 원하는녀석 삭제하는지 체크
    public void ClosePopupUI(UI_Popup popup)
    {
        if (_popupStack.Count == 0) return;
        if (_popupStack.Peek() != popup)
        {
            Debug.Log("Close Popup Failed");
            return;
        }
        ClosePopupUI();
    }
    // 오버라이딩
    public void ClosePopupUI()
    {
        if (_popupStack.Count == 0) return;

        UI_Popup popup = _popupStack.Pop();
        Destroy(popup.gameObject);
        popup = null;

        _order--;
    }


}
