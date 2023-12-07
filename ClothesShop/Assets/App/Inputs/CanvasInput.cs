using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class CanvasInput : MonoBehaviour
{
    public static CanvasInput Sgt;

    [SerializeField] private Panel PlayerEquipPanel;
    [SerializeField] private Panel StorePanel;
    [SerializeField] private PanelVision vision;
    
    [SerializeField] private List<Interaction> interactions = new List<Interaction>();
    [SerializeField] private Panel InteractionButton;
    [SerializeField] private TMP_Text InteractionLabel;

    public Panel Alert;
    public TMP_Text AlertDescription;

    public void OnInventory()
    {
        if (!PlayerEquipPanel.IsOnScreen()) vision.OpenPanel(PlayerEquipPanel);
        else vision.ClosePanel(PlayerEquipPanel);
    }

    
    public void OnStore()
    {
        if (!StorePanel.IsOnScreen()) vision.OpenPanel(StorePanel);
        else vision.ClosePanel(StorePanel);
    }


    public void TrowAlert(string text)
    {
        AlertDescription.text = text;
        Alert.gameObject.SetActive(true);
    }


    public void InvokeInteraction()
    {
        if (interactions.Count > 0)
        {
            interactions.Last().Invoke();
        }
    }


    private void UpdateInteraction()
    {
        if (interactions.Count > 0)
        {
            vision.OpenPanel(InteractionButton);
            InteractionLabel.text = interactions[0].ActionName;
        }
        else
        {
            vision.ClosePanel(InteractionButton);
        }
    }


    public void AddInteraction(Interaction item)
    {
        if (!interactions.Contains(item))
        {
            interactions.Add(item);

            UpdateInteraction();
        }
    }


    public void RemoveInteraction(Interaction item)
    {
        if (interactions.Contains(item))
        {
            interactions.Remove(item);

            UpdateInteraction();
        }
    }


    private void Awake()
    {
        Sgt = this;
    }
}
