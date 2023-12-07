using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class EquipUI : MonoBehaviour
{
    public static EquipUI Sgt { get; private set; }

    [SerializeField] EquipCard Card;

    public GameObject Content;
    public GridElement _gridElement;
    private List<GridElement> GridElementsList = new List<GridElement>();
    private List<Item> itemsToEquip;

    [SerializeField] TMP_Text PlayerMoneyText;

    Dictionary<ItemType, Item> EquipedItems = new Dictionary<ItemType, Item>();

    [SerializeField] ClotheSelection PlayerClothes;


    private void Awake()
    {
        Sgt = this;
    }

    void OnEnable()
    {
        ResetUI();
    }

    public void ResetUI()
    {
        itemsToEquip = GameManager.Sgt.PlayerData.Items;

        PlayerMoneyText.text = "$ " + GameManager.Sgt.PlayerData.Money;

        foreach (GridElement gridElement in GridElementsList)
        {
            Destroy(gridElement.gameObject);
        }

        GridElementsList.Clear();

        foreach (Item item in itemsToEquip)
        {
            GameObject newGridElement = Instantiate(_gridElement.gameObject, Content.transform);


            var gridElement = newGridElement.GetComponent<GridElement>();

            gridElement.item = item;
            gridElement.SelectElement += OnClickElement;

            gridElement.AddImages(item);

            gridElement.UISelected(EquipedItems.Values.Contains(item));

            newGridElement.SetActive(true);

            GridElementsList.Add(gridElement);
        }

        Card.ResetCard();
    }

    public void OnClickElement(object origin, GridElement selected)
    {
        if (EquipedItems.ContainsKey(selected.item.type))
        {
            EquipedItems[selected.item.type] = selected.item;
        }
        else
        {
            EquipedItems.Add(selected.item.type, selected.item);
        }

        foreach (GridElement gridElement in GridElementsList)
        {
            gridElement.UISelected(EquipedItems.Values.Contains(gridElement.item));
        }
        var list = EquipedItems.Values.ToList();
        UpdateCard(list);
    }

    private void UpdateCard(List<Item> list)
    {
        Card.UpdateCard(list);
    }


    private void OnDisable()
    {
        SelectClothes();
    }

    private void SelectClothes()
    {
        PlayerClothes.Equip(EquipedItems.Values.ToArray());
    }
}