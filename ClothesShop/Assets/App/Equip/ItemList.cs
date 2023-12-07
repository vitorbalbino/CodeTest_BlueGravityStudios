using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ItemList", order = 1)]

public class ItemList : ScriptableObject
{
    public List<Item> items;
}
