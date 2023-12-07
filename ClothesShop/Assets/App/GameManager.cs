using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Sgt;

    [SerializeField] public PlayerData PlayerData;

    private bool _isPause = false;
    public bool IsPause
    {
        get { return _isPause; }
        private set { _isPause = value; }
    }


    [SerializeField] private ItemList _itemList;
    public ItemList ItemList
    {
        get { return _itemList; }
        private set { _itemList = value; }
    }


    public void Pause()
    {
        Time.timeScale = 0;
        IsPause = true;
    }


    public void Unpause()
    {
        Time.timeScale = 1;
        IsPause = false;
    }


    private void Awake()
    {
        Sgt = this;

        PlayerData = new PlayerData();
    }
}