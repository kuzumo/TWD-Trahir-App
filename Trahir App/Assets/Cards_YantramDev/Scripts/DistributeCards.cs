using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistributeCards : MonoBehaviour
{
    public Transform cardsParent;
    public Transform playersParent;

    public int cardsToDistribute = 1;

    public float offset = 0.2f;
    public float offsetLocal = 0.3f;

    GameManager_Cards gameManager;

    public float lerpRate = 0.4f;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager_Cards>();
    }

    public void DistributeToAvailablePlayers()
    {
        PlayerController[] players = playersParent.GetComponentsInChildren<PlayerController>();

        // Loop through players and distribute cards randomly
        int cardIndex = 0;  // Start from the first card in the shuffled array
        foreach (PlayerController player in players)
        {
            if (player.canTakeCards)
            {
                // Give one card to the player
                DistributeToPlayer(player, cardIndex);
                cardIndex++;  // Move to the next card in the shuffled array
            }
            player.GetComponent<BoxCollider2D>().enabled = false; // Disable card interaction
        }

        // Delete remaining cards from Cards Parent
        Card[] remainingCards = cardsParent.GetComponentsInChildren<Card>();
        foreach (Card card in remainingCards)
            Destroy(card.gameObject);

        GetComponent<Button>().interactable = false; // Disable distribute button
    }

    void DistributeToPlayer(PlayerController player, int cardIndex)
    {
        JumpCardTo(player, cardIndex); // Now passing the cardIndex
    }

    void JumpCardTo(PlayerController player, int cardIndex)
    {
        Transform cardT = cardsParent.GetChild(0).transform; // Get the first card
        Transform playerCardPosT = player.transform.GetChild(0).transform; // Get the player's card position

        cardT.SetParent(playerCardPosT); // Move the card under the player’s card position

        // Set the card sprite here using the cardIndex
        Card card = cardT.GetComponent<Card>();
        card.InitCard(cardIndex); // Initialize the card with the correct sprite from the shuffled deck

        // You can then animate the card to the player if needed
        Vector3 newPos_local = Vector3.zero;
        cardT.localRotation = Quaternion.Euler(Vector3.zero);
        StartCoroutine(AnimateCardToPlayer_Local(cardT, newPos_local));
    }

    IEnumerator AnimateCardToPlayer_Local(Transform card, Vector3 newPos)
    {
        float timeElapsed = 0;
        float timeToLerp = 1f;

        while (timeElapsed < timeToLerp)
        {
            card.localPosition = Vector3.Lerp(card.localPosition, newPos, lerpRate); //old
            //card.position = Vector3.Lerp(card.localPosition, newPos, lerpRate); //new

            if (Vector3.Distance(card.position, newPos) < 0.01f)
            {
                card.localPosition = newPos;
                timeElapsed = timeToLerp + 1;
            }

            timeElapsed += Time.deltaTime;

            yield return null;
        }

        gameManager.allAvailableCards_Number = FindObjectsOfType<Card>().Length;
        print("Total Cards : " + gameManager.allAvailableCards_Number);

        gameObject.SetActive(false); // disable distribute button
    }
}
