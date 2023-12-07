using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEditor.Progress;

public class Interaction : MonoBehaviour
{
    [SerializeField] UnityEvent UEvent;

    public string _actionName = "";
    public string ActionName { get { return _actionName; } private set { _actionName = value; } }

    public void EnableInteraction()
    {
        CanvasInput.Sgt.AddInteraction(this);
    }

    public void DisableInteraction()
    {
        CanvasInput.Sgt.RemoveInteraction(this);
    }

    internal void Invoke()
    {
        UEvent.Invoke();
    }
}
