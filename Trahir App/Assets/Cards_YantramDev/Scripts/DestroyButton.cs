using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyButton : MonoBehaviour 
{
    public Button button; // Reference to the button
    public Image buttonImage; // Reference to the button's Image component
    public GameObject player; // Reference to the Player object

    public void OnMouseDown() 
    {
        // Disable the button
        button.interactable = false;

        // Change the button's image color to red
        buttonImage.color = Color.red;

        // Find the Card(Clone) under Player (at runtime)
        GameObject cardClone = FindCardClone();

        if (cardClone != null)
        {
            // Destroy the cloned card
            Destroy(cardClone);
        }
        else
        {
            Debug.LogWarning("Card(Clone) not found under Player.");
        }
    }

    private GameObject FindCardClone()
    {
        // Search for all children of the Player object and find the Card(Clone)
        foreach (Transform child in player.transform)
        {
            if (child.name == "Card(Clone)")
            {
                return child.gameObject; // Return the found Card(Clone)
            }
        }

        // If not found, return null
        return null;
    }
}
