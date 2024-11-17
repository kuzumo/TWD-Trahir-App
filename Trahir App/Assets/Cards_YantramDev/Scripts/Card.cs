using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public enum CardType
{
	// Diamond, 
	// Spade,
	// Heart,
	// Club
    Special
}

public class Card : MonoBehaviour
{
    GameManager_Cards gameManager;

	public int cardID;
	public int cardNumber;
	public CardType cardType;
    public Sprite cardSprite;

    public Sprite defaultSprite;

	//AllCards_Detail allCards;
	Random_ButThat randomCards;

    public float flipBackTime = 0.5f;

    public bool hasBeenChacked = false;

	void Start()
	{
        //allCards = FindObjectOfType<AllCards_Detail>();
        //randomCards = FindObjectOfType<Random_ButThat> ();

        gameManager = FindObjectOfType<GameManager_Cards>();
	}

    public void InitCard(int id)
    {
        if (AllCards_Detail.instance.cards != null)
        {
            cardID = AllCards_Detail.instance.cards[id].cardId; // Random card ID from the shuffled array
            cardNumber = AllCards_Detail.instance.cards[id].cardNumber;
            cardType = AllCards_Detail.instance.cards[id].cardType;

            cardSprite = AllCards_Detail.instance.cards[id].cardSprite;
        }
        else
        {
            print("Something bad happened! Please Reset the Game");
        }

        GetComponent<SpriteRenderer>().sprite = defaultSprite; // Show default sprite before flip
    }


    public void FlipCard_Face()
    {
        GetComponent<SpriteRenderer>().sprite = cardSprite;
        gameObject.transform.parent.parent.GetComponent<PlayerController>().CardsOnFace += 1;

        if (!hasBeenChacked)
        {
            gameManager.checkedNumberOfCards += 1;
        }
        hasBeenChacked = true;

        

        Invoke("FlipCard_Back", flipBackTime);
    }

    void FlipCard_Back()
    {
        if (hasBeenChacked)
        return; // Do nothing if the card is already revealed
        
        GetComponent<SpriteRenderer>().sprite = defaultSprite;
        gameObject.transform.parent.parent.GetComponent<PlayerController>().CardsOnFace -= 1;
    }
}


