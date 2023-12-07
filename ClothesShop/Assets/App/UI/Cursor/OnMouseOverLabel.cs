using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class OnMouseOverLabel : MonoBehaviour
{
    void OnMouseEnter()
    {
        Debug.Log("OnMouseEnter");
        CursorManager.Sgt.AddOnHoverList(this);
    }

    void OnMouseExit()
    {
        Debug.Log("OnMouseExit");
        CursorManager.Sgt.RemoveOnHoverList(this);
    }

    private void OnMouseOver()
    {
        Debug.Log("OnMouseOver");
        CursorManager.Sgt.AddOnHoverList(this);
    }
}