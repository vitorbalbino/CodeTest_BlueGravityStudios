using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class ShopUI : MonoBehaviour
{
    public static ShopUI Sgt;

    [SerializeField] Panel ShopPannel;

    [SerializeField] ItemsCard Card;

    [SerializeField] List<Item> itemsToSell = new List<Item>();

    [SerializeField] TMP_Text PlayerMoneyText;

    public GameObject Content;
    public GridElement _gridElement;
    public List<GridElement> GridElementsList;

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
        itemsToSell = GameManager.Sgt.ItemList.items;
        itemsToSell = GameManager.Sgt.ItemList.items.Where(x => !GameManager.Sgt.PlayerData.Items.Contains(x)).ToList();

        PlayerMoneyText.text = "$ " + GameManager.Sgt.PlayerData.Money;

        foreach (GridElement gridElement in GridElementsList)
        {
            Destroy(gridElement.gameObject);
        }

        GridElementsList.Clear();

        foreach (Item item in itemsToSell)
        {
            GameObject newGridElement = Instantiate(_gridElement.gameObject, Content.transform);


            var gridElement = newGridElement.GetComponent<GridElement>();

            gridElement.item = item;
            gridElement.SelectElement += OnClickElement;

            GridElementsList.Add(gridElement);

            gridElement.AddImages(item);

            gridElement.UISelected(false);

            newGridElement.SetActive(true);
        }

        Card.ResetCard();
    }

    public void OnClickElement(object origin, GridElement selected)
    {
        foreach (GridElement gridElement in GridElementsList)
        {
            gridElement.UISelected(gridElement == selected);
        }

        UpdateCard(selected.item);
    }


    public void UpdateCard(Item item)
    {
        Card.UpdateCard(item);
    }
}
