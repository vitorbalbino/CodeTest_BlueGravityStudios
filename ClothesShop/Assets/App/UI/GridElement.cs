using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GridElement : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image Img_BoxLight, Img_Character, Img_ItemPref, Img_Selector, Img_SelectorLight;

    public List<GameObject> imgList = new List<GameObject>();

    public Item item;

    bool selected;


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
            imgList.Remove(img);

            Destroy(img);
        }
    }


    public event EventHandler<GridElement> SelectElement;

    public void Click()
    {
        if (!selected)
        {
            Select();
        }
    }


    public void Select()
    {
        SelectElement?.Invoke(this, this);
    }


    public void UISelected(bool state)
    {
        Img_SelectorLight.gameObject.SetActive(state);
    }



    public void OnPointerEnter(PointerEventData eventData)
    {
        Img_Selector.gameObject.SetActive(true);
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        Img_Selector.gameObject.SetActive(false);
    }

    internal void AddImages(Item item)
    {
        AddImage(item.Spr_WristR);
        AddImage(item.Spr_ElbowR);
        AddImage(item.Spr_ShoulderR);

        AddImage(item.Spr_LegL);
        AddImage(item.Spr_LegR);
        AddImage(item.Spr_BootL);
        AddImage(item.Spr_BootR);

        AddImage(item.Spr_Pelvis);
        AddImage(item.Spr_Torso);

        AddImage(item.Spr_WristL);
        AddImage(item.Spr_ElbowL);
        AddImage(item.Spr_ShoulderL);

        AddImage(item.Spr_Head_Skin);
        AddImage(item.Spr_Head_Face);
        AddImage(item.Spr_Head_Hair);
    }
}
