using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : MonoBehaviour
{
    void OnInteraction()
    {
        Debug.Log("Interaction");
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other != null && other.gameObject.tag == "Player")
        {
            Debug.Log("Collided with player");
            OnInteraction();
        }
    }


    private void OnMouseEnter()
    {
        Debug.Log("OnMouseEnter");
    }

    private void OnMouseExit()
    {
        Debug.Log("OnMouseExit");
    }

    private void OnMouseDown()
    {
        OnInteraction();
    }
}
