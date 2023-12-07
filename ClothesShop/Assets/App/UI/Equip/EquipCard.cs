using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EquipCard : MonoBehaviour
{
    public List<GameObject> imgList = new List<GameObject>();
    private List<Item> itemsSelected;

    public Image Img_Character, Img_ItemPref;

    public void UpdateCard(List<Item> list)
    {
        ResetCard();

        if (list.Count <= 0) return;

        this.gameObject.SetActive(true);

        itemsSelected = list;


        AddImageForType(ItemType.Accessories);

        AddImageForType(ItemType.Torso);

        AddImageForType(ItemType.Head);
    }


    void AddImageForType(ItemType type)
    {
        var part = itemsSelected.Where(x => x.type == type);
        if (part.Any()) AddImages(part.First());
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
