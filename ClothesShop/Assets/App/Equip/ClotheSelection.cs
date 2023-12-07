using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClotheSelection : MonoBehaviour
{
    // Head

    [SerializeField] private SpriteRenderer 
        SRnd_Head_Skin, // Skin color block
        SRnd_Head_Face, // Face expression or mask
        SRnd_Head_Hair, // Hair or Hood

        SRnd_WristL,
        SRnd_WristR,

        SRnd_WeaponL,
        SRnd_WeaponR,

        SRnd_ElbowL,
        SRnd_ElbowR,

        SRnd_ShoulderL,
        SRnd_ShoulderR,

        SRnd_Torso,

        SRnd_LegL,
        SRnd_LegR,

        SRnd_BootL,
        SRnd_BootR,
        
        SRnd_Pelvis;

    internal void Equip(Item[] items)
    {
        foreach (Item item in items)
        {
            SetImageOnSprite(SRnd_LegL, item.Spr_LegL);
            SetImageOnSprite(SRnd_LegR, item.Spr_LegR);
            SetImageOnSprite(SRnd_BootL, item.Spr_BootL);
            SetImageOnSprite(SRnd_BootR, item.Spr_BootR);

            SetImageOnSprite(SRnd_Pelvis, item.Spr_Pelvis);
            SetImageOnSprite(SRnd_Torso, item.Spr_Torso);

            SetImageOnSprite(SRnd_WristR, item.Spr_WristR);
            SetImageOnSprite(SRnd_WeaponR, item.Spr_WeaponR);
            SetImageOnSprite(SRnd_ElbowR, item.Spr_ElbowR);
            SetImageOnSprite(SRnd_ShoulderR, item.Spr_ShoulderR);

            SetImageOnSprite(SRnd_WristL, item.Spr_WristL);
            SetImageOnSprite(SRnd_WeaponL, item.Spr_WeaponL);
            SetImageOnSprite(SRnd_ElbowL, item.Spr_ElbowL);
            SetImageOnSprite(SRnd_ShoulderL, item.Spr_ShoulderL);

            SetImageOnSprite(SRnd_Head_Skin, item.Spr_Head_Skin);
            SetImageOnSprite(SRnd_Head_Face, item.Spr_Head_Face);
            SetImageOnSprite(SRnd_Head_Hair, item.Spr_Head_Hair);
        }
    }

    void SetImageOnSprite(in SpriteRenderer spr, Sprite sprite)
    {
        if (sprite == null)
        {
            return;
        }

        spr.gameObject.SetActive(true);
        spr.enabled = true;
        spr.sprite = sprite;
    }
}
