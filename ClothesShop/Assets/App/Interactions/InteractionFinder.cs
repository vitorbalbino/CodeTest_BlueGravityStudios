using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionFinder : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<Interaction>(out Interaction inter))
        {
            inter.EnableInteraction();
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.TryGetComponent<Interaction>(out Interaction inter))
        {
            inter.DisableInteraction();
        }
    }
}