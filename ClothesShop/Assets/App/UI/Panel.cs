using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static Unity.VisualScripting.Antlr3.Runtime.Tree.TreeWizard;

[Serializable]
public class Panel : MonoBehaviour
{
    [SerializeField] UnityEvent ResetUEvent;

    bool _isOpen;
    public bool IsOpen {  get { return _isOpen; } private set { _isOpen = value; } }


    [SerializeField] bool _isExclusive;
    public bool IsExclusive { get { return _isExclusive; } private set { _isExclusive = value; } }

    [SerializeField] bool _pauseGame;
    public bool PauseGame { get { return _pauseGame; } private set { _pauseGame = value; } }


    protected void Reset()
    {
        ResetUEvent.Invoke();
    }


    public void Open()
    {
        if (!IsOpen)
            Reset();

        IsOpen = true;

        this.gameObject.SetActive(true);
    }


    public void Close()
    {
        IsOpen = false;
        this.gameObject.SetActive(false);
    }


    public void Hide()
    {
        this.gameObject.SetActive(false);
    }

    public bool IsOnScreen()
    {
        return IsOpen && this.gameObject.activeInHierarchy;
    }
}
