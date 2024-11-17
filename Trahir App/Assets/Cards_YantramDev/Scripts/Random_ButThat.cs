using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_ButThat : MonoBehaviour
{
    // Array to hold the 8 card IDs
    public int[] cardIds;

    // Method to initialize the cards with unique IDs (just 8 cards)
    void InitCardsArray()
    {
        // Here we just assign the 8 card IDs to the array directly
        System.Random rand = new System.Random();

        for (int i = 0; i < cardIds.Length; i++)
        {
            int tempId = rand.Next(1, 9); // Random b/w 1 and 8 (since you only have 8 cards)

            // Ensure that the ID is unique by checking all already assigned cards
            for (int j = 0; j < i; j++)
            {
                while (cardIds[j] == tempId)
                {
                    tempId = rand.Next(1, 9); // Pick a new random ID if it's a duplicate
                }
            }

            // Assign the unique ID to the array
            cardIds[i] = tempId;
        }

        print("Cards initialized with IDs: " + string.Join(", ", cardIds));
    }

    // Method to create the cards array with a given size
    public void CreateCardsArray(int size)
    {
        cardIds = new int[size]; // Size will always be 8 in your case
        InitCardsArray(); // Initialize the cards directly without threading
    }

    // Shuffle the card array (randomizing the card order)
    public void ShuffleCards()
    {
        for (int i = 0; i < cardIds.Length; i++)
        {
            int randomIndex = Random.Range(i, cardIds.Length);  // Get a random index
            int temp = cardIds[i];  // Temporarily store the value
            cardIds[i] = cardIds[randomIndex];  // Swap the current index with the random index
            cardIds[randomIndex] = temp;  // Complete the swap
        }
    }
}
