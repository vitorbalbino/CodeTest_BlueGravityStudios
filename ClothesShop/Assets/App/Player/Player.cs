using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Sgt;
    List<Item> list_items = new List<Item>();

    [SerializeField] ClotheSelection selection;

    private void Awake()
    {
        Sgt = this;
    }

    public void GetItem(Item item)
    {
        list_items.Add(item);
    }
}
