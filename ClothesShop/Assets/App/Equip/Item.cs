using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Item", order = 1)]

public class Item : ScriptableObject
{
    public string ItemName;

    public int price;

    public ItemType type;

    public Sprite
        Spr_Head_Skin, // Skin color block
        Spr_Head_Face, // Face expression or mask
        Spr_Head_Hair, // Hair or Hood

        Spr_WristL,
        Spr_WristR,

        Spr_WeaponL,
        Spr_WeaponR,

        Spr_ElbowL,
        Spr_ElbowR,

        Spr_ShoulderL,
        Spr_ShoulderR,

        Spr_Torso,

        Spr_LegL,
        Spr_LegR,

        Spr_BootL,
        Spr_BootR,

        Spr_Pelvis;
}


public enum ItemType
{
    Accessories,
    Head,
    Torso,
    FullSet
}