using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemsCard : MonoBehaviour
{
    [SerializeField] TMP_Text ItemName, ItemPrice;
    Item itemSelected;

    public Image Img_Character, Img_ItemPref;
    public List<GameObject> imgList = new List<GameObject>();

    public void UpdateCard(Item item)
    {
        ResetCard();

        if (item == null) return;

        this.gameObject.SetActive(true);

        itemSelected = item;

        ItemName.text = item.ItemName;
        ItemPrice.text = "$ " + item.price;

        AddImages(item);
    }


    private void AddImages(Item item)
    {
        AddImage(item.Spr_LegL);
        AddImage(item.Spr_LegR);
        AddImage(item.Spr_BootL);
        AddImage(item.Spr_BootR);

        AddImage(item.Spr_WristR);
        AddImage(item.Spr_ElbowR);
        AddImage(item.Spr_ShoulderR);

        AddImage(item.Spr_Pelvis);
        AddImage(item.Spr_Torso);

        AddImage(item.Spr_WristL);
        AddImage(item.Spr_ElbowL);
        AddImage(item.Spr_ShoulderL);

        AddImage(item.Spr_Head_Skin);
        AddImage(item.Spr_Head_Face);
        AddImage(item.Spr_Head_Hair);
    }


    public void OnBuy()
    {
        if (GameManager.Sgt.PlayerData.Money < itemSelected.price)
        {
            CanvasInput.Sgt.TrowAlert("Not enought money.");
            return;
        }

        GameManager.Sgt.PlayerData.BuyItem(itemSelected);
        ShopUI.Sgt.ResetUI();
    }


    public void AddImage(Sprite sprite)
    {
        if (sprite == null) return;

        GameObject newImg = Instantiate(Img_ItemPref.gameObject, Img_Character.transform);

        Image img = newImg.GetComponent<Image>();

        img.sprite = sprite;

        imgList.Add(newImg);

        newImg.SetActive(true);
    }


    public void ClearImages()
    {
        foreach (GameObject img in imgList)
        {
            Destroy(img);
        }

        imgList.Clear();
    }


    public void ResetCard()
    {
        this.gameObject.SetActive(false);
        ClearImages();
    }
}
