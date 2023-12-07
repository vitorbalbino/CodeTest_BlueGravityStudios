using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class CursorManager : MonoBehaviour
{
    public static CursorManager Sgt;

    public CursorElement CursorDefault, CursorOnHover;

    bool IsOnHover;

    List<IPointerClickHandler> OnHoverList = new List<IPointerClickHandler>();


    [System.Serializable]
    public class CursorElement
    {
        public Texture2D Icon;
        public Vector2 HotsPot;
    }


    void SetCursor(CursorElement cursor, bool isOnHover)
    {
        Debug.Log("Cursor isOnHover = " + isOnHover);

        Cursor.SetCursor(cursor.Icon, cursor.HotsPot, CursorMode.Auto);
        this.IsOnHover = isOnHover;
    }


    void SetDefault()
    {
        SetCursor(CursorDefault, false);
    }


    void SetOnHover()
    {
        SetCursor(CursorOnHover, true);
    }


    bool IsPointerOverUIObject()
    {
        

        return (OnHoverList.Count() != 0);
    }

    private void OnSceneGUI()
    {
        HandleUtility.AddDefaultControl(0);

        //Detect mouse events
        if (Event.current.type == EventType.MouseEnterWindow)
        {
            GameObject pickedObject = HandleUtility.PickGameObject(Event.current.mousePosition, true);

            //If selected null or a non child of the component gameobject
            if (pickedObject != null && pickedObject.TryGetComponent<IPointerClickHandler>(out IPointerClickHandler clickHandler))
            {
                OnHoverList.Add(clickHandler);
            }
        }
    }


    void Awake()
    {
        SetDefault();
        Cursor.lockState = CursorLockMode.Confined;

        Sgt = this;
    }


    void Update()
    {
        if (IsPointerOverUIObject())
        {
            if (!IsOnHover) SetOnHover();
        }
        else if (IsOnHover) SetDefault();
    }


    // public:


    public void AddOnHoverList(OnMouseOverLabel item)
    {
        //if (!OnHoverList.Contains(item)) OnHoverList.Add(item);
    }


    public void RemoveOnHoverList(OnMouseOverLabel item)
    {
        //if (OnHoverList.Contains(item)) OnHoverList.Remove(item);
    }
}
