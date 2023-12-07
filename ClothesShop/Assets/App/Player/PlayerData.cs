using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData
{
    [SerializeField] private int _money = 25;
    public int Money { get { return _money; } private set { _money = value; } }


    [SerializeField] private List<Item> _items = new List<Item>();
    public List<Item> Items { get { return _items; } private set { _items = value; } }


    public void BuyItem(Item item)
    {
        Items.Add(item);

        Money -= item.price;
    }

    public void SellItem(Item item)
    {
        Items.Remove(item);

        Money -= item.price;
    }


    public void SetMoney(int money)
    {
        Money = money;
    }
}
