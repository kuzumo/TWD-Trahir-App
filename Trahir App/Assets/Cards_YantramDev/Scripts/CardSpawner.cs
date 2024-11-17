using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSpawner : MonoBehaviour 
{
    public Card cardPrefab;
    Random_ButThat randomCards;
    public Button spawnButton;
    public Button distributeCardsButton;
    public Text selectUsersText;
    public GameObject playersParent;

    void Start()
    {
        randomCards = FindObjectOfType<Random_ButThat>();
        spawnButton.onClick.AddListener(SpawnNeededCards);
    }

    public void SpawnNeededCards()
    {
        // Shuffle the deck here
        AllCards_Detail.instance.ShuffleDeck(); // Shuffle the deck again before spawning

        for (int i = 0; i < AllCards_Detail.instance.cards.Length; i++) 
        {
            SpawnCard(i);  // Pass shuffled card index here
        }

        spawnButton.gameObject.SetActive(false);
        distributeCardsButton.gameObject.SetActive(true);
        selectUsersText.gameObject.SetActive(false);
    }

    void SpawnCard(int i)
    {
        Card cardObj = Instantiate(cardPrefab) as Card;
        cardObj.transform.SetParent(transform, false);
        
        // Initialize the card with the shuffled ID
        cardObj.InitCard(i);  // Pass the shuffled card ID to initialize the card
    }
}
