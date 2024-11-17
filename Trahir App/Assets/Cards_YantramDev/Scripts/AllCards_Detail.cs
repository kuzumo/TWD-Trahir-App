using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

[System.Serializable]
public struct IndividualCard
{
	public int cardId;
	public int cardNumber;
	public CardType cardType;
    public Sprite cardSprite;
}


public class AllCards_Detail : MonoBehaviour 
{
    public IndividualCard[] cards; // Array to hold all 8 cards

    public static AllCards_Detail instance;
    public Sprite[] cardSprites;  // Array to hold all card sprites

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            instance = this;
            Destroy(instance.gameObject);
        }
        //DontDestroyOnLoad(gameObject);

        // Shuffle cards
        ShuffleDeck(); // Shuffle when game starts (optional)
        
        // Initialize cards
        InitIndividualCards();
    }

    // Make ShuffleDeck public so it can be called from CardSpawner
    public void ShuffleDeck() 
    {
        for (int i = 0; i < cards.Length; i++)
        {
            int j = Random.Range(i, cards.Length);
            // Swap the cards[i] and cards[j]
            IndividualCard temp = cards[i];
            cards[i] = cards[j];
            cards[j] = temp;
        }
    }

    void InitIndividualCards()
    {
        // Initialize cards with values (for 8 cards only)
        cards = new IndividualCard[8];  // Only 8 cards

        for (int i = 0; i < cards.Length; i++) 
        {
            cards[i].cardId = i + 1;  // Give card a unique ID (1 to 8)
            cards[i].cardNumber = i + 1;  // For simplicity, card number matches card ID (can be customized)
            cards[i].cardType = CardType.Special;  // All cards are "Special"
            cards[i].cardSprite = cardSprites[i];  // Assign the sprite from the cardSprites array
        }
    }
}
